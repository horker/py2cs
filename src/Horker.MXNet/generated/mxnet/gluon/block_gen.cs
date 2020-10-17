using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Horker.MXNet.Compat;
using static Horker.MXNet.Compat.Compat;
using static Horker.MXNet.Compat.Coercing;

namespace Horker.MXNet.Gluon
{
    using static Helper;
    public static partial class Helper {}
    
    // Expr
    // Assignment of __all__
    // Import
    // Import
    // Import
    // Import
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    
    public partial class BlockScope : PythonObject
    {
        internal Block _block;
        internal Dictionary<string, int> _counter;
        internal BlockScope _oldScope;
        internal BlockScope _nameScope;
        internal string _name;
        
        // Expr
        public static ThreadLocal<BlockScope> _current = CoerceIntoThreadLocal<BlockScope>(Threading.Local());
        
        public BlockScope(Block block)
        {
            this._block = CoerceIntoBlock(block);
            this._counter = CoerceIntoDictionary<string, int>(new Dictionary<string, int>{
            }
            );
            this._oldScope = CoerceIntoBlockScope(null);
            this._nameScope = CoerceIntoBlockScope(null);
        }
        
        public static BlockScope Create(string prefix, ParameterDict @params, string hint)
        {
            // Expr
            var current = Getattr(BlockScope._current, "value", null);
            if (IsTrue((current is null))){
                if (IsTrue((prefix is null))){
                    if (IsTrue((!IsTrue(Hasattr(_name.NameManager._current, "value"))))){
                        _name.NameManager._current.Value = _name.NameManager();
                    }
                    prefix = (_name.NameManager._current.Value.Get(null, hint) + "_");
                }
                if (IsTrue((@params is null))){
                    @params = new ParameterDict(prefix);
                }
                else
                {
                    @params = new ParameterDict(@params.Prefix, @params);
                }
                return ValueTuple.Create(prefix, @params);
            }
            if (IsTrue((prefix is null))){
                var count = current._counter.Get(hint, 0);
                prefix = ("%s%d_".PyFormat(ValueTuple.Create(hint, count)));
                current._counter[hint] = (count + 1);
            }
            if (IsTrue((@params is null))){
                var parent = current._block.Params;
                @params = new ParameterDict((parent.Prefix + prefix), parent._shared);
            }
            else
            {
                @params = new ParameterDict(@params.Prefix, @params);
            }
            return ValueTuple.Create((current._block.Prefix + prefix), @params);
        }
        
        public BlockScope Enter()
        {
            if (IsTrue(this._block._emptyPrefix)){
                return this;
            }
            this._oldScope = CoerceIntoBlockScope(Getattr(BlockScope._current, "value", null));
            BlockScope._current.Value = this;
            this._nameScope = CoerceIntoBlockScope(_name.Prefix(this._block.Prefix));
            this._nameScope.Enter();
            return this;
        }
        
        public void Exit(object ptype, object value, object trace)
        {
            if (IsTrue(this._block._emptyPrefix)){
                return;
            }
            this._nameScope.Exit(ptype, value, trace);
            this._nameScope = CoerceIntoBlockScope(null);
            BlockScope._current.Value = this._oldScope;
        }
    }
    
    // Drop: _flatten
    
    // Drop: _regroup
    
    public partial class Block : PythonObject
    {
        internal bool _emptyPrefix;
        internal string _prefix;
        internal ParameterDict _params;
        internal string _name;
        internal BlockScope _scope;
        internal Dictionary<string, Block> _children;
        internal ParameterDict _regParams;
        internal Hashtable _forwardHooks;
        internal Hashtable _forwardPreHooks;
        
        // Expr
        
