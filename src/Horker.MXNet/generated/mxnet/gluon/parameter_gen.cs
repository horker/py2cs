using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Horker.MXNet;
using Horker.MXNet.Compat;
using static Horker.MXNet.Compat.Compat;
using static Horker.MXNet.Compat.Coercing;
using static Horker.MXNet.MXNetCoercing;
using static Horker.MXNet.MXNetCompat;
using static Horker.MXNet.DType;

namespace Horker.MXNet.Gluon
{
    using Int = System.Int32;
    using List = System.Array;
    using static Helper;
    public static partial class Helper {}
    
    // Expr
    // Assignment of __all__
    // ImportFrom
    // Import
    // Import
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    
    public static partial class Helper
    {
        public static object TensorTypes = CoerceIntoObject(ValueTuple.Create(Symbol.Symbol, NDArrayBase.NDArray));
    }
    
    public partial class DeferredInitializationError : MXNetError
    {
        
        // Expr
        /* pass */
    }
    
    public partial class Parameter : PythonObject
    {
        private Symbol _var;
        private NDArrayBase _data;
        private NDArrayBase _grad;
        private Context[] _ctxList;
        private object _ctxMap;
        private Trainer _trainer;
        private ValueTuple<Initializer, Context, Initializer, NDArrayBase> _deferredInit;
        private bool _differentiable;
        private bool _allowDeferredInit;
        private string _gradReq;
        private Shape _shape;
        public string Name { get; set; }
        private DType _dtype;
        public float LrMult { get; set; }
        public float WdMult { get; set; }
        public Initializer Init { get; set; }
        private string _gradStype;
        private string _stype;
        
        // Expr
        
        public Parameter(string name, string gradReq = "write", Shape shape = null, DType dtype = mx_real_t, float lrMult = 1.0f, float wdMult = 1.0f, Initializer init = null, bool allowDeferredInit = false, bool differentiable = true, string stype = "default", string gradStype = "default")
        {
            this._var = CoerceIntoSymbol(null);
            this._data = CoerceIntoNDArray(null);
            this._grad = CoerceIntoNDArray(null);
            this._ctxList = CoerceIntoContext[](null);
            this._ctxMap = CoerceIntoObject(null);
            this._trainer = CoerceIntoTrainer(null);
            this._deferredInit = CoerceIntoValueTuple<Initializer, Context, Initializer, NDArrayBase>(ValueTuple.Create());
            this._differentiable = CoerceIntoBool(differentiable);
            this._allowDeferredInit = CoerceIntoBool(allowDeferredInit);
            this._gradReq = CoerceIntoString(null);
            if (IsTrue(Isinstance(shape, Int))){
                var local0 = (int)shape;
                shape = ValueTuple.Create(local0);
            }
            this._shape = CoerceIntoShape(shape);
            this.Name = name;
            this._dtype = CoerceIntoDType(dtype);
            this.LrMult = lrMult;
            this.WdMult = wdMult;
            this.GradReq = gradReq;
            this.Init = init;
            var validStypes = new [] { "default", "row_sparse", "csr" };
            Assert((validStypes.Contains(gradStype)), "(validStypes.Contains(gradStype))");
            Assert((validStypes.Contains(stype)), "(validStypes.Contains(stype))");
            this._gradStype = CoerceIntoString(gradStype);
            this._stype = CoerceIntoString(stype);
        }
        
        private string Repr()
        {
            var s = "Parameter {name} (shape={shape}, dtype={dtype})";
            return s.Format(name: this.Name, shape: this.Shape, dtype: this.Dtype);
        }
        
        public override string GradReq
        {
            get {
                return this._gradReq;
            }
            set => SetGradReq(value);
        }
        
