using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Python2CSharp
{
    public class Generator
    {
        protected Formatter _out;
        protected Config _config;
        private List<IHook> _hooks;

        public Formatter Out => _out;
        public Config Config => _config;

        public Generator(Formatter @out, Config config)
        {
            _out = @out;
            _config = config;
            _hooks = new List<IHook>();
        }

        public void AddHook(IHook hook)
        {
            _hooks.Add(hook);
        }

        #region Helper methods

        public string StripQuotes(string s)
        {
            return s.Substring(1, s.Length - 2);
        }

        public string ConvertToCamelCase(string s, bool upper)
        {
            if (string.IsNullOrWhiteSpace(s) || s == "_")
                return s;

            // Upper snake cases
            if (Regex.IsMatch(s, "^[A-Z0-9_]+$"))
                return s;

            // Special method names
            bool special = false;
            var m = Regex.Match(s, "^__(.+)__$");
            if (m.Success)
            {
                special = true;
                s = m.Groups[1].Value;
            }

            var words = s.Split(new[] { '_' }).Where(x => x.Length >= 1).ToArray();

            string result = null;
            if (upper && s.Length >= 2 && s[0] == '_' && char.IsLower(s[1]))
            {
                // member variables and private methods
                var capitalized = words.Skip(1).Select(x => char.ToUpperInvariant(x[0]) + x.Substring(1));
                result = "_" + words[0] + string.Join("", capitalized);
            }
            else if (upper)
            {
                var capitalized = words.Select(x => x.Length <= 1 ? x.ToUpper() : char.ToUpperInvariant(x[0]) + x.Substring(1));
                result = string.Join("", capitalized);
            }
            else
            {
                var capitalized = words.Skip(1).Select(x => x.Length <= 1 ? x.ToUpper() : char.ToUpperInvariant(x[0]) + x.Substring(1));
                result = words[0] + string.Join("", capitalized);
            }

            if (special)
                return "__" + result + "__";
            return result;
        }

        public string ConvertToSnakeCase(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s == "_")
                return s;

            // Upper snake cases
            if (Regex.IsMatch(s, "^[A-Z0-9_]+$"))
                return s;

            // Special method names
            bool special = false;
            var m = Regex.Match(s, "^__(.+)__$");
            if (m.Success)
            {
                special = true;
                s = m.Groups[1].Value;
            }

            var result = string.Join("_", Regex.Split(s, @"([A-Z][^A-Z]+)")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Length == 1 ? char.ToLower(x[0]).ToString() : char.ToLower(x[0]) + x.Substring(1)));

            if (special)
                return "__" + result + "__";
            return result;
        }

        public string ConvertAsLocal(string s)
        {
            return EscapeCsKeyword(ConvertToCamelCase(s, false));
        }

        public string GetLocalName(string s, Context ctx)
        {
            if (ctx.FindLocal(s))
                return ConvertAsLocal(ctx.GetAliasForLocal(s));
            return ConvertAsLocal(s);
        }

        public string ConvertAsMethodOrClassName(string s)
        {
            if (_config.Replacements.TryGetValue(s, out var rep))
                return rep;
            else
                return ConvertToCamelCase(s, true);
        }

        public string ObjectNameOf(JToken node)
        {
            return node["_Name"].Value<string>();
        }

        public string GetNameProperty(JToken node, string propertyName)
        {
            return StripQuotes(node[propertyName].Value<string>());
        }

        public string GetNameId(JToken node)
        {
            return ObjectNameOf(node) == "Name" ? GetNameProperty(node, "id") : string.Empty;
        }

        private static readonly HashSet<string> _keywords = new HashSet<string>()
        {
            "params", "out", "this", "base"
        };

        public string EscapeCsKeyword(string s)
        {
            return _keywords.Contains(s) ? "@" + s : s;
        }

        public bool IsBareName(JToken func, Context ctx)
        {
            return ObjectNameOf(func) == "Name" && ctx.FindLocal(GetNameProperty(func, "id"));
        }

        public bool IsCapitalizedName(JToken node)
        {
            var objectName = ObjectNameOf(node);
            if (objectName != "Name")
                return false;

            var id = GetNameProperty(node, "id");
            return char.IsUpper(id[0]) || (id.Length >= 2 && id[0] == '_' && char.IsUpper(id[1]));
        }

        public bool IsCapitalizedNameOrAttribute(JToken node)
        {
            var objectName = ObjectNameOf(node);
            string id = null;
            if (objectName == "Name")
                id = GetNameProperty(node, "id");
            else if (objectName == "Attribute")
                id = GetNameProperty(node, "attr");
            else
                return false;

            return char.IsUpper(id[0]) || (id.Length >= 2 && id[0] == '_' && char.IsUpper(id[1]));
        }

        public bool IsMemberVariableAccess(JToken func, Context ctx)
        {
            if (!ctx.IsInFunction())
                return false;

            if (ObjectNameOf(func) == "Attribute")
            {
                var value = func["value"];
                return ObjectNameOf(value) == "Name" && GetNameProperty(value, "id") == "self" &&
                    _config[ctx.GetClassName()].Fields.Keys.Contains(GetNameProperty(func, "attr"));
            }

            return false;
        }

        public bool IsIsInstanceCall(JToken test, Context ctx)
        {
            return ObjectNameOf(test) == "Call" &&
                ObjectNameOf(test["func"]) == "Name" && GetNameProperty(test["func"], "id") == "isinstance" &&
                ObjectNameOf(test["args"][0]) == "Name" && ObjectNameOf(test["args"][1]) == "Name";
        }

        public Context ApplyIsInstanceConstraint(JToken test, Context ctx, bool copyContext)
        {
            // I need a cast sentence only when isinstance() is called with a single type specified because specifing multiple types means that type casting is usually necessary to use its value in a python code.
            if (IsIsInstanceCall(test, ctx) && _config.TypeNames.Keys.Contains(GetNameProperty(test["args"][1], "id")))
            {
                var l = GetNameProperty(test["args"][0], "id");
                var castTo = GetNameProperty(test["args"][1], "id");

                if (copyContext)
                    ctx = ctx.DeepCopy();

                var alias = ctx.MakeLocal();
                ctx.SetAliasForLocal(l, alias);
                _out.WriteLine($"var {alias} = ({castTo}){ConvertAsLocal(l)};");
            }

            return ctx;
        }

        public bool IsNone(JToken node)
        {
            return node.Type == JTokenType.String && node.Value<string>() == "None";
        }

        public bool IsConstantNone(JToken node)
        {
            return ObjectNameOf(node) == "Constant" && node["value"].Value<string>() == "None";
        }

        public string FormatExpression(JToken node, Context ctx)
        {
            var f = new Formatter();
            var g = new Generator(f, _config);
            g.GenerateExpression(node, ctx.DeepCopy());

            return f.GetOutput();
        }

        public string GetLocalOrParamType(string name, Context ctx, MethodConfig mc)
        {
            if (mc.Locals.TryGetValue(name, out var config))
                return config.Type;

            if (ctx.FindLocal(name))
                name = ctx.GetAliasForLocal(name);

            // We can't use ConvertAsLocal() because it escapes C# keywords thus we will use ConvertToCamelCase() instead.
            if (mc.SignatureAnalysis.ParamTypes.TryGetValue(ConvertToCamelCase(name, false), out var type))
                return type;

            return string.Empty;
        }

        public bool HasLocalOrParam(string name, Context ctx, MethodConfig mc)
        {
            if (mc.Locals.ContainsKey(name))
                return true;

            if (ctx.FindLocal(name))
                name = ctx.GetAliasForLocal(name);
            if (mc.SignatureAnalysis.ParamTypes.ContainsKey(ConvertToCamelCase(name, false)))
                return true;

            return false;
        }

        public ValueConstraint ResolveCondition(JToken test, Context ctx)
        {
            bool trueCond = true;
            if (ObjectNameOf(test) == "UnaryOp" && ObjectNameOf(test["op"]) == "Not")
            {
                trueCond = false;
                test = test["operand"];
            }

            if (!(ObjectNameOf(test) == "Call" &&
                ObjectNameOf(test["func"]) == "Name" && GetNameProperty(test["func"], "id") == "isinstance"))
                return ValueConstraint.Any;

            if (ObjectNameOf(test["args"][0]) != "Name")
                return ValueConstraint.Any;

            var id = GetNameProperty(test["args"][0], "id");
            id = ctx.GetAliasForLocal(id);
            var mc = ctx.GetMethodConfig();
            var type = GetLocalOrParamType(id, ctx, mc);

            if (string.IsNullOrEmpty(type))
                return ValueConstraint.Any;

            var typeArg = test["args"][1];
            if (ObjectNameOf(typeArg) == "Name")
            {
                var testType = GetNameProperty(typeArg, "id");
                if (_config.TypeNames.TryGetValue(testType, out var testTypes))
                {
                    if (!testTypes.Contains(type))
                        trueCond = !trueCond;
                    return trueCond ? ValueConstraint.True : ValueConstraint.False;
                }

                if (type != ConvertAsMethodOrClassName(testType))
                    trueCond = !trueCond;
                return trueCond ? ValueConstraint.True : ValueConstraint.False;
            }

            if (ObjectNameOf(typeArg) == "Tuple")
            {
                var elts = typeArg["elts"];
                foreach (var e in elts)
                {
                    string testType;
                    if (ObjectNameOf(e) == "Name")
                        testType = GetNameProperty(e, "id");
                    else if (ObjectNameOf(e) == "Attribute")
                        testType = FormatExpression(e, ctx);
                    else
                        return ValueConstraint.Any;
                    if (_config.TypeNames.TryGetValue(testType, out var testTypes))
                    {
                        if (testTypes.Contains(type))
                            return trueCond ? ValueConstraint.True : ValueConstraint.False;
                    }
                }

                trueCond = !trueCond;
                return trueCond ? ValueConstraint.True : ValueConstraint.False;
            }

            return ValueConstraint.Any;
        }

        #endregion

        #region General generators

        public ValueConstraint Generate(JToken node, Context ctx)
        {
            var result = ValueConstraint.Any;
            foreach (var h in _hooks)
            {
                result = h.TryGenerate(node, ctx);
                if (!result.IsInvalid())
                    return result;
            }

            if (IsNone(node))
            {
                _out.Write("null");
                return ValueConstraint.Any;
            }

            var name = node["_Name"].Value<string>();
            switch (name)
            {
                // Module

                case "Module": result = GenerateModule(node, ctx); break;

                // Statements

                case "FunctionDef": result = GenerateFunctionDef(node, ctx); break;
                case "ClassDef": result = GenerateClassDef(node, ctx); break;
                case "Return": result = GenerateReturn(node, ctx); break;
                case "Assign": result = GenerateAssign(node, ctx); break;
                case "AugAssign": result = GenerateAugAssign(node, ctx); break;
                case "For": result = GenerateFor(node, ctx); break;
                case "While": result = GenerateWhile(node, ctx); break;
                case "If": result = GenerateIf(node, ctx); break;
                case "With": result = GenerateWith(node, ctx); break;
                case "Raise": result = GenerateRaise(node, ctx); break;
                case "Try": result = GenerateTry(node, ctx); break;
                case "Assert": result = GenerateAssert(node, ctx); break;
                case "Expr": result = GenerateExpr(node, ctx); break;
                case "Pass": result = GeneratePass(node, ctx); break;
                case "Break": result = GenerateBreak(node, ctx); break;
                case "Continue": result = GenerateContinue(node, ctx); break;

                // Expressions

                case "BoolOp": result = GenerateBoolOp(node, ctx); break;
                case "BinOp": result = GenerateBinOp(node, ctx); break;
                case "UnaryOp": result = GenerateUnaryOp(node, ctx); break;
                case "IfExp": result = GenerateIfExp(node, ctx); break;
                case "Compare": result = GenerateCompare(node, ctx); break;
                case "Dict": result = GenerateDict(node, ctx); break;
                case "ListComp": result = GenerateListComp(node, ctx); break;
                case "SetComp": result = GenerateListComp(node, ctx); break;
                case "DictComp": result = GenerateListComp(node, ctx); break;
                case "GeneratorExp": result = GenerateListComp(node, ctx); break;
                case "Call": result = GenerateCall(node, ctx); break;
                case "Constant": result = GenerateConstant(node, ctx); break;

                case "Attribute": result = GenerateAttribute(node, ctx); break;
                case "Subscript": result = GenerateSubscript(node, ctx); break;
                case "Name": result = GenerateName(node, ctx); break;
                case "List": result = GenerateList(node, ctx); break;
                case "Tuple": result = GenerateTuple(node, ctx); break;

                // Subitems

                case "keyword": result = GenerateKeyword(node, ctx); break; // NOTICE: starts with lowercase letter

                default:
                    _out.WriteLine("// " + name);
                    break;
            }

            return result;
        }

        public ValueConstraint GenerateToplevelExpression(JToken node, Context ctx)
        {
            if (ObjectNameOf(node) == "Name")
            {
                var t = GetNameProperty(node, "id");
                if (_config.TypeNames.Keys.Contains(t))
                {
                    _out.Write($"typeof({ConvertAsMethodOrClassName(t)})");
                    return ValueConstraint.Any;
                }
            }
            else if (ObjectNameOf(node) == "Attribute" && ObjectNameOf(node["value"]) == "Name")
            {
                var t = GetNameProperty(node["value"], "id") + "." + GetNameProperty(node, "attr");
                if (_config.TypeNames.Keys.Contains(t))
                {
                    _out.Write("typeof(");
                    GenerateAttribute(node, ctx);
                    _out.Write(")");
                    return ValueConstraint.Any;
                }
            }

            return Generate(node, ctx.AsExpression());
        }

        public ValueConstraint GenerateExpression(JToken node, Context ctx)
        {
            return Generate(node, ctx.AsExpression());
        }

        public ValueConstraint GenerateBody(IEnumerable<JToken> nodes, Context ctx)
        {
            var constraint = ValueConstraint.Any;
            foreach (var e in nodes)
            {
                constraint = Generate(e, ctx);
                if (constraint.IsTerminal())
                    break;
            }

            return constraint;
        }

        public void GenerateCommaSeparated(IEnumerable<JToken> node, Action<JToken> action)
        {
            var first = true;
            foreach (var e in node)
            {
                if (!first)
                    _out.Write(", ");
                first = false;

                action.Invoke(e);
            }
        }

        public void GenerateCommaSeparated(JToken node, Context ctx)
        {
            GenerateCommaSeparated(node, e => GenerateToplevelExpression(e, ctx));
        }

        #endregion

        #region Module

        public ValueConstraint GenerateModule(JToken node, Context ctx)
        {
            foreach (var line in _config.UsingNamespaces)
                _out.WriteLine(line);

            _out.WriteNewLine();

            _out.WriteLine($"namespace {_config.Namespace}");
            _out.WriteOpening("{");

            _out.WriteLine("using Int = System.Int32;");
            _out.WriteLine("using List = System.Array;");

            _out.WriteLine("using static Helper;");
            _out.WriteLine("public static partial class Helper {}");
            _out.WriteNewLine();

            GenerateBody(node["body"], ctx.EnterNamespace(_config.Namespace));

            _out.WriteClosing("}");

            return ValueConstraint.Any;
        }

        #endregion

        #region Statements

        public ValueConstraint GenerateFunctionDef(JToken node, Context ctx)
        {
            var withinClass = ctx.IsInClass();
            var className = withinClass ? ctx.GetClassName() : "Helper";
            var funcName = GetNameProperty(node, "name");
            List<MethodConfig> mcs;
            try
            {
                mcs = _config[className][funcName];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"MethodConfig is not defined: {className}.{funcName}()");
            }

            foreach (var mc in mcs)
                GenerateFunctionDef(node, ctx, mc);

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateFunctionDef(JToken node, Context ctx, MethodConfig mc)
        {
            _out.WriteNewLine();

            var withinClass = ctx.IsInClass();
            var className = withinClass ? ctx.GetClassName() : "Helper";
            var funcName = GetNameProperty(node, "name");

            if (mc.Drop)
            {
                _out.WriteLine($"// Drop: {funcName}");
                return ValueConstraint.Any;
            }

            if (!withinClass)
            {
                _out.WriteLine("public static partial class Helper");
                _out.WriteOpening("{");
            }

            var vararg = node["args"]["vararg"];
            var varargName = string.Empty;
            if (vararg.Type == JTokenType.Object && ObjectNameOf(vararg) == "arg")
                varargName = GetNameProperty(vararg, "arg");

            var kwarg = node["args"]["kwarg"];
            var kwargName = string.Empty;
            if (kwarg.Type == JTokenType.Object && ObjectNameOf(kwarg) == "arg")
                kwargName = GetNameProperty(kwarg, "arg");

            List<string> keywordArguments = mc.KeywordArguments;

            var isProertyDef = false;
            var isSetterDef = false;
            var decoratorList = node["decorator_list"];
            if (decoratorList != null)
            {
                isProertyDef = decoratorList.Any(x => ObjectNameOf(x) == "Name" && GetNameProperty(x, "id") == "property");
                isSetterDef = decoratorList.Any(x => ObjectNameOf(x) == "Attribute" && GetNameProperty(x, "attr") == "setter");
            }

            var signature = isSetterDef ? mc.SignatureSetter : mc.Signature;
            var analysis = isSetterDef ? mc.SignatureSetterAnalysis : mc.SignatureAnalysis;

            var args = node["args"]["args"];
            var body = node["body"];

            ctx = ctx.EnterFunction(funcName, varargName, kwargName, mc, isSetterDef);

            foreach (var a in analysis.ParamTypes.Keys)
                ctx.AddLocal(ConvertToSnakeCase(a));

            foreach (var (l, a) in mc.LocalAliases)
                ctx.SetAliasForLocal(l, a);

            if (keywordArguments != null)
            {
                foreach (var arg in keywordArguments)
                    ctx.TryAddLocal(arg);
            }

            var oldOut = _out;
            var baseCall = string.Empty;
            var baseCallIndex = -1;

            for (var i = 0; i < body.Count(); ++i)
            {
                baseCall = FormatExpression(body[i], ctx);
                if (Regex.IsMatch(baseCall, "^(\"|//)"))
                    continue;
                if (Regex.IsMatch(baseCall, @"^base\.Init\("))
                {
                    baseCall = baseCall.Substring("base.Init".Length, baseCall.Length - ("base.Init".Length) - 3);
                    baseCallIndex = i;
                }
                else
                {
                    baseCall = null;
                }
                break;
            }

            if (!string.IsNullOrWhiteSpace(signature))
            {
                _out.WriteLine(signature);
            }
            else
            {
                if (!withinClass)
                    _out.Write("static ");

                if (withinClass && funcName == "__init__")
                    funcName = ctx.Name;
                else
                    funcName = ConvertAsMethodOrClassName(funcName);

                var argStrings = args.Select(x => "object " + ConvertAsLocal(GetNameProperty(x, "arg")));
                _out.WriteLine($"public object {funcName}({string.Join(", ", argStrings)})");
            }

            if (!string.IsNullOrEmpty(baseCall))
            {
                _out.WriteLine($": base{baseCall}");
            }

            _out.WriteOpening("{");

            if (analysis.IsProperty)
                _out.WriteOpening("get {");

            if (!string.IsNullOrEmpty(kwargName) && !HasLocalOrParam(kwargName, ctx, mc) && mc.KeywordArguments.Count > 0)
            {
                ctx.TryAddLocal(kwargName);
                _out.WriteLine($"var {ConvertAsLocal(kwargName)} = new Dictionary<string, string>();");
            }

            if (mc.Prologue != null)
            {
                foreach (var p in mc.Prologue)
                    _out.WriteLine(p);
            }

            foreach (var (l, c) in mc.Locals)
            {
                if (!string.IsNullOrEmpty(c.Definition))
                {
                    ctx.TryAddLocal(l);
                    _out.WriteLine(c.Definition);
                }
            }

            if (!string.IsNullOrEmpty(baseCall))
                GenerateBody(body.Skip(baseCallIndex + 1), ctx);
            else
                GenerateBody(body, ctx);

            if (analysis.IsProperty)
            {
                _out.WriteClosing("}");
                if (!string.IsNullOrEmpty(mc.SignatureSetter))
                    _out.WriteLine($"set => {mc.SignatureSetterAnalysis.MethodName}(value);");
            }

            _out.WriteClosing("}");

            if (!withinClass)
                _out.WriteClosing("}");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateClassDef(JToken node, Context ctx)
        {
            var className = GetNameProperty(node, "name");

            if (ctx.IsInFunction())
            {
                _out.WriteLine("// Skip: class {name}");
                return ValueConstraint.Any;
            }

            var config = _config[className];
            if (config.Drop)
            {
                _out.WriteNewLine();
                _out.WriteLine($"// Drop: {className}");
                return ValueConstraint.Any;
            }

            var baseClasses = _config[className].BaseClasses.Select(x => x == "object" ? "PythonObject" : x).ToArray();

            _out.WriteNewLine();
            _out.Write($"public partial class {className}");
            if (baseClasses.Length > 0)
                _out.WriteLine($" : {string.Join(", ", baseClasses)}");
            else
                _out.WriteNewLine();

            _out.WriteOpening("{");

            foreach (var entry in _config[className].Fields)
            {
                if (!entry.Value.Inherited)
                    _out.WriteLine(entry.Value.Signature);
            }
            _out.WriteNewLine();

            GenerateBody(node["body"], ctx.EnterClass(className));

            _out.WriteClosing("}");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateReturn(JToken node, Context ctx)
        {
            var mc = ctx.GetMethodConfig();

            var value = node["value"];
            if (IsNone(value))
            {
                if (mc != null && (ctx.IsSetterDef ? mc.SignatureSetterAnalysis.ReturnType : mc.SignatureAnalysis.ReturnType) == "void")
                    _out.WriteLine("return;");
                else
                    _out.WriteLine("return null;");
            }
            else
            {
                _out.Write("return ");
                GenerateExpression(node["value"], ctx);
                _out.WriteLine(";");
            }

            return ValueConstraint.Terminal;
        }

        public void GenerateAssignRhs(JToken node, Context ctx, string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                var t = type;
                if (type.EndsWith("[]"))
                    t = type.Substring(0, type.Length - 2) + "Array";
                _out.Write($"CoerceInto{ConvertAsMethodOrClassName(t)}(");
            }

            GenerateExpression(node["value"], ctx.WithTypeConstraint(type));

            if (!string.IsNullOrEmpty(type))
                _out.Write(")");
        }

        public ValueConstraint GenerateAssign(JToken node, Context ctx)
        {
            var targets = node["targets"];
            string type = null;

            if (!ctx.IsInFunction())
            {
                if (targets.Type == JTokenType.Array && targets.Count() != 1)
                    throw new GeneratorException(node, ctx, "Outside of functions, an assignent that has multiple nodes as its targets is not supported");

                var target = targets[0];
                var withinNamespace = ctx.IsInNamespace();

                if (withinNamespace)
                {
                    if (ObjectNameOf(target) == "Name" && GetNameProperty(target, "id") == "__all__")
                    {
                        _out.WriteNewLine();
                        _out.WriteLine("// Assignment of __all__");
                        return ValueConstraint.Any;
                    }

                    if (ObjectNameOf(target) == "Attribute")
                    {
                        _out.WriteNewLine();
                        _out.WriteLine("// Assignment of attribute");
                        return ValueConstraint.Any;
                    }
                }

                var id = GetNameProperty(target, "id");
                if (_config[ctx.GetClassName()].StaticFields.TryGetValue(id, out var sf))
                {
                    if (sf.Drop)
                    {
                        _out.WriteNewLine();
                        _out.WriteLine($"// Drop: {id}");
                        return ValueConstraint.Any;
                    }
                    type = sf.Type;
                }
                else
                {
                    type = "object";
                }

                if (withinNamespace)
                {
                    _out.WriteNewLine();
                    _out.WriteLine("public static partial class Helper");
                    _out.WriteOpening("{");
                }

                _out.Write($"public static {type} {ConvertAsMethodOrClassName(id)} = ");
                GenerateAssignRhs(node, ctx, type);
                _out.WriteLine(";");

                if (withinNamespace)
                    _out.WriteClosing("}");

                return ValueConstraint.Any;
            }

            if (targets.Count() == 1 && ObjectNameOf(targets[0]) == "Subscript" &&
                ObjectNameOf(targets[0]["slice"]) =="Slice")
            {
                _out.Write("InsertToSlice(");
                GenerateExpression(targets[0]["value"], ctx);
                _out.Write(", ");
                GenerateExpression(targets[0]["slice"]["lower"], ctx);
                _out.Write(", ");
                GenerateExpression(targets[0]["slice"]["upper"], ctx);
                _out.Write(", ");
                GenerateExpression(targets[0]["slice"]["step"], ctx);
                _out.Write(", ");
                GenerateExpression(node["value"], ctx);
                _out.WriteLine(");");

                return ValueConstraint.Any;
            }

            var targetsCount = targets.Count();
            var hasSetAttr = _config[ctx.GetClassName()].SpecialMethods.Contains("__setattr__");
            var useSetAttrs = new List<bool>();
            var types = new List<string>();
            var newLocals = new List<bool>();
            List<string> reassigns = null;

            var mc = ctx.GetMethodConfig();
            var value = node["value"];
            bool isCtype = targetsCount == 1 &&
                ObjectNameOf(value) == "Call" && ObjectNameOf(value["func"]) == "Attribute" &&
                ObjectNameOf(value["func"]["value"]) == "Name" &&
                GetNameProperty(value["func"]["value"], "id") == "ctypes";

            var ctxRhs = ctx.DeepCopy();

            for (var i = 0; i < targetsCount; ++i)
            {
                var target = targets[i];
                useSetAttrs.Add(hasSetAttr && IsMemberVariableAccess(target, ctx));
                if (ObjectNameOf(target) == "Name")
                {
                    var name = GetNameProperty(target, "id");
                    if (!ctx.FindLocal(name))
                    {
                        ctx.AddLocal(name);
                        newLocals.Add(true);
                    }
                    else
                    {
                        if (mc.Reassigned.Contains(name))
                        {
                            ctx.SetAliasForLocal(name, name + "Reassigned");
                            newLocals.Add(true);
                        }
                        newLocals.Add(false);
                    }
                    if (mc.Locals.TryGetValue(name, out var t))
                        type = t.Type;
                    types.Add(type);
                    if (isCtype)
                        ctx.SetLocalToCtype(name);
                }
                else if (ObjectNameOf(target) == "Attribute" &&
                    ObjectNameOf(target["value"]) == "Name" && GetNameProperty(target["value"], "id") == "self" &&
                    GetNameProperty(target, "attr").StartsWith("_"))
                {
                    var name = GetNameProperty(target, "attr");
                    type = _config[ctx.GetClassName()].GetFieldTypeOf(name);
                    types.Add(type);
                    newLocals.Add(false);
                }
                else
                {
                    types.Add(null);
                    newLocals.Add(false);
                }
            }

            string rhs = null;
            if (targetsCount > 1)
            {
                if (types.Any(x => x != null && x != types[0]))
                    throw new ArgumentException("Variable types mismatch in multiple assignment");

                type = types[0];
                if (useSetAttrs.Any())
                {
                    rhs = ctx.MakeLocal();
                    _out.Write($"{rhs} = ");
                    GenerateAssignRhs(node, ctxRhs, type);
                }
            }

            for (var i = 0; i < targetsCount; ++i)
            {
                var target = targets[i];
                if (useSetAttrs[i])
                {
                    var attr = GetNameProperty(targets[0], "attr");
                    _out.Write($"Setattr(\"{ConvertAsMethodOrClassName(attr)}\", ");
                    if (string.IsNullOrEmpty(rhs))
                        GenerateAssignRhs(node, ctx, types[i]);
                    else
                        _out.Write(rhs);
                    _out.WriteLine(");");
                }
                else
                {
                    var localDefined = false;
                    if (ObjectNameOf(target) == "Name")
                    {
                        if (newLocals[i])
                            _out.Write("var ");
                        var id = GetNameProperty(target, "id");
                        _out.Write(GetLocalName(id, ctx));
                    }
                    else if (ObjectNameOf(target) == "Tuple")
                    {
                        var lhs = new List<string>();
                        foreach (var t in target["elts"])
                        {
                            if (ObjectNameOf(t) == "Name")
                            {
                                var name = GetNameProperty(t, "id");
                                if (!ctx.FindLocal(name))
                                {
                                    localDefined = true;
                                    break;
                                }
                            }
                        }

                        if (localDefined)
                            _out.Write("var (");

                        var first = true;
                        foreach (var t in target["elts"])
                        {
                            if (!first)
                                _out.Write(", ");
                            first = false;
                            if (ObjectNameOf(t) == "Name")
                            {
                                var name = GetNameProperty(t, "id");
                                if (!ctx.FindLocal(name))
                                {
                                    ctx.AddLocal(name);
                                    if (localDefined)
                                    {
                                        _out.Write(GetLocalName(name, ctx));
                                        continue;
                                    }
                                }
                            }

                            if (localDefined)
                            {
                                var local = ctx.MakeLocal();
                                _out.Write(local);

                                if (reassigns == null)
                                    reassigns = new List<string>();
                                var exp = FormatExpression(t, ctx);
                                reassigns.Add($"{exp} = {local};");
                            }
                            else
                            {
                                GenerateExpression(t, ctx);
                            }
                        }
                        _out.Write(")");
                    }
                    else
                    {
                        // Subscript etc.
                        GenerateExpression(target, ctx);
                    }

                    _out.Write(" = ");
                    if (!string.IsNullOrEmpty(rhs))
                        _out.WriteLine($"{rhs};");
                }
            }

            if (string.IsNullOrEmpty(rhs))
            {
                GenerateAssignRhs(node, ctxRhs, type);
                _out.WriteLine(";");
            }

            if (reassigns != null)
            {
                foreach (var r in reassigns)
                    _out.WriteLine(r);
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateAugAssign(JToken node, Context ctx)
        {
            var target = node["target"];
            var op = node["op"]["_Name"].Value<string>();
            var value = node["value"];

            GenerateExpression(target, ctx);
            _out.Write(" = ");
            GenerateBinOp(target, op, value, ctx);
            _out.WriteLine(";");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateFor(JToken node, Context ctx)
        {
            _out.Write("foreach (var ");

            var ctx2 = ctx.DeepCopy();
            var target = node["target"];
            if (ObjectNameOf(target) == "Name")
            {
                var id = GetNameProperty(target, "id");
                ctx2.TryAddLocal(id);
                _out.Write(ConvertAsLocal(id));
            }
            else
            {
                if (ObjectNameOf(target) == "Tuple")
                {
                    _out.Write("(");
                    var first = true;
                    foreach (var e in target["elts"])
                    {
                        if (!first)
                            _out.Write(", ");
                        first = false;

                        if (ObjectNameOf(e) != "Name")
                            throw new ArgumentException("Complex expression is not acceptable as variables in for statements");

                        var id = GetNameProperty(e, "id");
                        ctx2.TryAddLocal(id);
                        _out.Write(ConvertAsLocal(id));
                    }
                    _out.Write(")");
                }
            }

            _out.Write(" in ");
            GenerateExpression(node["iter"], ctx);
            _out.WriteLine(")");
            _out.WriteOpening("{");
            GenerateBody(node["body"], ctx2);
            _out.WriteClosing("}");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateWhile(JToken node, Context ctx)
        {
            _out.Write("while (IsTrue(");
            FormatExpression(node["test"], ctx);
            _out.Write("))");
            _out.WriteOpening("{");
            GenerateBody(node["body"], ctx);
            _out.WriteClosing("}");

            if (node["orelse"].Count() > 0)
                throw new GeneratorException(node, ctx, "else clause in while is not supported");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateIf(JToken node, Context ctx)
        {
            var test = node["test"];
            var cond = ResolveCondition(test, ctx);
            var orElese = node["orelse"];

            if (cond.IsTrue())
                return GenerateBody(node["body"], ctx);

            if (cond.IsFalse())
            {
                if (orElese.Count() > 0)
                    return GenerateBody(orElese, ctx);
                return ValueConstraint.Any;
            }

            _out.Write("if (IsTrue(");
            GenerateExpression(node["test"], ctx);
            _out.WriteLine("))");
            _out.WriteOpening("{");

            var ctx2 = ctx.DeepCopy();
            ApplyIsInstanceConstraint(test, ctx2, false);
            GenerateBody(node["body"], ctx2);

            _out.WriteClosing("}");

            if (orElese.Count() > 0)
            {
                _out.WriteLine("else");
                _out.WriteOpening("{");
                GenerateBody(orElese, ctx.DeepCopy());
                _out.WriteClosing("}");
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateWith(JToken node, Context ctx)
        {
            var objs = new List<string>();
            foreach (var items in node["items"])
            {
                var l = ctx.MakeLocal();
                objs.Add(l);

                _out.Write($"var {l} = ");
                GenerateExpression(items["context_expr"], ctx);
                _out.WriteLine(";");
                _out.WriteLine($"{l}.Enter();");
            }

            _out.WriteLine("try");
            _out.WriteOpening("{");
            GenerateBody(node["body"], ctx);
            _out.WriteClosing("}");

            _out.WriteLine("finally");
            _out.WriteOpening("{");
            foreach (var o in objs)
                _out.WriteLine($"{o}.Exit(null, null, null);");
            _out.WriteClosing("}");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateRaise(JToken node, Context ctx)
        {
            var exc = node["exc"];
            if (ObjectNameOf(exc) == "Name")
            {
                _out.WriteLine($"throw new {GetNameProperty(exc, "id")}();");
            }
            else
            {
                _out.Write("throw ");
                GenerateExpression(node["exc"], ctx);
                _out.WriteLine(";");
            }

            return ValueConstraint.Terminal;
        }

        public ValueConstraint GenerateTry(JToken node, Context ctx)
        {
            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateAssert(JToken node, Context ctx)
        {
            var exp = FormatExpression(node["test"], ctx);
            _out.WriteLine($"Assert(IsTrue({exp}), \"{exp.Replace("\"", "\\\"")}\");");

            // In most cases this is needless.
            // ApplyIsInstanceConstraint(node["test"], ctx, false);

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateExpr(JToken node, Context ctx)
        {
            var value = node["value"];
            if (!ctx.IsInFunction())
                _out.WriteLine("// Expr");
            else
            {
                if (ctx.IsInStatement() && node["value"]["_Name"].Value<string>() != "Call")
                    _out.WriteLine("// Expr");
                else
                {
                    GenerateExpression(node["value"], ctx);
                    _out.WriteLine(";");
                }
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GeneratePass(JToken node, Context ctx)
        {
            _out.WriteLine("/* pass */");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateBreak(JToken node, Context ctx)
        {
            _out.WriteLine("break;");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateContinue(JToken node, Context ctx)
        {
            _out.WriteLine("continue;");

            return ValueConstraint.Any;
        }

        #endregion

        #region Expression

        private static Dictionary<string, string> _boolOpMap = new Dictionary<string, string>
        {
            { "And", " && " },
            { "Or", " || " }
        };

        public ValueConstraint GenerateBoolOp(JToken node, Context ctx)
        {
            var op = node["op"]["_Name"].Value<string>();
            var opString = _boolOpMap[op];
            var values = node["values"];

            _out.Write("(");

            var first = true;
            foreach (var v in values)
            {
                if (!first)
                    _out.Write(opString);
                first = false;
                _out.Write("IsTrue(");
                GenerateExpression(v, ctx);
                _out.Write(")");
            }
            _out.Write(")");

            return ValueConstraint.Bool;
        }

        private static Dictionary<string, string> _binOpMap = new Dictionary<string, string>
        {
            { "Add", "BinOp.Add" },
            { "Mult", "BinOp.Mult" },
            { "Pow", "System.FMath.Pow" },
            { "Sub", " - " },
            { "MatMult", " /* MatMult */ " },
            { "Div", " / " },
            { "Mod", " % " },
            { "LShift", " << " },
            { "RShift", ">> " },
            { "BitOr", " | " },
            { "BitXor", " ^ " },
            { "BitAnd", " & " },
            { "FloorDiv", " / " }
        };

        public ValueConstraint GenerateBinOp(JToken node, Context ctx)
        {
            var left = node["left"];
            var op = node["op"]["_Name"].Value<string>();
            var right = node["right"];

            return GenerateBinOp(left, op, right, ctx);
        }

        public ValueConstraint GenerateBinOp(JToken left, string op, JToken right, Context ctx)
        {
            if (op == "Add" || op == "Mult" || op == "Pow")
            {
                _out.Write(_binOpMap[op]);
                _out.Write("(");
                GenerateExpression(left, ctx);
                _out.Write(", ");
                GenerateExpression(right, ctx);
                _out.Write(")");
                return ValueConstraint.Any;
            }

            _out.Write("(");
            var con = GenerateExpression(left, ctx);

            if (op == "Mod" && con.IsString())
            {
                _out.Write(".PyFormat(");
                GenerateExpression(right, ctx);
                _out.Write(")");
            }
            else
            {
                _out.Write(_binOpMap[op]);
                GenerateExpression(right, ctx);
            }

            _out.Write(")");

            return ValueConstraint.Any;
        }

        private static Dictionary<string, string> _unaryOpMap = new Dictionary<string, string>
        {
            { "UAdd", "+" },
            { "USub", "-" },
            { "Invert", "~" },
            { "Not", "!" }
        };

        public ValueConstraint GenerateUnaryOp(JToken node, Context ctx)
        {
            var op = node["op"]["_Name"].Value<string>();
            var operand = node["operand"];

            _out.Write("(");
            _out.Write(_unaryOpMap[op]);
            if (op == "Not")
                _out.Write("IsTrue(");
            GenerateExpression(operand, ctx);
            if (op == "Not")
                _out.Write(")");
            _out.Write(")");

            return op == "Not" ? ValueConstraint.Bool : ValueConstraint.Any;
        }

        public ValueConstraint GenerateIfExp(JToken node, Context ctx)
        {
            _out.Write("(IsTrue(");
            GenerateExpression(node["test"], ctx);
            _out.Write(") ? ");
            GenerateExpression(node["body"], ctx);
            _out.Write(" : ");
            GenerateExpression(node["orelse"], ctx);
            _out.Write(")");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateDict(JToken node, Context ctx)
        {
            if (ctx.HasTypeConstraint())
                _out.Write("new " + ctx.TypeConstraint);
            else
                _out.Write("new System.Collections.Hashtable()");

            _out.WriteOpening("{");

            var keys = node["keys"];
            var values = node["values"];

            for (var i = 0; i < keys.Count(); ++i)
            {
                var k = keys[i];
                var v = values[i];
                _out.Write("{ ");
                GenerateExpression(k, ctx);
                _out.Write(", ");
                GenerateExpression(v, ctx);
                _out.WriteLine(" },");
            }

            _out.WriteClosing("}");

            return ValueConstraint.Any;
        }

        public void GenerateVariableList(JToken target, Context ctx)
        {
            if (ObjectNameOf(target) == "Name")
            {
                var id = GetNameProperty(target, "id");
                ctx.TryAddLocal(id);
                _out.Write(id);
            }
            else if (ObjectNameOf(target) == "Tuple")
            {
                _out.Write("(");
                var first = true;
                foreach (var e in target["elts"])
                {
                    if (!first)
                        _out.Write(", ");
                    first = false;

                    var id = GetNameProperty(e, "id");
                    ctx.TryAddLocal(id);
                    _out.Write(id);
                }
                _out.Write(")");
            }
            else
                throw new ArgumentException("comprehension parameters should be Name or Tuple");
        }

        public ValueConstraint GenerateListComp(JToken node, Context ctx)
        {
            var nodeType = node["_Name"].Value<string>();

            var generators = node["generators"].ToArray();
            var count = 0;
            var targets = new List<JToken>();
            for (var i = 0; i < generators.Length; ++i)
            {
                var g = generators[i];
                ++count;
                GenerateExpression(g["iter"], ctx);
                var target = g["target"];
                targets.Add(target);
                foreach (var j in g["ifs"])
                {
                    _out.Write(".Where(");
                    GenerateVariableList(target, ctx);
                    _out.Write(" => ");
                    GenerateExpression(j, ctx);
                    _out.Write(")");
                }

                _out.Write(".Select(");

                GenerateVariableList(target, ctx);
                _out.Write(" => ");
            }

            if (nodeType != "DictComp")
            {
                GenerateExpression(node["elt"], ctx);
                _out.Write(new string(')', count));

                if (nodeType == "ListComp")
                {
                    _out.Write(".ToList()");
                    return ValueConstraint.Any;
                }
                else if (nodeType == "SetComp")
                    _out.Write(".ToHashSet()");
            }
            else
            {
                _out.Write("ValueTuple.Create(");
                GenerateExpression(node["key"], ctx);
                _out.Write(", ");
                GenerateExpression(node["value"], ctx);
                _out.Write(")).ToDictionary()");
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateCompare(JToken node, Context ctx)
        {
            var ops = node["ops"];
            if (ops.Count() > 1)
                throw new GeneratorException(node, ctx, "More than one ops used");

            var comparators = node["comparators"];
            if (comparators.Count() > 1)
                throw new GeneratorException(node, ctx, "More than one comparators used");

            var left = node["left"];

            var op = ops[0]["_Name"].Value<string>();

            _out.Write("(");

            if (op == "Is" || op == "IsNot")
            {
                if (op == "IsNot")
                    _out.Write("!");

                if (ObjectNameOf(comparators[0]) == "Constant" && comparators[0]["value"].Value<string>() == "None")
                {
                    _out.Write("IsNone(");
                    GenerateExpression(left, ctx);
                    _out.Write(")");
                }
                else
                {
                    _out.Write("(");
                    GenerateExpression(left, ctx);
                    _out.Write(" is ");
                    GenerateExpression(comparators[0], ctx);
                    _out.Write(")");
                }
            }
            else if (op == "In" || op == "NotIn")
            {
                if (op == "NotIn")
                    _out.Write("!");

                GenerateExpression(comparators[0], ctx);
                _out.Write(".Contains(");
                GenerateExpression(left, ctx);
                _out.Write(")");
            }
            else
            {
                String opString;
                switch (op)
                {
                    case "Eq": opString = " == "; break;
                    case "NotEq": opString = " != "; break;
                    case "Lt": opString = " < "; break;
                    case "LtE": opString = " <= "; break;
                    case "Gt": opString = " > "; break;
                    case "GtE": opString = " >= "; break;
                    case "Is": opString = " is "; break;
                    default:
                        throw new GeneratorException(node, ctx, $"Unknown op: {ops[0].Value<string>()}");
                }
                GenerateExpression(left, ctx);
                _out.Write(opString);
                GenerateExpression(comparators[0], ctx);
            }

            _out.Write(")");

            return ValueConstraint.Bool;
        }

        public ValueConstraint GenerateCall(JToken node, Context ctx)
        {
            var func = node["func"];
            var args = node["args"];
            var keywords = node["keywords"];

            // Special case: kwarg.get("var"[, default])
            // Special case: kwarg.pop("var"[, default])

            if (ObjectNameOf(func) == "Attribute" &&
                GetNameId(func["value"]) == ctx.KeywordArgumentName)
            {
                var attr = GetNameProperty(func, "attr");
                if ((attr == "get" || attr == "pop") &&
                    args.Count() <= 2 && ObjectNameOf(args[0]) == "Constant")
                {
                    _out.Write(ConvertAsLocal(GetNameProperty(args[0], "value")));
                    return ValueConstraint.Any;
                }
            }

            // Special case: Ctypes.ByRef(value)

            if (ObjectNameOf(func) == "Attribute" &&
                ObjectNameOf(func["value"]) == "Name" &&
                GetNameProperty(func["value"], "id") == "ctypes" &&
                GetNameProperty(func, "attr") == "byref" &&
                args.Count() == 1 && ObjectNameOf(args[0]) == "Name")
            {
                _out.Write($"out {ConvertAsLocal(GetNameProperty(args[0], "id"))}");
                return ValueConstraint.Any;
            }

            // Special case: super()

            if (ObjectNameOf(func) == "Name" && GetNameProperty(func, "id") == "super")
            {
                _out.Write("base");
                return ValueConstraint.Any;
            }

            // Object instance creation

            if (IsCapitalizedName(func))
                _out.Write("new ");

            // Function name

            if (ObjectNameOf(func) == "Name")
                GenerateName(func, ctx, true);
            else
                GenerateExpression(func, ctx);

            // Implicit __call__

            if ((ObjectNameOf(func) == "Name" && ctx.FindLocal(GetNameProperty(func, "id"))) ||
                (_config[ctx.GetClassName()].SpecialMethods.Contains("__call__") && IsMemberVariableAccess(func, ctx)))
                _out.Write(".Call");

            _out.Write("(");

            // positional and variadic arguments

            var first = true;
            foreach (var a in args)
            {
                if (!first)
                    _out.Write(", ");
                first = false;

                if (ObjectNameOf(a) == "Starred")
                {
                    var mc = ctx.MethodConfig;
                    if (mc.VariadicArguments.Count == 0)
                    {
                        GenerateToplevelExpression(a["value"], ctx);
                    }
                    else
                    {
                        _out.Write(string.Join(", ", mc.VariadicArguments.Select(ConvertAsLocal)));
                    }
                }
                else
                {
                    GenerateToplevelExpression(a, ctx);
                }
            }

            // keyword arguments

            bool hasArgs = args.Count() > 0;
            foreach (var keyword in keywords)
            {
                var arg = keyword["arg"];
                if (IsNone(arg) && GetNameProperty(keyword["value"], "id") == ctx.KeywordArgumentName)
                {
                    var mc = ctx.GetMethodConfig();
                    if (mc.KeywordArguments.Count > 0)
                    {
                        if (hasArgs)
                            _out.Write(", ");
                        hasArgs = true;
                        _out.Write(string.Join(", ", mc.KeywordArguments.Select(x => {
                            var s = ConvertAsLocal(x);
                            return $"{s}: {s}";
                        })));
                    }
                }
                else
                {
                    if (hasArgs)
                        _out.Write(", ");
                    hasArgs = true;
                    _out.Write(ConvertAsLocal(StripQuotes(arg.Value<string>())));
                    _out.Write(": ");
                    GenerateExpression(keyword["value"], ctx);
                }
            }

            _out.Write(")");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateConstant(JToken node, Context ctx)
        {
            if (ctx.IsInStatement())
            {
                _out.WriteLine("// Constant");
                return ValueConstraint.Any;
            }

            var value = node["value"].Value<string>();
            var constraint = ValueConstraint.Any;

            if (value[0] == '"')
                constraint = ValueConstraint.String;
            else if (value[0] == '\'')
            {
                value = value.Substring(1, value.Length - 2).Replace("\"", "\\\"");
                value = "\"" + value + "\"";
                constraint = ValueConstraint.String;
            }
            else if (value == "True")
            {
                value = "true";
                constraint = ValueConstraint.Bool;
            }
            else if (value == "False")
            {
                value = "false";
                constraint = ValueConstraint.Bool;
            }
            else if (value == "None")
                value = "null";
            else if (Regex.IsMatch(value, @"[+-]?\d*\.\d+([eE][+-]\d+)?"))
                value = value + "f";

            _out.Write(value);

            return constraint;
        }

        public ValueConstraint GenerateAttribute(JToken node, Context ctx)
        {
            // Special case: __class__

            if (GetNameProperty(node, "attr") == "__class__")
            {
                GenerateExpression(node["value"], ctx);
                _out.Write(".GetType()");
                return ValueConstraint.Any;
            }

            // Special case: __name__

            if (GetNameProperty(node, "attr") == "__name__")
            {
                GenerateExpression(node["value"], ctx);
                _out.Write(".Name");
                return ValueConstraint.Any;
            }

            // Special case: Value property call to ctype variables

            if (GetNameProperty(node, "attr") == "value" &&
                ObjectNameOf(node["value"]) == "Name" &&
                ctx.IsLocalCtype(GetNameProperty(node["value"], "id")))
            {
                _out.Write(ConvertAsLocal(GetNameProperty(node["value"], "id")));
                return ValueConstraint.Any;
            }

            GenerateExpression(node["value"], ctx);
            var attr = ConvertAsMethodOrClassName(GetNameProperty(node, "attr"));
            _out.Write($".{attr}");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateSubscript(JToken node, Context ctx)
        {
            var value = node["value"];
            var slice = node["slice"];

            if (ObjectNameOf(value) == "Name" && GetNameProperty(value, "id") == ctx.KeywordArgumentName &&
                ObjectNameOf(slice) == "Index" && ObjectNameOf(slice["value"]) == "Constant")
            {
                _out.Write(ConvertAsLocal(GetNameProperty(slice["value"], "value")));
                return ValueConstraint.Any;
            }

            GenerateExpression(value, ctx);

            if (ObjectNameOf(slice) == "Index")
            {
                if (ObjectNameOf(slice["value"]) == "Constant")
                {
                    var constant = slice["value"]["value"].Value<string>();
                    if (constant == "0" || constant == "1" || constant == "2" || constant == "3" || constant == "4" || constant == "5")
                    {
                        _out.Write($".Item{int.Parse(constant) + 1}");
                        return ValueConstraint.Any;
                    }
                }

                _out.Write("[");
                GenerateExpression(slice["value"], ctx);
                _out.Write("]");
                return ValueConstraint.Any;
            }

            // Slice
            _out.Write(".Slice(");

            if (IsNone(slice["lower"]))
                _out.Write("null, ");
            else
            {
                GenerateExpression(slice["lower"], ctx);
                _out.Write(", ");
            }

            if (IsNone(slice["upper"]))
                _out.Write("null, ");
            else
            {
                GenerateExpression(slice["upper"], ctx);
                _out.Write(", ");
            }


            if (IsNone(slice["step"]))
                _out.Write("null)");
            else
            {
                GenerateExpression(slice["lower"], ctx);
                _out.Write(")");
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateName(JToken node, Context ctx, bool funcName = false)
        {
            var id = GetNameProperty(node, "id");
            if (id == "self")
                _out.Write("this");
            else
            {
                if (ctx.FindLocal(id))
                    _out.Write(ConvertAsLocal(ctx.GetAliasForLocal(id)));
                else
                {
                    _out.Write(ConvertAsMethodOrClassName(id));
                }
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateList(JToken node, Context ctx)
        {
            if (node["elts"].Count() == 0)
            {
                _out.Write("null");
                return ValueConstraint.Any;
            }

            _out.Write("new [] { ");
            GenerateCommaSeparated(node["elts"], ctx);
            _out.Write(" }");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateTuple(JToken node, Context ctx)
        {
            if (node["ctx"]["_Name"].Value<string>() == "Store")
                _out.Write("(");
            else
                _out.Write("ValueTuple.Create(");

            GenerateCommaSeparated(node["elts"], ctx);
            _out.Write(")");

            return ValueConstraint.Any;
        }

        #endregion

        #region Slice

        public ValueConstraint GenerateIndex(JToken node, Context ctx)
        {
            GenerateExpression(node["value"], ctx);

            return ValueConstraint.Any;
        }

        #endregion

        #region Subitems

        public ValueConstraint GenerateKeyword(JToken node, Context ctx)
        {
            var arg = node["arg"];
            if (arg.Value<string>() == "None" && GetNameProperty(node["value"], "id") == ctx.KeywordArgumentName)
            {
                var mc = ctx.GetMethodConfig();
                _out.Write(string.Join(", ", mc.KeywordArguments.Select(x => ConvertAsLocal(x))));
            }
            else
            {
                _out.Write(ConvertAsLocal(StripQuotes(arg.Value<string>())));
                _out.Write(": ");
                GenerateExpression(node["value"], ctx);
            }

            return ValueConstraint.Any;
        }

        #endregion
    }
}