        public Block(string prefix, ParameterDict @params)
        {
            Setattr("_emptyPrefix", CoerceIntoBool((prefix == "")));
            CoerceIntoBool((prefix == ""));
            () = BlockScope.Create(prefix, @params, this._alias());
            Setattr("_name", CoerceIntoString((this._prefix.Endswith("_") ? this._prefix.Slice(null, (-1), null) : this._prefix)));
            CoerceIntoString((this._prefix.Endswith("_") ? this._prefix.Slice(null, (-1), null) : this._prefix));
            Setattr("_scope", CoerceIntoBlockScope(new BlockScope(this)));
            CoerceIntoBlockScope(new BlockScope(this));
            Setattr("_children", CoerceIntoDictionary<string, Block>(new OrderedDict()));
            CoerceIntoDictionary<string, Block>(new OrderedDict());
            Setattr("_regParams", CoerceIntoParameterDict(new ParameterDict{
            }
            ));
            CoerceIntoParameterDict(new ParameterDict{
            }
            );
            Setattr("_forwardHooks", CoerceIntoHashtable(new OrderedDict()));
            CoerceIntoHashtable(new OrderedDict());
            Setattr("_forwardPreHooks", CoerceIntoHashtable(new OrderedDict()));
            CoerceIntoHashtable(new OrderedDict());
        }
        
        public object Repr(object self)
        {
            var s = "{name}(\n{modstr}\n)";
            var modstr = "\n".Join(this.Dict.Items().Where((key, block) => Isinstance(block, typeof(Block))).Select((key, block) => "  ({key}): {block}".Format(key: key, block: _indent(block.Repr(), 2))).ToList());
            return s.Format(name: this.Class.Name, modstr: modstr);
        }
        
        public void Setattr(string name, object value)
        {
            // Expr
            if (IsTrue(Hasattr(this, name))){
                var existing = Getattr(this, name);
                if (IsTrue((IsTrue(Isinstance(existing, ValueTuple.Create(typeof(Parameter), typeof(Block)))) && IsTrue((!IsTrue(Isinstance(value, Type(existing)))))))){
                    throw new TypeError("Changing attribute type for {name} from {type1} to {type2}is not allowed.".Format(name: name, type1: Type(existing), type2: Type(value)));
                }
            }
            if (IsTrue(Isinstance(value, typeof(Block)))){
                var local0 = (Block)value;
                this.RegisterChild(local0, name);
            }
            else
            {
                if (IsTrue(Isinstance(value, typeof(Parameter)))){
                    var local0 = (Parameter)value;
                    Assert((!this._regParams.Contains(name)), "(!this._regParams.Contains(name))");
                    this._regParams[name] = local0;
                }
            }
            base.Setattr(name, value);
        }
        
        // Drop: _check_container_with_block
        
        public string _alias()
        {
            return this.Class.Name.Lower();
        }
        
        public string Prefix
        {
            get {
                // Expr
                return this._prefix;
            }
        }
        
        public string Name
        {
            get {
                // Expr
                return this._name;
            }
        }
        
        public BlockScope NameScope()
        {
            // Expr
            return this._scope;
        }
        
        public ParameterDict Params
        {
            get {
                // Expr
                return this._params;
            }
        }
        
        public ParameterDict CollectParams(string select = null)
        {
            // Expr
            this._checkContainerWithBlock();
            var ret = new ParameterDict(this._params.Prefix);
            if (IsTrue((!IsTrue(select)))){
                ret.Update(this.Params);
            }
            else
            {
                var pattern = Re.Compile(select);
                ret.Update(this.Params.Items().Where((name, value) => pattern.Match(name)).Select((name, value) => ValueTuple.Create(name, value)).ToDictionary());
            }
            foreach (var cld in this._children.Values())
            {
                ret.Update(cld.CollectParams(select: select));
            }
            return ret;
        }
        
        internal Hashtable _collectParamsWithPrefix(string prefix = "")
        {
            if (IsTrue(prefix)){
                // AugAssign
            }
            var ret = this._regParams.Items().Select((key, val) => ValueTuple.Create((prefix + key), val)).ToDictionary();
            foreach (var (Name, Child) in this._children.Items())
            {
                ret.Update(Child._collectParamsWithPrefix((prefix + Name)));
            }
            return ret;
        }
        
