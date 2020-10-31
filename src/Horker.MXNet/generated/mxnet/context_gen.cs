using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Horker.MXNet;
using Horker.MXNet.Compat;
using static Horker.MXNet.Base;
using static Horker.MXNet.Compat.Compat;
using static Horker.MXNet.Compat.Coercing;
using static Horker.MXNet.Compat.Array;
using static Horker.MXNet.MXNetCoercing;
using static Horker.MXNet.MXNetCompat;
using static Horker.MXNet.DType;
using NDArrayHandle = System.IntPtr;
using SymbolHandle = System.IntPtr;
using DisposableObject = Horker.MXNet.Interop.DisposableObject;
using _LIB = Horker.MXNet.Interop._LIB;
using MxInt = System.Int32;
using MxUint = System.Int32;
using MxInt64 = System.Int64;
using PySlice = Horker.MXNet.Compat.Slice;
using Tuple = System.Collections.ICollection;
using List = System.Collections.ICollection;
using _numpy = Horker.MXNet.Np;

namespace Horker.MXNet
{
    using Int = System.Int32;
    using List = System.Array;
    using static Helper;
    public static partial class Helper {}
    
    // Expr
    // ImportFrom
    // Import
    // Import
    // Import
    // ImportFrom
    // ImportFrom
    // ImportFrom
    
    public partial class Context : IEquatable<Context>
    {
        public int DeviceTypeid { get; set; }
        public int DeviceId { get; set; }
        private Context _oldCtx;
        
        // Expr
        public static ThreadLocal<Context> _defaultCtx = CoerceIntoThreadLocal<Context>(Threading.Local());
        public static Dictionary<int, string> Devtype2str = CoerceIntoDictionary<int, string>(new Dictionary<int, string>{
            { 1, "cpu" },
            { 2, "gpu" },
            { 3, "cpu_pinned" },
            { 5, "cpu_shared" },
        }
        );
        public static Dictionary<string, int> Devstr2type = CoerceIntoDictionary<string, int>(new Dictionary<string, int>{
            { "cpu", 1 },
            { "gpu", 2 },
            { "cpu_pinned", 3 },
            { "cpu_shared", 5 },
        }
        );
        
        public Context(string deviceType, int deviceId = 0)
        {
            this.DeviceTypeid = Context.Devstr2type[deviceType];
            this.DeviceId = deviceId;
            this._oldCtx = CoerceIntoContext(null);
        }
        
        public object DeviceType
        {
            get {
                // Expr
                return Context.Devtype2str[this.DeviceTypeid];
            }
        }
        
        // Drop: __hash__
        
        // Drop: __eq__
        
        internal string __Str__()
        {
            return ("%s(%d)".PyFormat(ValueTuple.Create(this.DeviceType, this.DeviceId)));
        }
        
        internal object __Repr__()
        {
            return this.__Str__();
        }
        
        internal Context __Enter__()
        {
            if (IsTrue((!IsTrue(Hasattr(Context._defaultCtx, "value")))))
            {
                Context._defaultCtx.Value = new Context("cpu", 0);
            }
            this._oldCtx = CoerceIntoContext(Context._defaultCtx.Value);
            Context._defaultCtx.Value = this;
            return this;
        }
        
        internal void __Exit__(object ptype, object value, object trace)
        {
            Context._defaultCtx.Value = this._oldCtx;
        }
        
        public static Context DefaultCtx
        {
            get {
                Warnings.Warn("Context.default_ctx has been deprecated. Please use Context.current_context() instead. Please use test_utils.set_default_context to set a default context", typeof(DeprecationWarning));
                if (IsTrue((!IsTrue(Hasattr(Context._defaultCtx, "value")))))
                {
                    Cls._defaultCtx.Value = new Context("cpu", 0);
                }
                return Cls._defaultCtx.Value;
            }
            set => SetDefaultCtx(value);
        }
        
        public static void SetDefaultCtx(Context val)
        {
            Warnings.Warn("Context.default_ctx has been deprecated. Please use Context.current_context() instead. Please use test_utils.set_default_context to set a default context", typeof(DeprecationWarning));
            Cls._defaultCtx.Value = val;
        }
        
        public void EmptyCache()
        {
            // Expr
            var devType = CTypes.CInt(this.DeviceTypeid);
            var devId = CTypes.CInt(this.DeviceId);
            CheckCall(_LIB.MXStorageEmptyCache(devType, devId));
        }
    }
    
    // Assignment of attribute
    
    public static partial class Helper
    {
        public static object Cpu(int deviceId = 0)
        {
            // Expr
            return new Context("cpu", deviceId);
        }
    }
    
    public static partial class Helper
    {
        public static object CpuPinned(int deviceId = 0)
        {
            // Expr
            return new Context("cpu_pinned", deviceId);
        }
    }
    
    public static partial class Helper
    {
        public static object Gpu(int deviceId = 0)
        {
            // Expr
            return new Context("gpu", deviceId);
        }
    }
    
    public static partial class Helper
    {
        public static object NumGpus()
        {
            // Expr
            var count = CTypes.CInt();
            CheckCall(_LIB.MXGetGPUCount(out count));
            return count;
        }
    }
    
    public static partial class Helper
    {
        public static ValueTuple<long, long> GpuMemoryInfo(int deviceId = 0)
        {
            // Expr
            var free = CTypes.CUint64();
            var total = CTypes.CUint64();
            var devId = CTypes.CInt(deviceId);
            CheckCall(_LIB.MXGetGPUMemoryInformation64(devId, out free, out total));
            return ValueTuple.Create(free, total);
        }
    }
    
    public static partial class Helper
    {
        public static Context CurrentContext()
        {
            // Expr
            if (IsTrue((!IsTrue(Hasattr(Context._defaultCtx, "value")))))
            {
                Context._defaultCtx.Value = new Context("cpu", 0);
            }
            return Context._defaultCtx.Value;
        }
    }
}