        public override void SetGradReq(string req)
        {
            Assert((new [] { "write", "add", "null" }.Contains(req)), "(new [] { \"write\", \"add\", \"null\" }.Contains(req))");
            if (IsTrue((!IsTrue(this._differentiable)))){
                req = "null";
            }
            if (IsTrue((this._gradReq == req))){
                return;
            }
            this._gradReq = CoerceIntoString(req);
            if (IsTrue((IsTrue((req == "null")) && IsTrue((!(this._grad is null)))))){
                this._grad = CoerceIntoNDArray(null);
                this._data = CoerceIntoNDArray(this._data.Select(i => i.Detach()).ToList());
            }
            else
            {
                if (IsTrue((!(this._data is null)))){
                    this._initGrad();
                }
            }
        }
        
        public DType Dtype
        {
            get {
                // Expr
                return this._dtype;
            }
            set => SetDtype(value);
        }
        
        public void SetDtype(DType dtype)
        {
            this.Cast(dtype);
        }
        
        public Shape Shape
        {
            get {
                // Expr
                if (IsTrue((this._shape is null))){
                    return null;
                }
                else
                {
                    if (IsTrue(IsNpShape())){
                        return Tuple(this._shape.Select(i => (IsTrue((i != 0)) ? i : (-1))));
                    }
                    else
                    {
                        return this._shape;
                    }
                }
            }
            set => SetShape(value);
        }
        
        public void SetShape(Shape newShape)
        {
            if (IsTrue((this._shape is null))){
                this._shape = CoerceIntoShape(newShape);
                return;
            }
            Assert((IsTrue((Len(this._shape) == Len(newShape))) && IsTrue(All(Zip(newShape, this._shape).Select((i, j) => (ValueTuple.Create(0, i).Contains(j)))))), "(IsTrue((Len(this._shape) == Len(newShape))) && IsTrue(All(Zip(newShape, this._shape).Select((i, j) => (ValueTuple.Create(0, i).Contains(j))))))");
            this._shape = CoerceIntoShape(newShape);
        }
        
        private void _setTrainer(Trainer trainer)
        {
            // Expr
            if (IsTrue((IsTrue((this._stype != "default")) && IsTrue(this._trainer) && IsTrue(trainer) && IsTrue((!(this._trainer is trainer)))))){
                throw new RuntimeError(("Failed to set the trainer for Parameter '%s' because it was already set. More than one trainers for a %s Parameter is not supported.".PyFormat(ValueTuple.Create(this.Name, this._stype))));
            }
            this._trainer = CoerceIntoTrainer(trainer);
        }
        
        private object _checkAndGet(object arrList, Context ctx)
        {
            if (IsTrue((!(arrList is null)))){
                if (IsTrue((ctx is List))){
                    return arrList;
                }
                if (IsTrue((ctx is null))){
                    if (IsTrue((Len(arrList) == 1))){
                        return arrList.Item1;
                    }
                    else
                    {
                        ctx = Context.CurrentContext();
                    }
                }
                var ctxList = this._ctxMap[(ctx.DeviceTypeid & 1)];
                if (IsTrue((ctx.DeviceId < Len(ctxList)))){
                    var idx = ctxList[ctx.DeviceId];
                    if (IsTrue((!(idx is null)))){
                        return arrList[idx];
                    }
                }
                throw new RuntimeError(("Parameter '%s' was not initialized on context %s. It was only initialized on %s.".PyFormat(ValueTuple.Create(this.Name, Str(ctx), Str(this._ctxList)))));
            }
            if (IsTrue(this._deferredInit)){
                throw new DeferredInitializationError(("Parameter '%s' has not been initialized yet because initialization was deferred. Actual initialization happens during the first forward pass. Please pass one batch of data through the network before accessing Parameters. You can also avoid deferred initialization by specifying in_units, num_features, etc., for network layers.".PyFormat(this.Name)));
            }
            throw new RuntimeError(("Parameter '%s' has not been initialized. Note that you should initialize parameters and create Trainer with Block.collect_params() instead of Block.params because the later does not include Parameters of nested child Blocks".PyFormat(this.Name)));
        }
        
