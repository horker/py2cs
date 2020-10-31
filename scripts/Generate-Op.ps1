Set-StrictMode -Version Latest

. "$PSScriptRoot\common.ps1"

$TabWidth = 4
$BaseIndent = " " * $TabWidth * 2
$Indent0 = $BaseIndent
$Indent1 = $BaseIndent + " " * $TabWidth
$Indent2 = $BaseIndent + " " * $TabWidth * 2
$Indent3 = $BaseIndent + " " * $TabWidth * 3

$TypeMap = @{
    "boolean" = "bool"
    "boolean or None" = "bool"
    "double" = "double"
    "double or None" = "double"
    "float" = "float"
    "float or None" = "float"
    "int" = "int"
    "int (non-negative)" = "int"
    "int or None" = "int"
    "long (non-negative)" = "long"
    "NDArray" = "NDArray"
    "NDArray-or-Symbol" = "NDArrayOrSymbol"
    "NDArray-or-Symbol[]" = "NDArrayOrSymbolList"
    "ptr" = "IntPtr"
    "real_t" = "float"
    "Shape or None" = "Shape"
    "Shape(tuple)" = "Shape"
    "string" = "string"
    "Symbol" = "Symbol"
    "Symbol or Symbol[]" = "SymbolList"
}

$Prologue = @"
using System;
using Horker.MXNet;
using Horker.MXNet.Interop;

namespace {0}
{{
    public partial class {1} : {2}
    {{
        public static class {3}
        {{
"@

$Epilogue = @"
        }
    }
}
"@

$NDArrayPrologue = $Prologue -f "Horker.MXNet", "NDArray", "NDArrayBase", "Op"
$NDArrayInternalPrologue = $Prologue -f "Horker.MXNet", "NDArray", "NDArrayBase", "_internal"
$SymbolPrologue = $Prologue -f "Horker.MXNet", "Symbol", "SymbolBase", "Op"
$SymbolInternalPrologue = $Prologue -f "Horker.MXNet", "Symbol", "SymbolBase", "_internal"

function Parse-Argument($Argument, [bool]$IsNDArray) {

    $name = ConvertTo-CamelCase $Argument.Name $false
    if (("param", "this", "out", "base") -contains $name) {
        $name = "@" + $name
    }

    if ($ARgument.TypeInfo -Match "^\s*{") {
        $type = "string"
    }
    else {
        $ts = $Argument.TypeInfo -split "\s*,\s*"
        $type = $TypeMap[$ts[0]] ?? "object"
        $type = $type -Replace "NDArrayOrSymbol", ($IsNDArray ? "NDArray" : "Symbol")
    }

    $isInput = $type -match "NDArray|Symbol"

    @{
        Name = $name
        Type = $type
        DefaultValue = $null
        Kind = $isInput ? "input" : "param"
    }
}

function Get-ArgumentString($a) {
    ($a | foreach {
        $s = $_.Type + " " + $_.Name
        if ($_.DefaultValue) {
            $s += " = " + $_.Defaultvalue
        }
        $s
    }) -join ", "
}

function Get-MethodString($MethodInfo, [bool]$IsNDArray) {
    foreach ($method in $MethodInfo) {
        $name = $method.Name
        $methodName = ConvertTo-CamelCase $method.Name $true

        $returnType = $IsNDArray ? "NDArrayList" : "SymbolList"

        $args = @($method.Arguments | foreach {
            Parse-Argument $_ $IsNDArray
        })

        if ($IsNDArray) {
            if (($args | foreach { $_.Name }) -NotContains "@out") {
                $args += ,@{
                    Name = "@out"
                    Type = "NDArrayList"
                    DefaultValue = "null"
                    Kind = "out"
                }
            }
        }
        else {
            $args += ,@{
                Name = "symbol_name"
                Type = "string"
                DefaultValue = "null"
                Kind = "param"
            }
        }

        $argsString = Get-ArgumentString $args

        "$($Indent0)public static $returnType $methodName($argsString)"
        "$($Indent0){"
        "$($Indent1)return new Operator(`"$name`")"

        foreach ($a in $args) {
            if ($a.Kind -eq "input") {
                "$($Indent2).SetInput($($a.Name))"
            }
            elseif ($a.Kind -eq "param") {
                "$($Indent2).SetParam(`"$($a.Name)`", $($a.Name))"
            }
        }

        if ($IsNDArray) {
            "$($Indent2).Invoke(@out);"
        }
        else {
            "$($Indent2).CreateSymbol(symbol_name);"
        }
        "$($Indent0)}"
    }
}

function Get-ClassString($MethodInfos, [bool]$IsNDArray, [string]$Prologue, [string]$Epilogue) {
    $Prologue

    foreach ($mi in $MethodInfos) {
        Get-MethodString $mi $IsNDArray
        ""
    }

    $Epilogue
}

############################################################

$OutPath = "$PSScriptRoot\..\src\Horker.MXNet\generated\mxnet\"
$infos = Get-Content "$PSScriptRoot\..\src\\symbol_infos.json" | ConvertFrom-Json

$publicInfos = $infos | where { $_.Name -notmatch "^_" }
$internalInfos = $infos | where { $_.Name -match "^_" }

Get-ClassString $publicInfos $true $NDArrayPrologue $Epilogue > ($OutPath + "ndarray\NDArrayOp_gen.cs")
Get-ClassString $publicInfos $false $SymbolPrologue $Epilogue > ($OutPath + "symbol\SymbolOp_gen.cs")
Get-ClassString $internalInfos $true $NDArrayInternalPrologue $Epilogue > ($OutPath + "ndarray\NDArrayInternal_gen.cs")
Get-ClassString $internalInfos $false $SymbolInternalPrologue $Epilogue > ($OutPath + "symbol\SymbolInternal_gen.cs")
