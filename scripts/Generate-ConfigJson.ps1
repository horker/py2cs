param(
    [string]$PythonFile,
    [Switch]$Clobber
)

Set-StrictMode -Version Latest

$ClassRe = "^class (\w+)(?:\((\w+)\))?"
$DefRe = "^(\s{0,4})def (\w+)\(((?:[^:]|\r|\n)*)\):"
$PropertyRe = "^\s{4}@property"
$SetterRe = "^\s{4}@(\w+)\.setter"
$ClassPropertyRe = "^\s{4}@classproperty"
$FieldRe = "^\s*self\.([a-z\d_]+)\s*=\s*(.+)"
$LineRe = "(" + ($ClassRe, $DefRe, $PropertyRe, $SetterRe, $ClassPropertyRe, $FieldRe -join ")|(") + ")"

$Classes = [ordered]@{}

function Get-ClassObject([string]$name, [string]$base)
{
    $class = $Classes[$name]
    if ($null -eq $class) {
        $class = [PSCustomObject]@{
            Name = $name
            Base = $base
            Fields = [ordered]@{}
            Methods = [ordered]@{}
        }
        $Classes[$name] = $class
    }
    $class
}

function ConvertTo-CamelCase([string]$s, [bool]$upper = $true)
{
    $s = $s -replace "^(?:__)?(.+)(?:__)?$", '$1'

    $words = $s -split "(?<=.)_"
    ($words | foreach { $i = 0 } { ++$i; ($upper -or $i -gt 1) -and $_.Length -gt 1 ? [char]::ToUpper($_[0]) + $_.Substring(1) : $_ }) -join ""
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
                $class.Fields[$name] = "private $type $camelCased;"
            }
            else {
                $class.Fields[$name] = "public $type $camelCased { get; set; }"
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
            $visibility = $methodName -match "^_" ? "private" : "public"
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

            $params = @(($params -split "\s*,\s*") | where { -not [string]::IsNullOrWhitespace($_) -and $_ -ne "self" -and ($defType -ne "classProperty" -or $_ -ne "cls") })
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
                $line = "$visibility $static $returnType$camelCased"

            }
            else {
                $line = "$visibility $static $returnType$camelCased($paramString)"

            }
            $paramString

            $m = $class.Methods[$methodName]
            if ($m -eq $null) {
                 $class.Methods[$methodName] = @{}
            }

            $key = $defType -eq "setter" ? "SignatureSetter" : "Signature"
            $class.Methods[$methodName][$key] = $line

            $defType = "function"
        }
    }

    $Classes | foreach {
        $_.PSObject.Properties.Remove("Name")
    }
}

############################################################

$UsingNamespaces = @(
    "using System;",
    "using System.Linq;",
    "using System.Collections;",
    "using System.Collections.Generic;",
    "using System.Threading;",
    "using Horker.MXNet;",
    "using Horker.MXNet.Compat;",
    "using static Horker.MXNet.Compat.Compat;",
    "using static Horker.MXNet.Compat.Coercing;",
    "using static Horker.MXNet.MXNetCoercing;",
    "using static Horker.MXNet.MXNetCompat;",
    "using static Horker.MXNet.DType;"
)

$Namespace = "Horker.MXNet.Gluon"

$Replacements = [ordered]@{
    "ndarray" = "NDArray"
}

############################################################

function Get-OutPath([string]$pythonFile)
{
    $basePath = (Get-Item $PSScriptRoot\..).FullName
    $inPath = (Get-Item $pythonFile).FullName
    $inPath = $inPath.Substring($basePath.Length) -Replace "incubator-mxnet\\python\\"
    $outPath = "src\Horker.MXNet\generated\$inPath.config.json"
    $outPath
}

############################################################

$outPath = Get-OutPath $PythonFile
if (-not $Clobber -and (Test-Path $outPath)) {
    Write-Error "output file already exists: $outPath"
    exit
}

$doc = Get-Content -Raw -Encoding utf8 $PythonFile

$m = (New-Object Regex $LineRe, "Multiline").Matches($doc)

$lines = $m | foreach { $_.Groups[0].Value -Replace "\r|\n", " " }
$lines
Build-ClassDef $lines

$out = [ordered]@{
    UsingNamespaces = $UsingNamespaces
    Namespace = $Namespace
    Replacements = $Replacements
    Classes = $Classes
}

$result = $out | ConvertTo-Json -Depth 10
$result | Set-Content $outPath