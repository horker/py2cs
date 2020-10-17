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

        private Context _parent;
        private ModuleContextEnum _moduleContext;
        private StatementContextEnum _statementContext;
        private string _name;
        private Dictionary<string, string> _locals;
        private string _keywordArgumentName;
        private string _typeConstraint;
        private bool _isSetterDef;

        public ModuleContextEnum ModuleContext => _moduleContext;

        public bool IsInNamespace() => _moduleContext == ModuleContextEnum.Namespace;
        public bool IsInClass() => _moduleContext == ModuleContextEnum.Class;
        public bool IsInFunction() => _moduleContext == ModuleContextEnum.Function;

        public bool IsInStatement() => _statementContext == StatementContextEnum.Statement;

        public bool HasTypeConstraint() => !string.IsNullOrEmpty(_typeConstraint);

        public string Name => _name;
        public string KeywordArgumentName => _keywordArgumentName;
        public string TypeConstraint => _typeConstraint;
        public bool IsSetterDef => _isSetterDef;

        public Context(Context parent = null, string name = null, ModuleContextEnum moduleContext = ModuleContextEnum.Namespace, StatementContextEnum statementContext = StatementContextEnum.Statement, Dictionary<string, string> locals = null, string keywordArgumentName = null, string typeConstraint = null, bool isSetterDef = false)
        {
            _parent = parent;
            _name = name;
            _moduleContext = moduleContext;
            _statementContext = statementContext;
            _locals = locals ?? new Dictionary<string, string>();
            _keywordArgumentName = keywordArgumentName;
            _typeConstraint = typeConstraint;
            _isSetterDef = isSetterDef;
        }

        public Context GetCopy()
        {
            return new Context(this, _name, _moduleContext, _statementContext, _locals, _keywordArgumentName, _typeConstraint, _isSetterDef);
        }

        public Context GetDeepCopy()
        {
            return new Context(this, _name, _moduleContext, _statementContext, new Dictionary<string, string>(_locals), _keywordArgumentName, _typeConstraint, _isSetterDef);
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
            return new Context(this, name, ModuleContextEnum.Class, StatementContextEnum.Statement, new Dictionary<string, string>());
        }

        public Context EnterFunction(string name, string keywordArgumentName, bool isSetterDef)
        {
            return new Context(this, name, ModuleContextEnum.Function, StatementContextEnum.Statement, new Dictionary<string, string>(), keywordArgumentName, null, isSetterDef);
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
            _locals.Add(name, name);
        }

        public bool TryAddLocal(string name)
        {
            if (_locals.ContainsKey(name))
                return false;
            _locals.Add(name, name);
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

            _locals.Add(result, null);
            return result;
        }

        public void SetAliasForLocal(string name, string alias)
        {
            _locals[name] = alias;
        }

        public string GetAliasForLocal(string name)
        {
            return _locals[name];
        }

        public Context WithAliases(params (string, string)[] aliases)
        {
            var ctx = GetDeepCopy();
            foreach (var a in aliases)
            {
                ctx.SetAliasForLocal(a.Item1, a.Item2);
            }

            return ctx;
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
