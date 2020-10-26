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

        // MXNET_DLL int MXNDArraySave(const char* fname,
        //     mx_uint num_args,
        //     NDArrayHandle* args,
        //     const char** keys);
        [DllImport(MXNetDll)]
        public static extern int MXNDArraySave([MarshalAs(UnmanagedType.LPUTF8Str)] string fname,
            mx_uint num_args,
            NDArrayHandle[] args,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string[] keys);

        // MXNET_DLL int MXNDArrayLoad(const char* fname,
        //     mx_uint *out_size,
        //     NDArrayHandle** out_arr,
        //     mx_uint *out_name_size,
        //     const char*** out_names);
        [DllImport(MXNetDll)]
        public static extern int MXNDArrayLoad([MarshalAs(UnmanagedType.LPUTF8Str)] string fname,
            out mx_uint out_size,
            out NDArrayHandle[] out_arr,
            out mx_uint out_name_size,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] out string[] out_names);

        // MXNET_DLL int MXNDArrayLoadFromBuffer(const void *ndarray_buffer,
        //     size_t size,
        //     mx_uint *out_size,
        //     NDArrayHandle** out_arr,
        //     mx_uint *out_name_size,
        //     const char*** out_names);
        [DllImport(MXNetDll)]
        public static extern int MXNDArrayLoadFromBuffer(IntPtr ndarray_buffer,
            size_t size,
            out mx_uint out_size,
            out NDArrayHandle[] out_arr,
            out mx_uint out_name_size,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] out string[] out_names);

        // MXNET_DLL int MXListFunctions(mx_uint *out_size,
        //     FunctionHandle **out_array);
        [DllImport(MXNetDll)]
        public static extern int MXListFunctions(out mx_uint out_size,
            out FunctionHandle[] out_array);

        // MXNET_DLL int MXFuncGetInfo(FunctionHandle fun,
        //     const char **name,
        //     const char **description,
        //     mx_uint *num_args,
        //     const char ***arg_names,
        //     const char ***arg_type_infos,
        //     const char ***arg_descriptions,
        //     const char **return_type DEFAULT(NULL));
        [DllImport(MXNetDll)]
        public static extern int MXFuncGetInfo(FunctionHandle fun,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string[] name,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string[] description,
            out mx_uint num_args,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] out string[] arg_names,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] out string[] arg_type_infos,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] out string[] arg_descriptions,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string[] return_type );

        // MXNET_DLL int MXSymbolInferShape(SymbolHandle sym,
        //     mx_uint num_args,
        //     const char** keys,
        //     const mx_uint *arg_ind_ptr,
        //     const mx_uint *arg_shape_data,
        //     mx_uint *in_shape_size,
        //     const mx_uint **in_shape_ndim,
        //     const mx_uint ***in_shape_data,
        //     mx_uint *out_shape_size,
        //     const mx_uint **out_shape_ndim,
        //     const mx_uint ***out_shape_data,
        //     mx_uint *aux_shape_size,
        //     const mx_uint **aux_shape_ndim,
        //     const mx_uint ***aux_shape_data,
        //     int *complete);
        [DllImport(MXNetDll)]
        public static extern unsafe int MXSymbolInferShape(SymbolHandle sym,
            uint num_args,
            [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)]
            string[] keys,
            int[] arg_ind_ptr,
            int[] arg_shape_data,
            int* in_shape_size,
            int** in_shape_ndim,
            int*** in_shape_data,
            out int out_shape_size,
            out int* out_shape_ndim,
            out int** out_shape_data,
            out int aux_shape_size,
            out int* aux_shape_ndim,
            out int** aux_shape_data,
            out int complete);

        // MXNET_DLL int MXSymbolInferShapeEx(SymbolHandle sym,
        //     mx_uint num_args,
        //     const char** keys,
        //     const mx_uint *arg_ind_ptr,
        //     const int *arg_shape_data,
        //     mx_uint *in_shape_size,
        //     const int **in_shape_ndim,
        //     const int ***in_shape_data,
        //     mx_uint *out_shape_size,
        //     const int **out_shape_ndim,
        //     const int ***out_shape_data,
        //     mx_uint *aux_shape_size,
        //     const int **aux_shape_ndim,
        //     const int ***aux_shape_data,
        //     int *complete);
        [DllImport(MXNetDll)]
        public static extern unsafe int MXSymbolInferShapeEx(SymbolHandle sym,
            uint num_args,
            [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)]
            string[] keys,
            int[] arg_ind_ptr,
            int[] arg_shape_data,
            int* in_shape_size,
            int** in_shape_ndim,
            int*** in_shape_data,
            out int out_shape_size,
            out int* out_shape_ndim,
            out int** out_shape_data,
            out int aux_shape_size,
            out int* aux_shape_ndim,
            out int** aux_shape_data,
            out int complete);

        // MXNET_DLL int MXSymbolInferShapePartial(SymbolHandle sym,
        //     mx_uint num_args,
        //     const char** keys,
        //     const mx_uint *arg_ind_ptr,
        //     const mx_uint *arg_shape_data,
        //     mx_uint *in_shape_size,
        //     const mx_uint **in_shape_ndim,
        //     const mx_uint ***in_shape_data,
        //     mx_uint *out_shape_size,
        //     const mx_uint **out_shape_ndim,
        //     const mx_uint ***out_shape_data,
        //     mx_uint *aux_shape_size,
        //     const mx_uint **aux_shape_ndim,
        //     const mx_uint ***aux_shape_data,
        //     int *complete);
        [DllImport(MXNetDll)]
        public static extern unsafe int MXSymbolInferShapePartial(SymbolHandle sym,
            int num_args,
            [MarshalAs(UnmanagedType.LPUTF8Str)] out string keys,
            int[] arg_ind_ptr,
            int[] arg_shape_data,
            out int in_shape_size,
            out int* in_shape_ndim,
            out int** in_shape_data,
            out int out_shape_size,
            out int* out_shape_ndim,
            out int** out_shape_data,
            out int aux_shape_size,
            out int* aux_shape_ndim,
            out int** aux_shape_data,
            out int complete);

        // MXNET_DLL int MXSymbolInferShapePartialEx(SymbolHandle sym,
        //     mx_uint num_args,
        //     const char** keys,
        //     const mx_uint *arg_ind_ptr,
        //     const int *arg_shape_data,
        //     mx_uint *in_shape_size,
        //     const int **in_shape_ndim,
        //     const int ***in_shape_data,
        //     mx_uint *out_shape_size,
        //     const int **out_shape_ndim,
        //     const int ***out_shape_data,
        //     mx_uint *aux_shape_size,
        //     const int **aux_shape_ndim,
        //     const int ***aux_shape_data,
        //     int *complete);
        [DllImport(MXNetDll)]
        public static extern unsafe int MXSymbolInferShapePartialEx(SymbolHandle sym,
            int num_args,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] string[] keys,
            int[] arg_ind_ptr,
            int[] arg_shape_data,
            int in_shape_size,
            int[] in_shape_ndim,
            int** in_shape_data,
            out int out_shape_size,
            out int* out_shape_ndim,
            out int** out_shape_data,
            out int aux_shape_size,
            out int* aux_shape_ndim,
            out int** aux_shape_data,
            out int complete);

        // MXNET_DLL int MXSymbolInferType(SymbolHandle sym,
        //     mx_uint num_args,
        //     const char** keys,
        //     const int *arg_type_data,
        //     mx_uint *in_type_size,
        //     const int **in_type_data,
        //     mx_uint *out_type_size,
        //     const int **out_type_data,
        //     mx_uint *aux_type_size,
        //     const int **aux_type_data,
        //     int *complete);
        [DllImport(MXNetDll)]
        public static extern unsafe int MXSymbolInferType(SymbolHandle sym,
            mx_uint num_args,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string[] keys,
            int[] arg_type_data,
            int[] in_type_size,
            int** in_type_data,
            out int[] out_type_size,
            out int[] out_type_data,
            out mx_uint aux_type_size,
            out int[] aux_type_data,
            out int complete);
    }
}