        private object _getRowSparse(object arrList, Context ctx, object rowId)
        {
            // Expr
            if (IsTrue((!IsTrue(Isinstance(rowId, NDArrayBase.NDArray))))){
                throw new TypeError(("row_id must have NDArray type, but %s is given".PyFormat(Type(rowId))));
            }
            if (IsTrue((!IsTrue(this._trainer)))){
                throw new RuntimeError(("Cannot get row_sparse data for Parameter '%s' when no Trainer is created with it.".PyFormat(this.Name)));
            }
            var results = this._checkAndGet(arrList, ctx);
            this._trainer._rowSparsePull(this, results, rowId);
            return results;
        }
        
        private void _loadInit(NDArrayBase data, Context ctx, bool castDtype = false, string dtypeSource = "current")
        {
            // Expr
            if (IsTrue(castDtype)){
                Assert((new [] { "current", "saved" }.Contains(dtypeSource)), "(new [] { \"current\", \"saved\" }.Contains(dtypeSource))");
            }
            if (IsTrue(this.Shape)){
                foreach (var (SelfDim, DataDim) in Zip(this.Shape, data.Shape))
                {
                    Assert((ValueTuple.Create(0, DataDim).Contains(SelfDim)), "(ValueTuple.Create(0, DataDim).Contains(SelfDim))");
                }
                this.Shape = Tuple(Zip(this.Shape, data.Shape).Select((i, j) => (IsTrue((i != 0)) ? i : j)));
            }
            if (IsTrue(this.Dtype)){
                if (IsTrue((IsTrue(castDtype) && IsTrue((FakeNumpy.Dtype(this.Dtype).Type != data.Dtype))))){
                    if (IsTrue((dtypeSource == "current"))){
                        data = data.Astype(this.Dtype, copy: false);
                    }
                    else
                    {
                        if (IsTrue((dtypeSource == "saved"))){
                            this.Dtype = data.Dtype;
                        }
                    }
                }
                else
                {
                    Assert((FakeNumpy.Dtype(this.Dtype).Type == data.Dtype), "(Np.Dtype(this.Dtype).Type == data.Dtype)");
                }
            }
            if (IsTrue((this._stype != data.Stype))){
                data = data.Tostype(this._stype);
            }
            if (IsTrue(Isinstance(ctx, typeof(Context)))){
                var local0 = (Context)ctx;
                ctx = new [] { local0 };
            }
            if (IsTrue((this._data is null))){
                if (IsTrue(this._deferredInit)){
                    Assert((IsTrue((ctx is null)) || IsTrue((Set(ctx) == Set(this._deferredInit.Item2)))), "(IsTrue((ctx is null)) || IsTrue((Set(ctx) == Set(this._deferredInit.Item2))))");
                    ctx = this._deferredInit.Item2;
                }
                else
                {
                    if (IsTrue((ctx is null))){
                        ctx = new [] { Cpu() };
                    }
                }
                this._initImpl(data, ctx);
            }
            else
            {
                Assert((IsTrue((ctx is null)) || IsTrue((Set(ctx) == Set(this.ListCtx())))), "(IsTrue((ctx is null)) || IsTrue((Set(ctx) == Set(this.ListCtx()))))");
                this.SetData(data);
            }
            this._deferredInit = CoerceIntoValueTuple<Initializer, Context, Initializer, NDArrayBase>(ValueTuple.Create());
        }
        
