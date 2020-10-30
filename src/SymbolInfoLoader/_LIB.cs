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
using size_t = System.Int64;
using int64_t = System.Int64;
using uint64_t = System.Int64;
using dim_t = System.Int64;
using mx_uint = System.Int32;
using mx_float = System.Single;

namespace Horker.MXNet.Interop
{
    public static partial class _LIB
    {
        private const string MXNetDll = "libmxnet.dll";

        // MXNET_DLL int MXSymbolListAtomicSymbolCreators(mx_uint *out_size,
        //     AtomicSymbolCreator **out_array);
        [DllImport(MXNetDll)]
        public static extern int MXSymbolListAtomicSymbolCreators(out mx_uint out_size,
             out IntPtr out_array);

        // MXNET_DLL int MXSymbolGetAtomicSymbolInfo(AtomicSymbolCreator creator,
        //     const char **name,
        //     const char **description,
        //     mx_uint *num_args,
        //     const char ***arg_names,
        //     const char ***arg_type_infos,
        //     const char ***arg_descriptions,
        //     const char **key_var_num_args,
        //     const char **return_type DEFAULT(NULL));
        [DllImport(MXNetDll)]
        public static extern int MXSymbolGetAtomicSymbolInfo(AtomicSymbolCreator creator,
            out IntPtr name,
            out IntPtr description,
            out mx_uint num_args,
            out IntPtr arg_names,
            out IntPtr arg_type_infos,
            out IntPtr arg_descriptions,
            out IntPtr key_var_num_args,
            out string return_type);
    }
}