        public void SaveParamters(string filename)
        {
            // Expr
            var @params = this._collectParamsWithPrefix();
            var argDict = @params.Items().Select((key, val) => ValueTuple.Create(key, val._reduce())).ToDictionary();
            NDArray.Save(filename, argDict);
        }
        
        public void SaveParams(string filename)
        {
            // Expr
            Warnings.Warn("save_params is deprecated. Please use save_parameters. Note that if you want load from SymbolBlock later, please use export instead. For details, see https://mxnet.incubator.apache.org/tutorials/gluon/save_load_params.html");
        }
        
        public void LoadParameters(string filename, Context ctx = null, bool allowMissing = false, bool ignoreExtra = false, bool castDtype = false, string dtypeSource = "current")
        {
            // Expr
            var loaded = NDArray.Load(filename);
            var @params = this._collectParamsWithPrefix();
            if (IsTrue((IsTrue((!IsTrue(loaded))) && IsTrue((!IsTrue(@params)))))){
                return;
            }
            if (IsTrue((!IsTrue(Any(loaded.Keys().Select(i => (i.Contains(".")))))))){
                // Delete
                this.CollectParams().Load(filename, ctx, allowMissing, ignoreExtra, this.Prefix, castDtype: castDtype, dtypeSource: dtypeSource);
                return;
            }
            if (IsTrue((!IsTrue(allowMissing)))){
                foreach (var name in @params.Keys())
                {
                    Assert((loaded.Contains(name)), "(loaded.Contains(name))");
                }
            }
            foreach (var name in loaded)
            {
                if (IsTrue((IsTrue((!IsTrue(ignoreExtra))) && IsTrue((!@params.Contains(name)))))){
                    throw new ValueError(("Parameter '%s' loaded from file '%s' is not present in ParameterDict, which contains parameters %s. Set ignore_extra=True to ignore. " % ValueTuple.Create(name, filename, _briefPrintList(this._params.Keys()))));
                }
                if (IsTrue((@params.Contains(name)))){
                    @params[name]._loadInit(loaded[name], ctx, castDtype: castDtype, dtypeSource: dtypeSource);
                }
            }
        }
        
        public void LoadParams(string filename, Context ctx = null, bool allowMissing = false, bool ignoreExtra = false)
        {
            // Expr
            Warnings.Warn("load_params is deprecated. Please use load_parameters.");
            this.LoadParameters(filename, ctx, allowMissing, ignoreExtra);
        }
        
        public void RegisterChild(Block block, string name)
        {
            // Expr
            if (IsTrue((name is null))){
                name = Str(Len(this._children));
            }
            this._children[name] = block;
        }
        
        public HookHandle RegisterForwardPreHook(object hook)
        {
            // Expr
            var handle = new HookHandle();
            handle.Attach(this._forwardPreHooks, hook);
            return handle;
        }
        
        public HookHandle RegisterForwardHook(object hook)
        {
            // Expr
            var handle = new HookHandle();
            handle.Attach(this._forwardHooks, hook);
            return handle;
        }
        
        public Block Apply(Action<Block> fn)
        {
            // Expr
            foreach (var cld in this._children.Values())
            {
                cld.Apply(fn);
            }
            fn.Call(this);
            return this;
        }
        
        public void Initialize(Initializer init = null, Context ctx, bool verbose = false, bool forceReinit = false)
        {
            // Expr
            this.CollectParams().Initialize(init, ctx, verbose, forceReinit);
        }
        
        public void Hybridize(bool active)
        {
            // Expr
            foreach (var cld in this._children.Values())
            {
                cld.Hybridize(active);
            }
        }
        
        public void Cast(DType dtype)
        {
            // Expr
            foreach (var child in this._children.Values())
            {
                child.Cast(dtype);
            }
            foreach (var (unused, Param) in this.Params.Items())
            {
                Param.Cast(dtype);
            }
        }
        