        private void _finishDeferredInit()
        {
            // Expr
            if (IsTrue((!IsTrue(this._deferredInit)))){
                return;
            }
            var (init, ctx, defaultInit, data) = this._deferredInit;
            this._deferredInit = CoerceIntoValueTuple<Initializer, Context, Initializer, NDArrayBase>(ValueTuple.Create());
            Assert(ShapeIsKnown(this.Shape), "ShapeIsKnown(this.Shape)");
            var local0 = Autograd.Pause();
            local0.Enter();
            try
            {
                if (IsTrue((data is null))){
                    data = NDArrayBase.Zeros(shape: this.Shape, dtype: this.Dtype, ctx: Context.Cpu(), stype: this._stype);
                    Initializer.Create(defaultInit)(Initializer.InitDesc(this.Name, new System.Collections.Hashtable(){
                        { "__init__", init },
                    }
                    ), data);
                }
                this._initImpl(data, ctx);
            }
            finally
            {
                local0.Exit(null, null, null);
            }
        }
        
        private object _initImpl(NDArrayBase data, object ctxList)
        {
            // Expr
            this._ctxList = CoerceIntoContext[](List(ctxList));
            this._ctxMap = CoerceIntoObject(new [] { new [] {  }, new [] {  } });
            foreach (var (I, Ctx) in Enumerate(this._ctxList))
            {
                var devList = this._ctxMap[(Ctx.DeviceTypeid & 1)];
                while (IsTrue()){
                    devList.Append(null);
                }
                devList[Ctx.DeviceId] = I;
            }
            this._data = CoerceIntoNDArray(this._ctxList.Select(ctx => data.Copyto(ctx)).ToList());
            this._initGrad();
        }
        
        private object _initGrad()
        {
            // Expr
            if (IsTrue((this.GradReq == "null"))){
                this._grad = CoerceIntoNDArray(null);
                return null;
            }
            this._grad = CoerceIntoNDArray(this._data.Select(i => NDArrayBase.Zeros(shape: i.Shape, dtype: i.Dtype, ctx: i.Context, stype: this._gradStype)).ToList());
            Autograd.MarkVariables(this._checkAndGet(this._data, List), this._grad, this.GradReq);
        }
        
        private object _reduce()
        {
            // Expr
            var ctx = Context.Cpu();
            if (IsTrue((this._stype == "default"))){
                var block = this.ListData();
                var data = (NDArrayBase.AddN(block.Select(w => w.Copyto(ctx))) / Len(block));
            }
            else
            {
                var allRowIds = NDArrayBase.Arange(0, this.Shape.Item1, dtype: "int64", ctx: ctx);
                data = NDArrayBase.Zeros(this.Shape, stype: "row_sparse", ctx: ctx);
                this._trainer._rowSparsePull(this, data, allRowIds, fullIdx: true);
            }
            return data;
        }
        
        public object Initialize(Initializer init = null, Context ctx = null, object defaultInit = initializer.Uniform(), bool forceReinit = false)
        {
            // Expr
            if (IsTrue((IsTrue((!(this._data is null))) && IsTrue((!IsTrue(forceReinit)))))){
                Warnings.Warn(("Parameter '%s' is already initialized, ignoring. Set force_reinit=True to re-initialize.".PyFormat(this.Name)), stacklevel: 2);
                return null;
            }
            local0 = CoerceIntoNDArray(null)this._data = local0;
            this._grad = local0;
            if (IsTrue((ctx is null))){
                ctx = new [] { Context.CurrentContext() };
            }
            if (IsTrue(Isinstance(ctx, typeof(Context)))){
                var local1 = (Context)ctx;
                ctx = new [] { local1 };
            }
            if (IsTrue((init is null))){
                init = (IsTrue((this.Init is null)) ? defaultInit : this.Init);
            }
            if (IsTrue((!IsTrue(ShapeIsKnown(this.Shape))))){
                if (IsTrue(this._allowDeferredInit)){
                    this._deferredInit = CoerceIntoValueTuple<Initializer, Context, Initializer, NDArrayBase>(ValueTuple.Create(init, ctx, defaultInit, null));
                    return null;
                }
                throw new ValueError(("Cannot initialize Parameter '%s' because it has invalid shape: %s.".PyFormat(ValueTuple.Create(this.Name, Str(this.Shape)))));
            }
            this._deferredInit = CoerceIntoValueTuple<Initializer, Context, Initializer, NDArrayBase>(ValueTuple.Create(init, ctx, defaultInit, null));
            this._finishDeferredInit();
        }
        
