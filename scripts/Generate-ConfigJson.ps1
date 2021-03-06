param(
    [string]$PythonFile,
    [Switch]$Clobber
)

Set-StrictMode -Version Latest

. "$PSScriptRoot\common.ps1"

############################################################

$InPathBase = Join-Path (Get-Item $PSScriptRoot\..).FullName "pip\mxnet_cu101mkl-1.5.0-py2.py3-none-win_amd64\mxnet"
$OutPathBase = "src\Horker.MXNet\generated\mxnet\{0}.config.json"

############################################################

$ClassRe = "^class (\w+)(?:\((\w+)\))?"
$DefRe = "^( {0,4})def (\w+)\(((?:[^:]|\r|\n)*)\):"
$PropertyRe = "^ {4}@property"
$SetterRe = "^ {4}@(\w+)\.setter"
$ClassPropertyRe = "^ {4}@classproperty"
$FieldRe = "^ *self\.([a-z\d_]+)\s*=\s*(.+)"
$LineRe = "(" + ($ClassRe, $DefRe, $PropertyRe, $SetterRe, $ClassPropertyRe, $FieldRe -join ")|(") + ")"

############################################################

$Classes = [ordered]@{}

function Get-ClassObject([string]$name, [string[]]$bases)
{
    $class = $Classes[$name]
    if ($null -eq $class) {
        $class = [PSCustomObject]@{
            Name = $name
            BaseClasses = $bases
            Fields = [ordered]@{}
            Methods = [ordered]@{}
        }
        $Classes[$name] = $class
    }
    $class
}

function Infer-Type([string]$Name, [string]$DefaultValue = "") {
    $type = "object"
    if ($Name -match "name|prefix$") {
        $type = "string"
    }
    elseif ($Name -match "^_?shape$") {
        $type = "Shape"
    }
    elseif ($Name -match "stype$") {
        $type = "string"
    }
    elseif ($Name -match "^_?dtype$") {
        $type = "DType"
    }
    elseif ($Name -match "^init$") {
        $type = "Initializer"
    }
    elseif ($Name -match "^_?ctx$") {
        $type = "Context"
    }
    elseif ($Name -match "^_?ctx_list$") {
        $type = "Context[]"
    }
    elseif ($Name -match "^_?params$") {
        $type = "ParameterDict"
    }
    elseif ($DefaultValue -match "^'") {
        $type = "string"
    }
    elseif ($DefaultValue -match "^\d+") {
        if ($DefaultValue -match "\.") {
            $type = "float"
        }
        else {
            $type = "int"
        }
    }
    elseif ($DefaultValue -match "^true$") {
        $type = "bool"
    }
    elseif ($DefaultValue -match "^false$") {
        $type = "bool"
    }

    $type
}

$CsKeywords = @("params", "out")

function ReplaceTo-SafeName([string]$name) {
    if ($CsKeywords -contains $Name) {
        return "@" + $Name
    }
    return $Name
}

function Convert-Value([string]$value) {
    if ($value -match "^'") {
        return '"' + $value.Substring(1, $value.Length - 2) + '"'
    }
    if ($value -match "^\d*\.\d+$") {
        return $value + "f"
    }
    if ($value -eq "None") {
        return "null"
    }
    if ($value -eq "True") {
        return "true"
    }
    if ($value -eq "False") {
        return "false"
    }

    return $value
}