        public NDArray Call(params NDArray[] args)
        {
            // Expr
            foreach (var hook in this._forwardPreHooks.Values())
            {
                hook.Call(this, args);
            }
            var @out = this.Forward(args);
            foreach (var hook in this._forwardHooks.Values())
            {
                hook.Call(this, args, @out);
            }
            return @out;
        }
        
        public NDArray Forward(params NDArray[] args)
        {
            // Expr
            throw new NotImplementedError();
        }
        
        // Drop: summary
    }
    
    public partial class HybridBlock : PythonObject
    {
        internal CachedGraph _cachedGraph;
        internal CachedOp _cachedOp;
        internal List<int> _outFormat;
        internal List<int> _inFormat;
        internal bool _active;
        internal Dictionary<string, string> _flags;
        
        // Expr
        
        public HybridBlock(string prefix = null, ParameterDict @params = null)
        : base(prefix: prefix, params: @params)
        {
            this._cachedGraph = CoerceIntoCachedGraph(ValueTuple.Create());
            this._cachedOp = CoerceIntoCachedOp(null);
            this._outFormat = CoerceIntoList<int>(null);
            this._inFormat = CoerceIntoList<int>(null);
            this._active = CoerceIntoBool(false);
            this._flags = CoerceIntoDictionary<string, string>(new [] {  });
        }
        
        public Setattr(string name, object value)
        {
            // Expr
            base.Setattr(name, value);
            if (IsTrue(Isinstance(value, typeof(HybridBlock)))){
                var local0 = (HybridBlock)value;
                this._clearCachedOp();
            }
        }
        
        internal CachedGraph _getGraph(NDArrayList args)
        {
            if (IsTrue((!IsTrue(this._cachedGraph)))){
                () = _flatten(args, "input");
                if (IsTrue((Len(args) > 1))){
                    var inputs = Range(Len(args)).Select(i => Symbol.Var(("data%d".PyFormat(i)))).ToList();
                }
                else
                {
                    inputs = new [] { Symbol.Var("data") };
                }
                var groupedInputs = _regroup(inputs, this._inFormat)[0];
                var @params = this._regParams.Items().Select((i, j) => ValueTuple.Create(i, j.Var())).ToDictionary();
                var local0 = this.NameScope();
                local0.Enter();
                try
                {
                    var @out = this.HybridForward(Symbol, groupedInputs, on: @params);
                }
                finally
                {
                    local0.Exit(null, null, null);
                }
                () = _flatten(@out, "output");
                this._cachedGraph = CoerceIntoCachedGraph(ValueTuple.Create(inputs, Symbol.Group(@out)));
            }
            return this._cachedGraph;
        }
        
        internal void _buildCache(NDArrayList args)
        {
            var (data, @out) = this._getGraph(args);
            var dataNames = Enumerate(data).Select((i, data) => ValueTuple.Create(data.Name, i)).ToDictionary();
            var @params = this.CollectParams();
            var inputNames = @out.ListInputs();
            var paramNames = Set(@params.Keys());
            var expectedNames = Set(inputNames);
            foreach (var name in expectedNames)
            {
                Assert((IsTrue((paramNames.Contains(name))) || IsTrue((dataNames.Contains(name)))), "(IsTrue((paramNames.Contains(name))) || IsTrue((dataNames.Contains(name))))");
            }
            var usedDataNames = dataNames.Where(i => (expectedNames.Contains(i))).Select(i => i).ToList();
            if (IsTrue((Len(usedDataNames) != Len(dataNames)))){
                var unused = ", ".Join(dataNames.Items().Where((name, i) => (!expectedNames.Contains(name))).Select((name, i) => ("%d-th".PyFormat(i))).ToList());
                Warnings.Warn(("The %s input to HybridBlock is not used by any computation. Is this intended?".PyFormat(unused)), stacklevel: 4);
            }
            var usedParamNames = paramNames.Where(i => (expectedNames.Contains(i))).Select(i => i).ToList();
            if (IsTrue((Len(usedParamNames) != Len(paramNames)))){
                unused = ", ".Join(List((paramNames - Set(usedParamNames))));
                Warnings.Warn(("Parameter %s is not used by any computation. Is this intended?".PyFormat(unused)), stacklevel: 4);
            }
            var dataIndices = new [] {  };
            var paramIndices = new [] {  };
            this._cachedOpArgs = new [] {  };
            foreach (var (i, name) in Enumerate(inputNames))
            {
                if (IsTrue((dataNames.Contains(name)))){
                    dataIndices.Append(i);
                    this._cachedOpArgs.Append(ValueTuple.Create(true, dataNames[name]));
                }
                else
                {
                    paramIndices.Append(i);
                    this._cachedOpArgs.Append(ValueTuple.Create(false, @params[name]));
                }
            }
            var flags = (new [] { ValueTuple.Create("data_indices", dataIndices), ValueTuple.Create("param_indices", paramIndices) } + this._flags);
            this._cachedOp = CoerceIntoCachedOp(NDArray.CachedOp(@out, flags));
        }
        