        public void ResetCtx(Context ctx)
        {
            // Expr
            if (IsTrue((ctx is null))){
                ctx = new [] { Context.CurrentContext() };
            }
            if (IsTrue(Isinstance(ctx, typeof(Context)))){
                var local0 = (Context)ctx;
                ctx = new [] { local0 };
            }
            if (IsTrue(this._data)){
                var data = this._reduce();
                var local0 = Autograd.Pause();
                local0.Enter();
                try
                {
                    this._initImpl(data, ctx);
                }
                finally
                {
                    local0.Exit(null, null, null);
                }
            }
            else
            {
                if (IsTrue(this._deferredInit)){
                    var (init, unused, defaultInit, local1) = this._deferredInit;
                    data = local1;
                    this._deferredInit = CoerceIntoValueTuple<Initializer, Context, Initializer, NDArrayBase>(ValueTuple.Create(init, ctx, defaultInit, data));
                }
                else
                {
                    throw new ValueError(("Cannot reset context for Parameter '%s' because it has not been initialized.".PyFormat(this.Name)));
                }
            }
        }
        
        public void SetData(NDArrayBase data)
        {
            // Expr
            this.Shape = data.Shape;
            if (IsTrue((this._data is null))){
                Assert(this._deferredInit, "this._deferredInit");
                this._deferredInit = CoerceIntoValueTuple<Initializer, Context, Initializer, NDArrayBase>((this._deferredInit.Slice(null, 3, null) + ValueTuple.Create(data)));
                return;
            }
            if (IsTrue((IsTrue(this._trainer) && IsTrue(this._trainer._kvInitialized) && IsTrue(this._trainer._updateOnKvstore)))){
                if (IsTrue((!this._trainer._paramsToInit.Contains(this)))){
                    this._trainer._resetKvstore();
                }
            }
            foreach (var arr in this._checkAndGet(this._data, List))
            {
                arr.Slice(null, null, null) = data;
            }
        }
        
        public object RowSparseData(object rowId)
        {
            // Expr
            if (IsTrue((this._stype != "row_sparse"))){
                throw new RuntimeError(("Cannot return a copy of Parameter %s via row_sparse_data() because its storage type is %s. Please use data() instead.".PyFormat(ValueTuple.Create(this.Name, this._stype))));
            }
            return this._getRowSparse(this._data, rowId.Context, rowId);
        }
        
        public object ListRowSparseData(object rowId)
        {
            // Expr
            if (IsTrue((this._stype != "row_sparse"))){
                throw new RuntimeError(("Cannot return copies of Parameter '%s' on all contexts via list_row_sparse_data() because its storage type is %s. Please use data() instead.".PyFormat(ValueTuple.Create(this.Name, this._stype))));
            }
            return this._getRowSparse(this._data, List, rowId);
        }
        
        public NDArrayBase Data(Context ctx = null)
        {
            // Expr
            if (IsTrue((this._stype != "default"))){
                throw new RuntimeError(("Cannot return a copy of Parameter '%s' on ctx %s via data() because its storage type is %s. Please use row_sparse_data() instead.".PyFormat(ValueTuple.Create(this.Name, Str(ctx), this._stype))));
            }
            return this._checkAndGet(this._data, ctx);
        }
        
        public object ListData()
        {
            // Expr
            if (IsTrue((this._stype != "default"))){
                throw new RuntimeError(("Cannot return copies of Parameter '%s' on all contexts via list_data() because its storage type is %s. Please use row_sparse_data() instead.".PyFormat(ValueTuple.Create(this.Name, this._stype))));
            }
            return this._checkAndGet(this._data, List);
        }
        
