Set-StrictMode -Version Latest

function Get-Declarations([string]$HeaderFile, [Hashtable]$Methods) {
    $doc = Get-Content -Raw $HeaderFile

    $re = New-Object Regex "^MXNET_DLL\s*[^;]+;", "Multiline"
    $decls = $re.Matches($doc) | foreach { $_.Groups[0].Value }

    foreach ($d in $decls) {
        $orig = $d

        $funcName = ""

        $params = @()
        if ($d -match "(\w+)\(((?:.|\r|\n)*)\);") {
            write-host $matches[1]
            write-host $matches[2]
            $funcName = $matches[1]
            if ([string]::IsNullOrEmpty($matches[2])) {
                $params = @()
            }
            else {
                $params = $matches[2] -split "[\r\n\s]*,[\r\n\s]*"
            }
        }

        $def = $Methods[$funcName]
        if ($def -and $def["Drop"]) {
            @{
                Original = $orig
                Decl = "// (Dropped)"
            }
            continue
        }

        $outParams = $def -and $def["Params"] ?? @{}

        $paramMap = [ordered]@{}

        foreach ($p in $params) {
            $m = ([regex]"^(.+\s+\**)(\w+)(?:\s+DEFAULT\([^)]+\))?$").Match($p)
            $type = $m.Groups[1].Value.Trim()
            $name = $m.Groups[2].Value.Trim()
            $isOut = $outParams -contains $name -or $name -match "out"

            $csType = $type -Replace "\s*const\s*", ""
            $csType = $csType -Replace "void\s*\*", "IntPtr"
            $CsType = $csType -Replace "\s*struct\s*", ""

            if ($isOut) {
                $csType = $csType -Replace "\s*\*$", ""
            }
            else {
                $csType = $csType -Replace "\s*\*$", "[]"
            }

            $csType = $csType -Replace "^char\s*\*", "string"
            $csType = $csType -Replace "^char\s*\*", "string"
            $csType = $csType -Replace "(\w+)\s*\*", "`$1[]"
            $csType = $csType -Replace "mx_uint", "int"
            $csType = $csType -Replace "mx_int", "int"
            $csType = $csType -Replace "uint", "int"

            if (("this", "base", "out") -Contains $name) {
                $name = "@" + $name
            }
            $paramMap[$name] = [PSCustomObject]@{
                Type = $type
                CsType = $csType
                IsOut = $isOut
            }
        }

        $paramMap | out-host
        $decl = "[DllImport(MXNetDll)]`n"
        $decl += "public static extern int $funcName(`n"
        $i = 0
        $count = $paramMap.Count
        foreach ($entry in $paramMap.GetEnumerator()) {
            $name = $entry.Key
            $p = $entry.Value
            $comma = ++$i -eq $count ? "" : ","
            if ($p.IsOut) {
                $decl += "    out $($p.CsType) $name$comma`n"
            }
            else {
                $decl += "    $($p.CsType) $name$comma`n"
            }
        }
        $decl += ");"

#        # Return types
#
#        $d = $d -Replace "MXNET_DLL\s+const char(\s*)\*(\s*)", "MXNET_DLL string`$1`$2"
#
#        # keywords
#
#        $d = $d -Replace "\b(out|params|this)\b", "@`$1"
#
#        # Attribute
#
#        $d = $d -Replace "MXNET_DLL\s+", "[DllImport(MXNetDll)]`npublic static extern "
#
#        # Default values
#
#        $d = $d -Replace "DEFAULT\(([^)]+)\)", ""
#
#        # Parameters (string)
#
#        $d = $d -Replace "const char(\s*)\*(\s*)\*(\s*)\*(\s*)", "[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] out string[]`$1`$2`$3`$4"
#        $d = $d -Replace "const char(\s*)\*(\s*)\*(\s*)(\w*out\w*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] out string`$1`$2`$3`$4"
#        $d = $d -Replace "const char(\s*)\*(\s*)\*(\s*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] string[]`$1`$2`$3"
#        $d = $d -Replace "char const(\s*)\*(\s*)\*(\s*)(\w*out\w*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] out string`$1`$2`$3`$4"
#        $d = $d -Replace "char const(\s*)\*(\s*)\*(\s*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] string[]`$1`$2`$3"
#        $d = $d -Replace "const char\*\s*const\*", "[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] string[]"
#        $d = $d -Replace "const char(\s*)\*", "[MarshalAs(UnmanagedType.LPUTF8Str)] string`$1"
#
#        # Parameters (inters)
#
#        $d = $d -Replace "const mx_uint(\s*)\*(\s*)\*(\s*)", "out mx_uint[]`$1`$2`$3"
#        $d = $d -Replace "const mx_int(\s*)\*(\s*)\*(\s*)", "out mx_int[]`$1`$2`$3"
#        $d = $d -Replace "const int(\s*)\*(\s*)\*(\s*)", "out int[]`$1`$2`$3"
#        $d = $d -Replace "const mx_uint(\s*)\*(\s*)", "mx_uint[]`$1`$2"
#        $d = $d -Replace "const mx_int(\s*)\*(\s*)", "mx_int[]`$1`$2"
#        $d = $d -Replace "const int(\s*)\*(\s*)", "int[]`$1`$2"
#
#        $d = $d -Replace "mx_uint(\s*)\*(\s*)\*(\s*)", "out mx_uint[]`$1`$2`$3"
#        $d = $d -Replace "mx_int(\s*)\*(\s*)\*(\s*)", "out mx_int[]`$1`$2`$3"
#        $d = $d -Replace "int(\s*)\*(\s*)\*(\s*)", "out int[]`$1`$2`$3"
#        $d = $d -Replace "int(\s*)\*(\s*)(dims|shape)", "int[]`$1`$2`$3"
#        $d = $d -Replace "dim_t(\s*)\*(\s*)(dims|shape)", "int[]`$1`$2`$3"
#        $d = $d -Replace "mx_uint\*", "out mx_uint"
#        $d = $d -Replace "mx_int\*", "out mx_int"
#        $d = $d -Replace "int\*", "out int"
#
#        # Parameters (void*)
#
#        $d = $d -Replace "const void(\s*)\*(\s*)", "IntPtr`$1`$2"
#        $d = $d -Replace "void(\s*)\*(\s*)", "IntPtr`$1`$2"
#
#        # Parameters (generic out)
#
#        $d = $d -Replace "(?!const\s+)(\w+)\s*\*\s*(@?\w+)", "out `$1 `$2"
#        $d = $d -Replace "(?!const\s+)(\w+)\s*\*\s*\*\s*(@?\w+)", "out `$1[] `$2"
#
#        # Cleanup
#
#        $d = $d -Replace "const\s*", ""
#        $d = $d -Replace "struct\s*", ""
#
        ######

        @{
            Original = $orig
            Decl = $decl
        }
    }
}