        internal void _deferredInferShape(NDArrayList args)
        {
        }
        
        internal void _callCachedOp(NDArrayList args)
        {
            if (IsTrue((this._cachedOp is null))){
                this._buildCache(args);
            }
            var (fmt) = _flatten(args, "input");
            Assert((fmt == this._inFormat), "(fmt == this._inFormat)");
            var @out = this._cachedOp(Cargs);
            if (IsTrue(Isinstance(@out, typeof(NDArray)))){
                var local0 = (NDArray)out;
                @out = new [] { local0 };
            }
            return _regroup(@out, this._outFormat)[0];
        }
        
        internal void _clearCachedOp()
        {
            this._cachedGraph = CoerceIntoCachedGraph(ValueTuple.Create());
            this._cachedOp = CoerceIntoCachedOp(null);
        }
        
        public void RegisterChild(Block block, string name = null)
        {
            if (IsTrue((!IsTrue(Isinstance(block, typeof(HybridBlock)))))){
                throw new ValueError(("Children of HybridBlock must also be HybridBlock, but %s has type %s. If you are using Sequential, please try HybridSequential instead.".PyFormat(ValueTuple.Create(Str(block), Str(Type(block))))));
            }
            base.RegisterChild(block, name);
            this._clearCachedOp();
        }
        
        public void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            this._active = CoerceIntoBool(active);
            this._flags = CoerceIntoDictionary<string, string>(List(Kwargs.Items()));
            this._clearCachedOp();
            if (IsTrue((IsTrue((IsTrue(active) && IsTrue(this._forwardHooks))) || IsTrue(this._forwardPreHooks)))){
                Warnings.Warn("\{}\ is being hybridized while still having forward hook/pre-hook. If \{}\ is a child of HybridBlock, the hooks will not take effect.");
            }
            base.Hybridize(active);
        }
        
        public void Cast(DType dtype)
        {
            this._clearCachedOp();
            base.Cast(dtype);
        }
        
        // Drop: _infer_attrs
        
        public void InferShape(NDArrayList args)
        {
            // Expr
            this._inferAttrs("infer_shape", "shape", args);
        }
        
        public void InferType(NDArrayList args)
        {
            // Expr
            this._inferAttrs("infer_type", "dtype", args);
        }
        
        public void Export(string path, int epoch = 0, bool removeAmpCast = true)
        {
            // Expr
            if (IsTrue((!IsTrue(this._cachedGraph)))){
                throw new RuntimeError("Please first call block.hybridize() and then run forward with this block at least once before calling export.");
            }
            var sym = this._cachedGraph[1];
            sym.Save(("%s-symbol.json".PyFormat(path)), removeAmpCast: removeAmpCast);
            var argNames = Set(sym.ListArguments());
            var auxNames = Set(sym.ListAuxiliaryStates());
            var argDict = new System.Collections.Hashtable(){
            }
            ;
            foreach (var (Name, Param) in this.CollectParams().Items())
            {
                if (IsTrue((argNames.Contains(Name)))){
                    argDict[("arg:%s".PyFormat(Name))] = Param._reduce();
                }
                else
                {
                    Assert((auxNames.Contains(Name)), "(auxNames.Contains(Name))");
                    argDict[("aux:%s".PyFormat(Name))] = Param._reduce();
                }
            }
            NDArray.Save(("%s-%04d.params".PyFormat(ValueTuple.Create(path, epoch))), argDict);
        }
        