        public object Grad(Context ctx = null)
        {
            // Expr
            if (IsTrue((IsTrue((!(this._data is null))) && IsTrue((this._grad is null))))){
                throw new RuntimeError(("Cannot get gradient array for Parameter '%s' because grad_req='null'".PyFormat(this.Name)));
            }
            return this._checkAndGet(this._grad, ctx);
        }
        
        public object ListGrad()
        {
            // Expr
            if (IsTrue((IsTrue((!(this._data is null))) && IsTrue((this._grad is null))))){
                throw new RuntimeError(("Cannot get gradient array for Parameter '%s' because grad_req='null'".PyFormat(this.Name)));
            }
            return this._checkAndGet(this._grad, List);
        }
        
        public Context[] ListCtx()
        {
            // Expr
            if (IsTrue((this._data is null))){
                if (IsTrue(this._deferredInit)){
                    return this._deferredInit.Item2;
                }
                throw new RuntimeError(("Parameter '%s' has not been initialized".PyFormat(this.Name)));
            }
            return this._ctxList;
        }
        
        public object ZeroGrad()
        {
            // Expr
            if (IsTrue((this._grad is null))){
                return null;
            }
            foreach (var i in this._grad)
            {
                NDArrayBase.ZerosLike(i, out: i);
            }
        }
        
        public Symbol Var()
        {
            // Expr
            if (IsTrue((this._var is null))){
                this._var = CoerceIntoSymbol(Symbol.Var(this.Name, shape: this.Shape, dtype: this.Dtype, lrMult: this.LrMult, wdMult: this.WdMult, init: this.Init, stype: this._stype));
            }
            return this._var;
        }
        
        public void Cast(DType dtype)
        {
            // Expr
            this._dtype = CoerceIntoDType(dtype);
            if (IsTrue((this._data is null))){
                return;
            }
            var local0 = Autograd.Pause();
            local0.Enter();
            try
            {
                this._data = CoerceIntoNDArray(this._data.Select(i => i.Astype(dtype)).ToList());
                if (IsTrue((this._grad is null))){
                    return;
                }
                this._grad = CoerceIntoNDArray(this._grad.Select(i => i.Astype(dtype)).ToList());
                Autograd.MarkVariables(this._data, this._grad, this.GradReq);
            }
            finally
            {
                local0.Exit(null, null, null);
            }
        }
    }
    
    public partial class Constant : Parameter
    {
        public object Const { get; set; }
        public object Value { get; set; }
        
        // Expr
        
        public Constant(string name, object value)
        {
            if (IsTrue((!IsTrue(Isinstance(value, NDArrayBase.NDArray))))){
                value = NDArrayBase.Array(value);
            }
            this.Value = value;
            // Skip: class {name}
            var initName = "Constant_{}_{}".Format(name, Id(this));
            Initializer.Alias(initName)(typeof(Init));
            base.Init(name, gradReq: "null", shape: value.Shape, dtype: value.Dtype, init: initName);
        }
        
        private object Repr()
        {
            var s = "Constant {name} (shape={shape}, dtype={dtype})";
            return s.Format(name: this.Name, shape: this.Shape, dtype: this.Dtype);
        }
        
        public override string GradReq
        {
            get {
                return "null";
            }
            set => SetGradReq(value);
        }
        
        public override void SetGradReq(string req)
        {
            if (IsTrue((req != "null"))){
                Warnings.Warn("Constant parameter \{}\ does not support grad_req other than \null\, and new value \{}\ is ignored.".Format(this.Name, req));
            }
        }
    }
    
    public partial class ParameterDict : PythonObject
    {
        private string _prefix;
        private Dictionary<string, Parameter> _params;
        private ParameterDict _shared;
        
        // Expr
        
        public ParameterDict(string prefix = "", ParameterDict shared = null)
        {
            this._prefix = CoerceIntoString(prefix);
            this._params = CoerceIntoDictionary<string, Parameter>(new OrderedDict());
            this._shared = CoerceIntoParameterDict(shared);
        }
        