$BasePath = "$PSScriptRoot\..\"

function Write-CsFile($Spec)
{
    $inFile = $BasePath + $Spec.InFile
    $outFile = $BasePath + $Spec.OutFile

    $indent = $Spec.Indent
    $methods = $Spec.Methods

    $set = Get-Declarations $inFile $methods

    $Spec.Prologue > $outFile

    foreach ($s in $set) {
        "" >> $outFile
        $orig = $s.Original -split "[\r\n]+" | foreach { "// " + ($_ -Replace "^\s+", "    ") }
        $decl = $s.Decl -split "[\r\n]+" | foreach { $_ -Replace "^\s+", "    " }
        @($orig) + @($decl) | foreach { (" " * $indent) + $_ } >> $outFile
    }

    $Spec.Epilogue >> $outFile
}

############################################################

$CommonHeader = @"
using System;
using System.Runtime.InteropServices;
using AtomicSymbolCreator = System.IntPtr;
using DataIterCreator = System.IntPtr;
using DataIterHandle = System.IntPtr;
using ExecutorHandle = System.IntPtr;
using ExecutorMonitorCallback = System.IntPtr;
using KVStoreHandle = System.IntPtr;
using NDArrayHandle = System.IntPtr;
using ProfileHandle = System.IntPtr;
using SymbolHandle = System.IntPtr;
using CudaModuleHandle = System.IntPtr;
using CudaKernelHandle = System.IntPtr;
using DLManagedTensorHandle = System.IntPtr;
using FunctionHandle = System.IntPtr;
using LibFeature = System.IntPtr;
using CachedOpHandle = System.IntPtr;
using MXKVStoreUpdater = System.IntPtr;
using MXKVStoreStrUpdater = System.IntPtr;
using MXKVStoreServerController = System.IntPtr;
using RecordIOHandle = System.IntPtr;
using RtcHandle = System.IntPtr;
using CustomOpPropCreator = System.IntPtr;
using EngineSyncFunc = System.IntPtr;
using EngineAsyncFunc = System.IntPtr;
using EngineVarHandle = System.IntPtr;
using EngineFuncParamDeleter = System.IntPtr;
using ContextHandle = System.IntPtr;
using EngineFnPropertyHandle = System.IntPtr;
using MXCallbackList = System.IntPtr;
using PredictorHandle = System.IntPtr;
using NDListHandle = System.IntPtr;
using size_t = System.Int64;
using int64_t = System.Int64;
using uint64_t = System.Int64;
using dim_t = System.Int64;
using mx_uint = System.Int32;
using mx_float = System.Single;
"@

$Specs = @(
    @{
        InFile = "incubator-mxnet\include\mxnet\c_api.h"
        OutFile = "src\Horker.MXNet\generated\CApi_gen.cs"
        Indent = 8
        Prologue = @"
// Automatically generated by scripts\Generate-CBinding.ps1
// DO NOT EDIT
// Source: include/mxnet/c_api.h

$CommonHeader

namespace Horker.MXNet.Interop
{
    public static partial class _LIB
    {
"@
        Epilogue = @"
    }
}
"@
        Methods = @{
            "MXNDArraySave" = @{ Drop = $true }
            "MXNDArrayLoad" = @{ Drop = $true }
            "MXNDArrayLoadFromBuffer" = @{ Drop = $true }
            "MXListFunctions" = @{ Drop = $true }
            "MXFuncGetInfo" = @{ Drop = $true }
            "MXSymbolInferShape" = @{ Drop = $true }
            "MXSymbolInferShapeEx" = @{ Drop = $true }
            "MXSymbolInferShapePartial" = @{ Drop = $true }
            "MXSymbolInferShapePartialEx" = @{ Drop = $true }
            "MXSymbolInferType" = @{ Drop = $true }
        }
    }
    @{
        InFile = "incubator-mxnet\include\mxnet\c_predict_api.h"
        OutFile = "src\Horker.MXNet\generated\CPredictApi_gen.cs"
        Indent = 8
        Prologue = @"
// Automatically generated by scripts\Generate-CBinding.ps1
// DO NOT EDIT
// Source: include/mxnet/c_predict_api.h

$CommonHeader

namespace Horker.MXNet.Interop
{
    public static partial class _LIB
    {
"@
        Epilogue = @"
    }
}
"@
        Methods = @{
            "MXGetLastError" = @{ Drop = $true }
        }
    }
)

############################################################

foreach ($s in $Specs) {
    Write-CsFile $s
}