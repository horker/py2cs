Set-StrictMode -Version Latest

function Get-Declarations([string]$HeaderFile, [string[]]$Drops) {
    $doc = Get-Content -Raw $HeaderFile

    $re = New-Object Regex "^MXNET_DLL\s*[^;]+;", "Multiline"
    $decls = $re.Matches($doc) | foreach { $_.Groups[0].Value }

    foreach ($d in $decls) {
        $orig = $d

        if ($d -match "(\w+)\(" -and $Drops -contains $matches[1]) {
            @{
                Original = $orig
                Decl = "// (Dropped)"
            }
            continue
        }

        # Return types

        $d = $d -Replace "MXNET_DLL\s+const char(\s*)\*(\s*)", "MXNET_DLL string`$1`$2"

        # keywords

        $d = $d -Replace "\b(out|params|this)\b", "@`$1"

        # Attribute

        $d = $d -Replace "MXNET_DLL\s+", "[DllImport(MXNetDll)]`npublic static extern "

        # Default values

        $d = $d -Replace "DEFAULT\(([^)]+)\)", ""

        # Parameters (string)

        $d = $d -Replace "const char(\s*)\*(\s*)\*(\s*)\*(\s*)", "[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] out string[]`$1`$2`$3`$4"
        $d = $d -Replace "const char(\s*)\*(\s*)\*(\s*)(\w*out\w*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] out string`$1`$2`$3`$4"
        $d = $d -Replace "const char(\s*)\*(\s*)\*(\s*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] string[]`$1`$2`$3"
        $d = $d -Replace "char const(\s*)\*(\s*)\*(\s*)(\w*out\w*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] out string`$1`$2`$3`$4"
        $d = $d -Replace "char const(\s*)\*(\s*)\*(\s*)", "[MarshalAs(UnmanagedType.LPUTF8Str)] string[]`$1`$2`$3"
        $d = $d -Replace "const char\*\s*const\*", "[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] string[]"
        $d = $d -Replace "const char(\s*)\*", "[MarshalAs(UnmanagedType.LPUTF8Str)] string`$1"

        # Parameters (inters)

        $d = $d -Replace "const mx_uint(\s*)\*(\s*)\*(\s*)", "out mx_uint[]`$1`$2`$3"
        $d = $d -Replace "const mx_int(\s*)\*(\s*)\*(\s*)", "out mx_int[]`$1`$2`$3"
        $d = $d -Replace "const int(\s*)\*(\s*)\*(\s*)", "out int[]`$1`$2`$3"
        $d = $d -Replace "const mx_uint(\s*)\*(\s*)", "mx_uint[]`$1`$2"
        $d = $d -Replace "const mx_int(\s*)\*(\s*)", "mx_int[]`$1`$2"
        $d = $d -Replace "const int(\s*)\*(\s*)", "int[]`$1`$2"

        $d = $d -Replace "mx_uint(\s*)\*(\s*)\*(\s*)", "out mx_uint[]`$1`$2`$3"
        $d = $d -Replace "mx_int(\s*)\*(\s*)\*(\s*)", "out mx_int[]`$1`$2`$3"
        $d = $d -Replace "int(\s*)\*(\s*)\*(\s*)", "out int[]`$1`$2`$3"
        $d = $d -Replace "int(\s*)\*(\s*)(dims|shape)", "int[]`$1`$2`$3"
        $d = $d -Replace "dim_t(\s*)\*(\s*)(dims|shape)", "int[]`$1`$2`$3"
        $d = $d -Replace "mx_uint\*", "out mx_uint"
        $d = $d -Replace "mx_int\*", "out mx_int"
        $d = $d -Replace "int\*", "out int"

        # Parameters (void*)

        $d = $d -Replace "const void(\s*)\*(\s*)", "IntPtr`$1`$2"
        $d = $d -Replace "void(\s*)\*(\s*)", "IntPtr`$1`$2"

        # Parameters (generic out)

        $d = $d -Replace "(?!const\s+)(\w+)\s*\*\s*(@?\w+)", "out `$1 `$2"
        $d = $d -Replace "(?!const\s+)(\w+)\s*\*\s*\*\s*(@?\w+)", "out `$1[] `$2"

        # Cleanup

        $d = $d -Replace "const\s*", ""
        $d = $d -Replace "struct\s*", ""

        ######

        @{
            Original = $orig
            Decl = $d
        }
    }
}

$BasePath = "$PSScriptRoot\..\"

function Write-CsFile($Spec)
{
    $inFile = $BasePath + $Spec.InFile
    $outFile = $BasePath + $Spec.OutFile

    $indent = $Spec.Indent
    $drops = $Spec.Drops

    $set = Get-Declarations $inFile $drops

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
        private const string MXNetDll = "libmxnet.dll";
"@
        Epilogue = @"
    }
}
"@
        Drops = @(
            "MXNDArraySave"
            "MXNDArrayLoad"
            "MXNDArrayLoadFromBuffer"
            "MXListFunctions"
            "MXFuncGetInfo"
            "MXSymbolInferShape"
            "MXSymbolInferShapeEx"
            "MXSymbolInferShapePartial"
            "MXSymbolInferShapePartialEx"
            "MXSymbolInferType"
        )
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
        Drops = @(
            "MXGetLastError"
        )

    }
)

############################################################

foreach ($s in $Specs) {
    Write-CsFile $s
}