        private string Repr()
        {
            var s = "{name}(\n{content}\n)";
            var name = (IsTrue(this._prefix) ? (this._prefix + " ") : "");
            return s.Format(name: name, content: "\n".Join(this.Values().Select(v => _indent("  {0}".Format(v), 2)).ToList()));
        }
        
        private Parameter Getitem(string key)
        {
            return this._params[key];
        }
        
        private object Iter()
        {
            return Iter(this._params);
        }
        
        public IEnumerable<ValueTuple<string, Parameter>> Items()
        {
            return this._params.Items();
        }
        
        public IEnumerable<string> Keys()
        {
            return this._params.Keys();
        }
        
        public IEnumerable<Parameter> Values()
        {
            return this._params.Values();
        }
        
        public string Prefix
        {
            get {
                // Expr
                return this._prefix;
            }
        }
        
        private Parameter _getImpl(string name)
        {
            if (IsTrue((this._params.Contains(name)))){
                return this._params[name];
            }
            if (IsTrue((IsTrue((!(this._shared is null))) && IsTrue((this._shared._params.Contains(name)))))){
                this._params[name] = this._shared._params[name];
                return this._shared._params[name];
            }
            return null;
        }
        
        public object Get(string name, object kwargs)
        {
            // Expr
            name = (this.Prefix + name);
            var param = this._getImpl(name);
            if (IsTrue((param is null))){
                param = new Parameter(name);
                this._params[name] = param;
            }
            else
            {
                foreach (var (K, V) in kwargs.Items())
                {
                    if (IsTrue((IsTrue(Hasattr(param, K)) && IsTrue((!(Getattr(param, K) is null)))))){
                        var existing = Getattr(param, K);
                        if (IsTrue((IsTrue((K == "shape")) && IsTrue((Len(V) == Len(existing)))))){
                            var inferredShape = new [] {  };
                            var matched = true;
                            foreach (var (Dim1, Dim2) in Zip(V, existing))
                            {
                                if (IsTrue((IsTrue((Dim1 != Dim2)) && IsTrue(((Dim1 * Dim2) != 0))))){
                                    matched = false;
                                    break;
                                }
                                else
                                {
                                    if (IsTrue((Dim1 == Dim2))){
                                        inferredShape.Append(Dim1);
                                    }
                                    else
                                    {
                                        if (IsTrue((Dim1 == 0))){
                                            inferredShape.Append(Dim2);
                                        }
                                        else
                                        {
                                            inferredShape.Append(Dim1);
                                        }
                                    }
                                }
                            }
                            if (IsTrue(matched)){
                                param._shape = Tuple(inferredShape);
                                continue;
                            }
                        }
                        else
                        {
                            if (IsTrue((IsTrue((K == "dtype")) && IsTrue((FakeNumpy.Dtype(V) == FakeNumpy.Dtype(existing)))))){
                                continue;
                            }
                        }
                        Assert((IsTrue((V is null)) || IsTrue((V == existing))), "(IsTrue((V is null)) || IsTrue((V == existing)))");
                    }
                    else
                    {
                        Setattr(param, K, V);
                    }
                }
            }
            return param;
        }
        
        public object GetConstant(string name, object value = null)
        {
            // Expr
            name = (this.Prefix + name);
            var param = this._getImpl(name);
            if (IsTrue((param is null))){
                if (IsTrue((value is null))){
                    throw new KeyError("No constant named '{}'. Please specify value if you want to create a new constant.".Format(name));
                }
                param = new Constant(name, value);
                this._params[name] = param;
            }
            else
            {
                if (IsTrue((!(value is null)))){
                    Assert(Isinstance(param, typeof(Constant)), "Isinstance(param, typeof(Constant))");
                    var local0 = (Constant)param;
                    if (IsTrue(Isinstance(value, NDArrayBase.NDArray))){
                        value = value.Asnumpy();
                    }
                    Assert((IsTrue((local0.Shape == value.Shape)) && IsTrue((local0.Value.Asnumpy() == value).All())), "(IsTrue((local0.Shape == value.Shape)) && IsTrue((local0.Value.Asnumpy() == value).All()))");
                }
            }
            return local0;
        }
        