        public NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            // Expr
            if (IsTrue(Isinstance(x, typeof(NDArray)))){
                var local0 = (NDArray)x;
                var local1 = local0.Context;
                local1.Enter();
                try
                {
                    if (IsTrue(this._active)){
                        return this._callCachedOp(local0, args);
                    }
                    return this.HybridForward(NDArray, local0, args, on: Params);
                }
                finally
                {
                    local1.Exit(null, null, null);
                }
            }
            Assert(Isinstance(x, typeof(Symbol)), "Isinstance(x, typeof(Symbol))");
            var local0 = (Symbol)x;
            var @params = this._regParams.Items().Select((i, j) => ValueTuple.Create(i, j.Var())).ToDictionary();
            var local1 = this.NameScope();
            local1.Enter();
            try
            {
                return this.HybridForward(Symbol, local0, args, on: @params);
            }
            finally
            {
                local1.Exit(null, null, null);
            }
        }
        
        public NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, object F, params NDArrayOrSymbol[] args)
        {
            // Expr
            throw new NotImplementedError();
        }
    }
    
    public static partial class Helper
    {
        internal static string _commonPrefix(params string[] names)
        {
            // Expr
            if (IsTrue((!IsTrue(names)))){
                return "";
            }
            var prefix = names[0];
            foreach (var name in names)
            {
                var i = 0;
                while (IsTrue()){
                    // AugAssign
                }
                prefix = prefix.Slice(null, i, null);
            }
            return prefix;
        }
    }
    
    public partial class SymbolBlock : PythonObject
    {
        
        // Expr
        
        public static SymbolBlock Imports(string symbolFile, string[] inputNames, string paramFile = null, Context ctx = null)
        {
            // Expr
            var sym = Symbol.Load(symbolFile);
            if (IsTrue(Isinstance(inputNames, Str))){
                var local0 = (str)input_names;
                inputNames = new [] { local0 };
            }
            if (IsTrue((paramFile is null))){
                var inputs = inputNames.Select(i => Symbol.Var(i, dtype: MxRealT)).ToList();
            }
            else
            {
                inputs = inputNames.Select(i => Symbol.Var(i)).ToList();
            }
            var ret = new SymbolBlock(sym, inputs);
            if (IsTrue((!(paramFile is null)))){
                ret.CollectParams().Load(paramFile, ctx: ctx, castDtype: true, dtypeSource: "saved");
            }
            return ret;
        }
        
        public string Repr()
        {
            var s = "{name}(\n{modstr}\n)";
            var modstr = "\n".Join(new [] { "{block} : {numinputs} -> {numoutputs}".Format(block: this._cachedGraph[1], numinputs: Len(this._cachedGraph[0]), numoutputs: Len(this._cachedGraph[1].ListOutputs())) });
            return s.Format(name: this.Class.Name, modstr: modstr);
        }
        
        public SymbolBlock(SymbolList outputs, SymbolList inputs, ParameterDict @params = null)
        : base(prefix: null, params: null)
        {
            this._prefix = "";
            this._params = new ParameterDict("", @params);
            if (IsTrue((IsTrue(Isinstance(inputs, Symbol.Symbol)) && IsTrue((Len(inputs.ListOutputs()) == 1))))){
                inputs = new [] { inputs };
            }
            if (IsTrue((IsTrue(Isinstance(outputs, ValueTuple.Create(List, Tuple))) && IsTrue((Len(outputs) == 1))))){
                outputs = outputs[0];
            }
            var (syms, local0) = _flatten(inputs, "input");
            this._inFormat = local0;
            var (@out, local1) = _flatten(outputs, "output");
            this._outFormat = local1;
            @out = Symbol.Group(@out);
            var inputNames = Set();
            foreach (var i in syms)
            {
                Assert((Len(i.GetInternals().ListOutputs()) == 1), "(Len(i.GetInternals().ListOutputs()) == 1)");
                inputNames.Add(i.Name);
            }
            var rowSparseStorage = NDArray.Ndarray.STORAGETYPESTRTOID["row_sparse"];
            foreach (var i in @out)
            {
                foreach (var j in i.GetInternals())
                {
                    Assert((j.Attr("__storage_type__") != Str(rowSparseStorage)), "(j.Attr(\"__storage_type__\") != Str(rowSparseStorage))");
                }
            }
            var argParams = @out.ListArguments();
            var auxParams = @out.ListAuxiliaryStates();
            var (argTypes, auxTypes) = _inferParamTypes(syms, @out, argParams, auxParams);
            foreach (var (i, Arg) in Enumerate(argParams))
            {
                if (IsTrue((!inputNames.Contains(Arg)))){
                    this.Params.Get(Arg, allowDeferredInit: true, dtype: argTypes[i]);
                }
            }
            foreach (var (i, Aux) in Enumerate(auxParams))
            {
                if (IsTrue((!inputNames.Contains(Aux)))){
                    this.Params.Get(Aux, gradReq: "null", allowDeferredInit: true, dtype: auxTypes[i]);
                }
            }
            this._cachedGraph = ValueTuple.Create(syms, @out);
            var lenPrefix = Len(_commonPrefix(List(this._params.Keys())));
            this._regParams = this._params.Items().Select((key, val) => ValueTuple.Create(key.Slice(lenPrefix, null, null), val)).ToDictionary();
        }
        
        // Drop: forward
        
        public void _clearCachedOp()
        {
            var tmp = this._cachedGraph;
            base._clearCachedOp();
            this._cachedGraph = tmp;
        }
        
        public void Cast(DType dtype)
        {
            this._clearCachedOp();
            base.Cast(dtype);
        }
        
        public NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, object F, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedError();
        }
    }
    
    public static partial class Helper
    {
        internal static IList<DType> _inferParamTypes(SymbolList inParams, Symbol outParams, IList<string> argParams, IList<string> auxParams, DType defaultDType = mx_real_t)
        {
            // Expr
            var argTypes = null;
            var auxTypes = null;
            var inputSymNames = inParams.Select(in_param => inParam.Name).ToList();
            var inputSymArgTypes = new [] {  };
            var canInferInputType = true;
            foreach (var inParam in inParams)
            {
                var inputSymArgType = inParam.InferType()[0];
                if (IsTrue((IsTrue((!IsTrue(inputSymArgType))) || IsTrue((Len(inputSymArgType) < 1))))){
                    canInferInputType = false;
                    break;
                }
                else
                {
                    inputSymArgTypes.Append(inParam.InferType()[0][0]);
                }
            }
            if (IsTrue(canInferInputType)){
                var @params = Zip(inputSymNames, inputSymArgTypes).Select((k, v) => ValueTuple.Create(k, v)).ToDictionary();
            }
            if (IsTrue((IsTrue((argTypes is null)) || IsTrue((Len(argTypes) != Len(argParams)))))){
                argTypes = new [] {  };
                foreach (var unused in argParams)
                {
                    argTypes.Append(defaultDtype);
                }
            }
            if (IsTrue((IsTrue((auxTypes is null)) || IsTrue((Len(auxTypes) != Len(auxParams)))))){
                auxTypes = new [] {  };
                foreach (var unused in auxParams)
                {
                    auxTypes.Append(defaultDtype);
                }
            }
            return ValueTuple.Create(argTypes, auxTypes);
        }
    }
}
