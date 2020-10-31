using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Python2CSharp
{
    public class Context
    {
        public enum ModuleContextEnum { Namespace, Class, Function };
        public enum StatementContextEnum { Statement, Expression };

        public class Local
        {
            public string Alias { get; set; }
            public bool IsCtype { get; set; }

            public Local(string alias, bool isCtype = false)
            {
                Alias = alias;
                IsCtype = isCtype;
            }
        }

        private Context _parent;
        private ModuleContextEnum _moduleContext;
        private StatementContextEnum _statementContext;
        private string _name;
        private Dictionary<string, Local> _locals;
        private string _variadicArgumentName;
        private string _keywordArgumentName;
        private string _typeConstraint;
        private MethodConfig _methodConfig;
        private bool _isSetterDef;

        public ModuleContextEnum ModuleContext => _moduleContext;

        public bool IsInNamespace() => _moduleContext == ModuleContextEnum.Namespace;
        public bool IsInClass() => _moduleContext == ModuleContextEnum.Class;
        public bool IsInFunction() => _moduleContext == ModuleContextEnum.Function;

        public bool IsInStatement() => _statementContext == StatementContextEnum.Statement;

        public bool HasTypeConstraint() => !string.IsNullOrEmpty(_typeConstraint);

        public string Name => _name;
        public string VariadicArgumentName => _variadicArgumentName;
        public string KeywordArgumentName => _keywordArgumentName;
        public string TypeConstraint => _typeConstraint;
        public MethodConfig MethodConfig => _methodConfig;
        public bool IsSetterDef => _isSetterDef;

        public Context(Context parent = null,
            string name = null,
            ModuleContextEnum moduleContext = ModuleContextEnum.Namespace,
            StatementContextEnum statementContext = StatementContextEnum.Statement,
            Dictionary<string, Local> locals = null,
            string variadicArgumentName = null,
            string keywordArgumentName = null,
            string typeConstraint = null,
            MethodConfig methodConfing = null,
            bool isSetterDef = false)
        {
            _parent = parent;
            _name = name;
            _moduleContext = moduleContext;
            _statementContext = statementContext;
            _locals = locals ?? new Dictionary<string, Local>();
            _variadicArgumentName = variadicArgumentName;
            _keywordArgumentName = keywordArgumentName;
            _typeConstraint = typeConstraint;
            _methodConfig = methodConfing;
            _isSetterDef = isSetterDef;
        }

        public Context GetCopy()
        {
            return new Context(this, _name, _moduleContext, _statementContext, _locals, _variadicArgumentName, _keywordArgumentName, _typeConstraint, _methodConfig, _isSetterDef);
        }

        public Context DeepCopy()
        {
            var copyLocal = new Dictionary<string, Local>();
            foreach (var l in _locals)
                copyLocal.Add(l.Key, new Local(l.Value.Alias, l.Value.IsCtype));

            return new Context(this, _name, _moduleContext, _statementContext, copyLocal, _variadicArgumentName, _keywordArgumentName, _typeConstraint, _methodConfig, _isSetterDef);
        }

        public Context AsStatement()
        {
            if (IsInStatement())
                return this;

            var result = GetCopy();
            result._statementContext = StatementContextEnum.Statement;
            return result;
        }

        public Context AsExpression()
        {
            if (!IsInStatement())
                return this;

            var result = GetCopy();
            result._statementContext = StatementContextEnum.Expression;
            return result;
        }

        public Context EnterNamespace(string name)
        {
            return new Context(this, name, ModuleContextEnum.Namespace, StatementContextEnum.Statement);
        }

        public Context EnterClass(string name)
        {
            return new Context(this, name, ModuleContextEnum.Class, StatementContextEnum.Statement);
        }

        public Context EnterFunction(string name, string variadicArgumentName, string keywordArgumentName, MethodConfig mc, bool isSetterDef)
        {
            return new Context(this, name, ModuleContextEnum.Function, StatementContextEnum.Statement, null, variadicArgumentName, keywordArgumentName, null, mc, isSetterDef);
        }

        public Context WithTypeConstraint(string typeConstraint)
        {
            var result = GetCopy();
            result._typeConstraint = typeConstraint;
            return result;
        }

        public bool FindLocal(string name)
        {
            var l = _locals;
            var p = _parent;
            while (l == null && p != null)
            {
                l = p._locals;
                p = p._parent;
            }

            if (l == null)
                return false;

            return l.ContainsKey(name);
        }

        public void AddLocal(string name)
        {
            _locals.Add(name, new Local(name));
        }

        public bool TryAddLocal(string name)
        {
            if (_locals.ContainsKey(name))
                return false;
            _locals.Add(name, new Local(name));
            return true;
        }

        public string MakeLocal()
        {
            var i = 0;
            var baseName = "local";
            string result;
            do
            {
                result = baseName + i++;
            }
            while (_locals.ContainsKey(result));

            _locals.Add(result, new Local(result));
            return result;
        }

        public void SetAliasForLocal(string name, string alias)
        {
            if (_locals.TryGetValue(name, out var l))
                l.Alias = alias;
            else
                _locals.Add(name, new Local(alias));
        }

        public string GetAliasForLocal(string name)
        {
            return _locals[name].Alias;
        }

        public Context WithAliases(params (string, string)[] aliases)
        {
            var ctx = DeepCopy();
            foreach (var a in aliases)
            {
                ctx.SetAliasForLocal(a.Item1, a.Item2);
            }

            return ctx;
        }

        public void SetLocalToCtype(string name)
        {
            _locals[name].IsCtype = true;
        }

        public bool IsLocalCtype(string name)
        {
            if (_locals.TryGetValue(name, out var l))
                return l.IsCtype;
            return false;
        }

        public void SetMethodConfig(MethodConfig mc)
        {
            if (_moduleContext != ModuleContextEnum.Function)
                throw new InvalidOperationException("Current context is not a function");
            _methodConfig = mc;
        }

        public MethodConfig GetMethodConfig()
        {
            if (_moduleContext != ModuleContextEnum.Function)
                throw new InvalidOperationException("Current context is not a function");

            if (_methodConfig == null)
                throw new InvalidOperationException("Method config is null");
            return _methodConfig;
        }

        public string GetClassName()
        {
            var c = this;
            while (c != null && c._moduleContext != ModuleContextEnum.Class)
                c = c._parent;

            return c == null ? "Helper" : c._name;
        }

        public string GetFunctionName()
        {
            var c = this;
            while (c != null && c._moduleContext != ModuleContextEnum.Function)
                c = c._parent;

            return c == null ? null : c._name;
        }
    }
}