        public void Update(ParameterDict other)
        {
            // Expr
            foreach (var (K, V) in other.Items())
            {
                if (IsTrue((this._params.Contains(K)))){
                    Assert((this._params[K] is V), "(this._params[K] is V)");
                }
            }
            foreach (var (K, V) in other.Items())
            {
                this._params[K] = V;
            }
        }
        
        public void Initialize(Initializer init = initializer.Uniform(), Context ctx = null, bool verbose = false, bool forceReinit = false)
        {
            // Expr
            if (IsTrue(verbose)){
                init.SetVerbosity(verbose: verbose);
            }
            foreach (var (unused, V) in this.Items())
            {
                V.Initialize(null, ctx, init, forceReinit: forceReinit);
            }
        }
        
        public void ZeroGrad()
        {
            // Expr
            foreach (var i in this.Values())
            {
                i.ZeroGrad();
            }
        }
        
        public void ResetCtx(Context ctx)
        {
            // Expr
            foreach (var i in this.Values())
            {
                i.ResetCtx(ctx);
            }
        }
        
        public void Setattr(string name, object value)
        {
            // Expr
            foreach (var i in this.Values())
            {
                Setattr(i, name, value);
            }
        }
        
        public void Save(string filename, string stripPrefix = "")
        {
            // Expr
            var argDict = new System.Collections.Hashtable(){
            }
            ;
            foreach (var param in this.Values())
            {
                var weight = param._reduce();
                if (IsTrue((!IsTrue(param.Name.Startswith(stripPrefix))))){
                    throw new ValueError(("Prefix '%s' is to be striped before saving, but Parameter's name '%s' does not start with '%s'. this may be due to your Block shares parameters from other Blocks or you forgot to use 'with name_scope()' when creating child blocks. For more info on naming, please see http://mxnet.incubator.apache.org/tutorials/basic/naming.html".PyFormat(ValueTuple.Create(stripPrefix, param.Name, stripPrefix))));
                }
                argDict[param.Name.Slice(Len(stripPrefix), null, null)] = weight;
            }
            NDArrayBase.Save(filename, argDict);
        }
        
        public void Load(string filename, Context ctx = null, bool allowMissing = false, bool ignoreExtra = false, string restorePrefix = "", bool castDtype = false, string dtypeSource = "current")
        {
            // Expr
            if (IsTrue(restorePrefix)){
                foreach (var name in this.Keys())
                {
                    Assert(name.Startswith(restorePrefix), "name.Startswith(restorePrefix)");
                }
            }
            var lprefix = Len(restorePrefix);
            var ndarrayLoad = NDArrayBase.Load(filename);
            var loaded = (IsTrue(Isinstance(ndarrayLoad, Dict)) ? ndarrayLoad.Items().Select((k, v) => ValueTuple.Create((IsTrue((IsTrue(k.Startswith("arg:")) || IsTrue(k.Startswith("aux:")))) ? k.Slice(4, null, null) : k), v)).ToList() : ndarrayLoad);
            var argDict = loaded.Select((k, v) => ValueTuple.Create((restorePrefix + k), v)).ToDictionary();
            if (IsTrue((!IsTrue(allowMissing)))){
                foreach (var name in this.Keys())
                {
                    Assert((argDict.Contains(name)), "(argDict.Contains(name))");
                }
            }
            foreach (var name in argDict)
            {
                if (IsTrue((!this._params.Contains(name)))){
                    Assert(ignoreExtra, "ignoreExtra");
                    continue;
                }
                this[name]._loadInit(argDict[name], ctx, castDtype: castDtype, dtypeSource: dtypeSource);
            }
        }
    }
}