function Build-ClassDef([string[]]$lines) {
    $defType = "function"
    foreach ($l in $lines) {
        if ($l -match $ClassRe) {
            $name = $matches[1]
            $base = $matches[2] ?? "object"
            $class = Get-ClassObject $name $base
        }
        elseif ($l -match $FieldRe) {
            $name = $matches[1]
            $value = $matches[2]
            $camelCased = ConvertTo-CamelCase $name
            $type = Infer-Type $name $value
            $visibility = $camelCased -match "^_" ? "private" : "public"

            if ($name -match "^_") {
                $class.Fields[$name] = [ordered]@{
                    Signature = "private $type $camelCased;"
                }
            }
            else {
                $class.Fields[$name] = [ordered]@{
                    Signature = "public $type $camelCased { get; set; }"
                }
            }
        }
        elseif ($l -match $PropertyRe) {
            $defType = "property"
        }
        elseif ($l -match $SetterRe) {
            $defType = "setter"
        }
        elseif ($l -match $ClassPropertyRe) {
            $defType = "classProperty"
        }
        elseif ($l -match $DefRe) {
            $indent = $matches[1]
            $methodName = $matches[2]
            $returnType = (Infer-Type $methodName) + " "
            $params = $matches[3]
            $visibility = $methodName -match "^_" ? "internal" : "public"
            $static = ""

            if ($indent.Length -eq 0) {
                $class = Get-ClassObject "Helper"
                $static = "static "
            }

            if ($methodName -eq "__init__") {
                $camelCased = $class.Name
                $returnType = ""
                $visibility = "public"
            }
            else {
                $camelCased = ConvertTo-CamelCase $methodName
                if ($defType -eq "setter") {
                    $camelCased = "Set" + $camelCased
                    $returnType = "void ";
                }
            }

            if ($defType -eq "classProperty") {
                $static = "static "
            }

            $params = @(($params -split "\s*,\s*") | where {
                -not [string]::IsNullOrWhitespace($_) -and
                "self" -ne $_ -and
                ($defType -ne "classProperty" -or $_ -ne "cls") -and
                $_ -notmatch "\*\*" })

            $params.Count
            $paramString = ($params | foreach {
                $name, $defaultValue = $_ -split "\s*=\s*"
                $name = $name -replace "\*\*", ""
                $name = ReplaceTo-SafeName (ConvertTo-CamelCase $name $false)
                $type = Infer-Type $name $defaultValue

                if (-not [string]::IsNullOrEmpty($defaultValue)) {
                    $defaultValue = Convert-Value $defaultValue
                    "$type $name = $defaultValue"
                }
                else {
                    "$type $name"
                }
            }) -join ", "


            if ($defType -eq "property" -and [string]::IsNullOrEmpty($paramString)) {
                $line = "$visibility $static$returnType$camelCased"

            }
            else {
                $line = "$visibility $static$returnType$camelCased($paramString)"

            }
            $paramString

            $m = $class.Methods[$methodName]
            if ($m -eq $null) {
                 $class.Methods[$methodName] = ,@{}
            }

            $key = $defType -eq "setter" ? "SignatureSetter" : "Signature"
            $class.Methods[$methodName] = ,@{ $key = $line }

            $defType = "function"
        }
    }

    $Classes | foreach {
        $_.PSObject.Properties.Remove("Name")
    }
}

############################################################

$UsingNamespaces = @(
    "using System;"
    "using System.Linq;"
    "using System.Collections;"
    "using System.Collections.Generic;"
    "using System.Threading;"
    "using Horker.MXNet;"
    "using Horker.MXNet.Compat;"
    "using Horker.MXNet.Interop;"
    "using static Horker.MXNet.Base;"
    "using static Horker.MXNet.Compat.Compat;"
    "using static Horker.MXNet.Compat.Coercing;"
    "using static Horker.MXNet.Compat.Array;"
    "using static Horker.MXNet.MXNetCoercing;"
    "using static Horker.MXNet.MXNetCompat;"
    "using static Horker.MXNet.DType;"
    "using NDArrayHandle = System.IntPtr;"
    "using SymbolHandle = System.IntPtr;"
    "using MxInt = System.Int32;"
    "using MxUint = System.Int32;"
    "using MxInt64 = System.Int64;"
    "using PySlice = Horker.MXNet.Compat.Slice;"
    "using Tuple = System.Collections.ICollection;"
    "using List = System.Collections.ICollection;"
)

$Namespace = "Horker.MXNet"

$Replacements = [ordered]@{
    "ndarray" = "NDArray"
    "ctypes" = "CTypes"
    "dtype" = "DType"
    "stype" = "SType"
    "uint8" =  "UInt8"
}

$TypeNames = [ordered]@{
    "NDArray" = ,"NDArray"
    "SymbolBase" = ,"SymbolBase"
    "Symbol" = ,"Symbol"
    "tuple" =  ,"Tuple"
    "list" = @(
      "List<int>"
      "List<PySlice>"
      "IEnumerable<int>"
      "IEnumerable<PySlice>"
    )
    "py_slice" = ,"PySlice"
    "mx_int" = ,"mx_int"
    "mx_uint" = ,"mx_uint"
    "integer_types" = "int", "long"
    "numeric_types" = "float", "int", "long"
    "string_types" = ,"string"
}

############################################################

function Get-OutPath([string]$inPpath)
{
    $inPath = $inPath.Substring($InPathBase.Length)
    $outPath = "src\Horker.MXNet\config\mxnet\{0}.config.json" -f $inPath
    $outPath
}

############################################################

$inPath = (Get-Item (Join-Path $InPathBase $pythonFile)).FullName
$outPath = Get-OutPath $inPath

Write-Host "Input: $inPath"
Write-Host "Output: $outPath"

if (-not $Clobber -and (Test-Path $outPath)) {
    Write-Error "output file already exists: $outPath"
    exit
}

$doc = Get-Content -Raw -Encoding utf8 $inPath

$m = (New-Object Regex $LineRe, "Multiline").Matches($doc)

$lines = $m | foreach { $_.Groups[0].Value -Replace "\r|\n", " " }
$lines
Build-ClassDef $lines

$out = [ordered]@{
    UsingNamespaces = @()
    Namespace = $Namespace
    Replacements = @{}
    TypeNames = @{}
    Classes = $Classes
}

$result = $out | ConvertTo-Json -Depth 10
$result | Set-Content $outPath