using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Horker.MXNet;
using Horker.MXNet.Compat;
using Horker.MXNet.Interop;
using static Horker.MXNet.Compat.Compat;
using static Horker.MXNet.Compat.Coercing;
using static Horker.MXNet.MXNetCompat;
using static Horker.MXNet.MXNetCoercing;
using static Horker.MXNet.DType;

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
    
    public partial class Context : PythonObject, IEquatable<Context>
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
            if (IsTrue(Isinstance(deviceType, typeof(Context)))){
                var local0 = (Context)deviceType;
                this.DeviceTypeid = local0.DeviceTypeid;
                this.DeviceId = local0.DeviceId;
            }
            else
            {
                this.DeviceTypeid = Context.Devstr2type[deviceType];
                this.DeviceId = deviceId;
            }
            this._oldCtx = CoerceIntoContext(null);
        }
        
        public string DeviceType
        {
            get {
                // Expr
                return Context.Devtype2str[this.DeviceTypeid];
            }
        }
        
        // Drop: __hash__
        
        public bool Equals(Context other)
        {
            // Expr
            return (IsTrue(Isinstance(other, typeof(Context))) && IsTrue((this.DeviceTypeid == other.DeviceTypeid)) && IsTrue((this.DeviceId == other.DeviceId)));
        }
        
        private string Str()
        {
            return ("%s(%d)".PyFormat(ValueTuple.Create(this.DeviceType, this.DeviceId)));
        }
        
        private string Repr()
        {
            return this.Str();
        }
        
        private Context Enter()
        {
            if (IsTrue((!IsTrue(Hasattr(Context._defaultCtx, "value"))))){
                Context._defaultCtx.Value = new Context("cpu", 0);
            }
            this._oldCtx = CoerceIntoContext(Context._defaultCtx.Value);
            Context._defaultCtx.Value = this;
            return this;
        }
        
        private void Exit(object ptype, object value, object trace)
        {
            Context._defaultCtx.Value = this._oldCtx;
        }
        
        public static Context DefaultCtx
        {
            get {
                Warnings.Warn("Context.default_ctx has been deprecated. Please use Context.current_context() instead. Please use test_utils.set_default_context to set a default context", typeof(DeprecationWarning));
                if (IsTrue((!IsTrue(Hasattr(Context._defaultCtx, "value"))))){
                    Context._defaultCtx.Value = new Context("cpu", 0);
                }
                return Context._defaultCtx.Value;
            }
            set => SetDefaultCtx(value);
        }
        
        public static void SetDefaultCtx(Context val)
        {
            Warnings.Warn("Context.default_ctx has been deprecated. Please use Context.current_context() instead. Please use test_utils.set_default_context to set a default context", typeof(DeprecationWarning));
            Context._defaultCtx.Value = val;
        }
        
        public void EmptyCache()
        {
            // Expr
            var devType = Ctypes.CInt(this.DeviceTypeid);
            var devId = Ctypes.CInt(this.DeviceId);
            CheckCall(LIB.MXStorageEmptyCache(devType, devId));
        }
    }
    // Assignment of attribute
    
    public static partial class Helper
    {
        public static Context Cpu(int deviceId = 0)
        {
            // Expr
            return new Context("cpu", deviceId);
        }
    }
    
    public static partial class Helper
    {
        public static Context CpuPinned(int deviceId = 0)
        {
            // Expr
            return new Context("cpu_pinned", deviceId);
        }
    }
    
    public static partial class Helper
    {
        public static Context Gpu(int deviceId = 0)
        {
            // Expr
            return new Context("gpu", deviceId);
        }
    }
    
    public static partial class Helper
    {
        public static int NumGpus()
        {
            // Expr
            var count = Ctypes.CInt();
            CheckCall(LIB.MXGetGPUCount(ref count));
            return count.Value;
        }
    }
    
    public static partial class Helper
    {
        public static ValueTuple<long, long> GpuMemoryInfo(int deviceId = 0)
        {
            // Expr
            var free = Ctypes.CUint64();
            var total = Ctypes.CUint64();
            var devId = Ctypes.CInt(deviceId);
            CheckCall(LIB.MXGetGPUMemoryInformation64(devId, ref free, ref total));
            return ValueTuple.Create(free.Value, total.Value);
        }
    }
    
    public static partial class Helper
    {
        public static Context CurrentContext()
        {
            // Expr
            if (IsTrue((!IsTrue(Hasattr(Context._defaultCtx, "value"))))){
                Context._defaultCtx.Value = new Context("cpu", 0);
            }
            return Context._defaultCtx.Value;
        }
    }
}
