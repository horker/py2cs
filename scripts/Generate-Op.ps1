using namespace System.Collections
using namespace System.Collections.Generic

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

function Get-DefaultValueLiteral([string]$Type, [string]$Value) {
    $v = $Value.Trim("'")
    if ($Type -match "string") {
        $v = "`"" + $v + "`""
    }
    elseif ($Type -match "bool") {
        $v = $v -eq "0" ? "false" : "true"
    }
    elseif ($Type -match "(float|double)") {
        $t = $matches[1]
        if ($v -eq "null") {
            $v = "$t.NaN"
        }
        if ($v -match "[\d.]+" -and $t -eq "float") {
            $v = $v + "f"
        }
    }
    elseif ($Type -match "Shape") {
        if ($v -eq "[]" -or $v -eq "None") {
            $v = "new Shape()"
        }
        else {
            $v = "new [] {" + ($v -Replace "[\[\]]", "") + "}"
        }
    }

    $v
}

function Parse-Argument($Argument, [bool]$IsNDArray) {

    $name = ConvertTo-CamelCase $Argument.Name $false
    if (("param", "this", "out", "base") -contains $name) {
        $name = "@" + $name
    }

    $default = $null
    if ($Argument.TypeInfo -Match ",\s*default\s*=(.+)") {
        $default = $Matches[1]
        if ($default -eq "None") {
            $default = "null"
        }
    }

    if ($Argument.TypeInfo -Match "^\s*{") {
        $type = "string"
    }
    else {
        $ts = $Argument.TypeInfo -split "\s*,\s*"

        if ($TypeMap.Contains($ts[0])) {
            $type = $TypeMap[$ts[0]]
            $type = $type -Replace "NDArrayOrSymbol", ($IsNDArray ? "NDArray" : "Symbol")
        }
        else {
            if ($default -Match "^\[") {
                $type = "float[]"
            }
            else {
                $type = "object"
            }
        }
    }

    $isInput = $type -match "NDArray|Symbol"

    @{
        Name = $name
        OriginalName = $Argument.Name
        Type = $type
        DefaultValue = $default
        Kind = $isInput ? "input" : "param"
    }
}

function Parse-Arguments($arguments, [bool]$IsNDArray) {
    $args = @($arguments | foreach {
        Parse-Argument $_ $IsNDArray
    })

    $hasDefault = $false
    for ($i = 0; $i -lt $args.Length; ++$i) {
        if ($args[$i].DefaultValue) {
            $hasDefault = $true
        }
        else {
            if ($hasDefault) {
                $args[$i].DefaultValue = "null"
            }
        }
    }

    ,$args
}

function Get-ArgumentString($a, [List[Hashtable]]$queue) {
    ($a | foreach {
        $s = $_.Type + " " + $_.Name
        if ($_.DefaultValue) {
            $d = Get-DefaultValueLiteral $_.Type $_.DefaultValue
            if ($_.Type -Match "string") {
                $s += " = " + $d
            }
            elseif ($_.Type -Match "bool") {
                if ($_.DefaultValue -eq "null") {
                    $s = "bool? " + $_.Name + " = null"
                }
                else {
                    $s += " = " + $d
                }
            }
            elseif ($s -match "int|long|float|double") {
                $s = $_.Type + "? " + $_.Name + " = null"
            }
            else {
                $s += " = null"
                if ($_.DefaultValue -ne "null") {
                    $queue.Add(@{ Name = $_.Name; Value = $d })
                }
            }
        }
        $s
    }) -join ", "
}

function Get-MethodString($MethodInfo, [bool]$IsNDArray) {
    foreach ($method in $MethodInfo) {
        $name = $method.Name
        $methodName = ConvertTo-CamelCase $method.Name $true

        $returnType = $IsNDArray ? "NDArrayList" : "SymbolList"

        $args = Parse-Arguments $method.Arguments $IsNDArray

        if ($IsNDArray) {
            if (($args | foreach { $_.Name }) -NotContains "@out") {
                $args += ,@{
                    Name = "@out"
                    OriginalName = "out"
                    Type = "NDArrayList"
                    DefaultValue = "null"
                    Kind = "out"
                }
            }
        }
        else {
            $args += ,@{
                Name = "symbolName"
                OriginalName = "symbol_name"
                Type = "string"
                DefaultValue = "null"
                Kind = "param"
            }
        }

        $defaultValueQuque = New-Object List[Hashtable]
        $argsString = Get-ArgumentString $args $defaultValueQuque

        "$($Indent0)public static $returnType $methodName($argsString)"
        "$($Indent0){"

        foreach ($d in $defaultValueQuque) {
            "$($Indent1)$($d.Name) = $($d.Value);"
        }

        "$($Indent1)return new Operator(`"$name`")"

        foreach ($a in $args) {
            if ($a.Kind -eq "input") {
                "$($Indent2).SetInput($($a.Name))"
            }
            elseif ($a.Kind -eq "param") {
                "$($Indent2).SetParam(`"$($a.OriginalName)`", $($a.Name))"
            }
        }

        if ($IsNDArray) {
            "$($Indent2).Invoke(@out);"
        }
        else {
            "$($Indent2).CreateSymbol(symbolName);"
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
