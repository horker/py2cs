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
using _LIB = Horker.MXNet.Interop._LIB;
using MxInt = System.Int32;
using MxUint = System.Int32;
using MxInt64 = System.Int64;
using PySlice = Horker.MXNet.Compat.Slice;
using Tuple = System.Collections.ICollection;
using List = System.Collections.ICollection;
using _numpy = Horker.MXNet.Np;
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
using _LIB = Horker.MXNet.Interop._LIB;
using NDArrayHandle = System.IntPtr;
using SymbolHandle = System.IntPtr;
using MxInt = System.Int32;
using MxUint = System.Int32;
using MxInt64 = System.Int64;
using PySlice = Horker.MXNet.Compat.Slice;
using Tuple = System.Collections.ICollection;
using List = System.Collections.ICollection;

namespace Horker.MXNet
{
    using Int = System.Int32;
    using List = System.Array;
    using static Helper;
    public static partial class Helper {}
    
    // Expr
    // ImportFrom
    // Import
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    
    public static partial class Helper
    {
        public static object _symbolCls = CoerceIntoObject(null);
    }
    
    public partial class SymbolBase : DisposableObject
    {
        public SymbolHandle Handle { get; private set; }
        
        // Expr
        public static object __Slots__ = CoerceIntoObject(new [] { "handle" });
        
        public SymbolBase(SymbolHandle handle)
        {
            // Expr
            this.Handle = handle;
        }
        
        protected override void DisposeUnmanaged()
        {
            CheckCall(_LIB.NNSymbolFree(this.Handle));
        }
        
        internal void _compose(SymbolList args, string name = null)
        {
            string[] keys = null;
            var kwargs = new Dictionary<string, IntPtr>();
            // Expr
            name = name;
            if (IsTrue(name))
            {
                name = CStr(name);
            }
            if (IsTrue((IsTrue((Len(args) != 0)) && IsTrue((Len(kwargs) != 0)))))
            {
                throw new TypeError("compose only accept input Symbols                 either as positional or keyword arguments, not both");
            }
            foreach (var arg in args)
            {
                if (IsTrue((!IsTrue(Isinstance(arg, typeof(SymbolBase))))))
                {
                    throw new TypeError("Compose expect `Symbol` as arguments");
                }
            }
            foreach (var val in kwargs.Values())
            {
                if (IsTrue((!IsTrue(Isinstance(val, typeof(SymbolBase))))))
                {
                    throw new TypeError("Compose expect `Symbol` as arguments");
                }
            }
            var numArgs = (Len(args) + Len(kwargs));
            if (IsTrue((Len(kwargs) != 0)))
            {
                keys = CoerceIntoStringArray(CStrArray(kwargs.Keys()));
                args = CHandleArray(kwargs.Values());
            }
            else
            {
                keys = CoerceIntoStringArray(null);
                args = CHandleArray(kwargs.Values());
            }
            CheckCall(_LIB.NNSymbolCompose(this.Handle, name, numArgs, keys, args));
        }
        
        internal void _setAttr(IDictionary<string, string> kwargs)
        {
            // Expr
            var keys = CStrArray(kwargs.Keys());
            var vals = CStrArray(kwargs.Values().Select(s => Str(s)).ToList());
            var numArgs = MxUint(Len(kwargs));
            CheckCall(_LIB.MXSymbolSetAttrs(this.Handle, numArgs, keys, vals));
        }
        
        internal void _setHandle(SymbolHandle handle)
        {
            // Expr
            this.Handle = handle;
        }
        
        // Drop: __reduce__
    }
    
    // Drop: _set_symbol_class
    
    // Drop: _symbol_creator
}
