using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Python2CSharp
{
    public class Generator
    {
        private Formatter _out;
        private Config _config;

        public Generator(Formatter @out, Config config)
        {
            _out = @out;
            _config = config;
        }

        #region Helper methods

        private string StripQuotes(string s)
        {
            return s.Substring(1, s.Length - 2);
        }

        private CultureInfo _cultureInfo = CultureInfo.InvariantCulture;

        private string ConvertToCamelCase(string s, bool upper)
        {
            if (s == "_")
                return "unused";

            var words = s.Split(new[] { '_' });

            if (upper && s.Length >= 2 && s[0] == '_' && char.IsLower(s[1]))
            {
                // member variables and private methods
                var capitalized = words.Skip(2).Select(x => char.ToUpperInvariant(x[0]) + x.Substring(1));
                return "_" + words[1] + string.Join("", capitalized);
            }

            if (upper)
            {
                var capitalized = words.Select(x => x.Length <= 1 ? x.ToUpper() : char.ToUpperInvariant(x[0]) + x.Substring(1));
                return string.Join("", capitalized);
            }
            else
            {
                var capitalized = words.Skip(1).Select(x => x.Length <= 1 ? x.ToUpper() : char.ToUpperInvariant(x[0]) + x.Substring(1));
                return words[0] + string.Join("", capitalized);
            }
        }

        private string ObjectNameOf(JToken node)
        {
            return node["_Name"].Value<string>();
        }

        private string GetNameProperty(JToken node, string propertyName)
        {
            return StripQuotes(node[propertyName].Value<string>());
        }

        private static readonly HashSet<string> _keywords = new HashSet<string>()
        {
            "params", "out"
        };

        private string EscapeCsKeyword(string s)
        {
            return _keywords.Contains(s) ? "@" + s : s;
        }

        private string ConvertAsLocal(string s)
        {
            return EscapeCsKeyword(ConvertToCamelCase(s, false));
        }

        private bool IsBareName(JToken func, Context ctx)
        {
            return ObjectNameOf(func) == "Name" && ctx.FindLocal(GetNameProperty(func, "id"));
        }

        private bool IsCapitalizedName(JToken node)
        {
            var objectName = ObjectNameOf(node);
            if (objectName != "Name")
                return false;

            var id = GetNameProperty(node, "id");
            return char.IsUpper(id[0]) || (id.Length >= 2 && id[0] == '_' && char.IsUpper(id[1]));
        }

        private bool IsCapitalizedNameOrAttribute(JToken node)
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

        private bool IsMemberVariableAccess(JToken func, Context ctx)
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

        private bool IsIsInstanceCall(JToken test, Context ctx)
        {
            return ObjectNameOf(test) == "Call" &&
                ObjectNameOf(test["func"]) == "Name" && GetNameProperty(test["func"], "id") == "isinstance" &&
                ObjectNameOf(test["args"][0]) == "Name" && ObjectNameOf(test["args"][1]) == "Name";
        }

        private Context ApplyIsInstanceConstraint(JToken test, Context ctx, bool copyContext)
        {
            if (IsIsInstanceCall(test, ctx))
            {
                var l = GetNameProperty(test["args"][0], "id");
                var castTo = GetNameProperty(test["args"][1], "id");

                if (copyContext)
                    ctx = ctx.GetDeepCopy();

                var alias = ctx.MakeLocal();
                ctx.SetAliasForLocal(l, alias);
                _out.WriteLine($"var {alias} = ({castTo}){l};");
            }

            return ctx;
        }

        private bool IsNone(JToken node)
        {
            return node.Type == JTokenType.String && node.Value<string>() == "None";
        }

        private string FormatExpression(JToken node, Context ctx)
        {
            var f = new Formatter();
            var g = new Generator(f, _config);
            g.GenerateExpression(node, ctx.GetDeepCopy());

            return f.GetOutput();
        }

        private MethodConfig GetMethodConfig(Context ctx)
        {
            return _config[ctx.GetClassName()][ctx.GetFunctionName()];
        }

        #endregion

        #region General generators

        public ValueConstraint Generate(JToken node, Context ctx)
        {
            if (IsNone(node))
            {
                _out.Write("null");
                return ValueConstraint.Any;
            }

            var name = node["_Name"].Value<string>();
            ValueConstraint result = null;
            switch (name)
            {
                // Module

                case "Module": result = GenerateModule(node, ctx); break;

                // Statements

                case "FunctionDef": result = GenerateFunctionDef(node, ctx); break;
                case "ClassDef": result = GenerateClassDef(node, ctx); break;
                case "Return": result = GenerateReturn(node, ctx); break;
                case "Assign": result = GenerateAssign(node, ctx); break;
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
                case "Starred": result = GenerateStarred(node, ctx); break;

                default:
                    _out.WriteLine("// " + name);
                    break;
            }

            return result;
        }

        private ValueConstraint GenerateExpression(JToken node, Context ctx)
        {
            return Generate(node, ctx.AsExpression());
        }

        private ValueConstraint GenerateBody(IEnumerable<JToken> nodes, Context ctx)
        {
            foreach (var e in nodes)
                Generate(e, ctx);
            return ValueConstraint.Any;
        }

        private void GenerateCommaSeparated(IEnumerable<JToken> node, Action<JToken> action)
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

        private void GenerateCommaSeparated(JToken node, Context ctx)
        {
            GenerateCommaSeparated(node, e => GenerateExpression(e, ctx));
        }

        private void GenerateCommaSeparated(IEnumerable<JToken> node, Context ctx)
        {
            GenerateCommaSeparated(node, e => GenerateExpression(e, ctx));
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
            _out.WriteNewLine();

            var funcName = GetNameProperty(node, "name");
            var mc = _config[ctx.GetClassName()][funcName];
            if (mc.Drop)
            {
                _out.WriteLine($"// Drop: {funcName}");
                return ValueConstraint.Any;
            }

            var withinClass = ctx.IsInClass();
            if (!withinClass)
            {
                _out.WriteLine("public static partial class Helper");
                _out.WriteOpening("{");
            }

            var kwarg = node["args"]["kwarg"];
            var kwargName = string.Empty;
            if (kwarg.Type == JTokenType.Object && ObjectNameOf(kwarg) == "arg")
                kwargName = GetNameProperty(kwarg, "arg");

            List<string> keywordArguments = mc?.KeywordArguments;

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

            ctx = ctx.EnterFunction(funcName, kwargName, isSetterDef);

            foreach (var arg in args)
                ctx.AddLocal(GetNameProperty(arg, "arg"));

            foreach (var a in analysis.ParamTypes.Keys)
                ctx.TryAddLocal(a);

            if (keywordArguments != null)
            {
                foreach (var arg in keywordArguments)
                    ctx.AddLocal(arg);
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
                    funcName = ConvertToCamelCase(funcName, true);

                var argStrings = args.Select(x => "object " + ConvertToCamelCase(GetNameProperty(x, "arg"), false));
                _out.WriteLine($"public object {funcName}({string.Join(", ", argStrings)})");
            }

            if (!string.IsNullOrEmpty(baseCall))
            {
                _out.WriteLine($": base{baseCall}");
            }

            _out.WriteOpening("{");

            if (analysis.IsProperty)
                _out.WriteOpening("get {");

            if (mc?.Prologue != null)
            {
                foreach (var p in mc?.Prologue)
                    _out.WriteLine(p);
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
                _out.WriteLine($"// Drop: {className}");
                return ValueConstraint.Any;
            }

            var baseClass = _config[className].Base;
            if (baseClass == null)
            {
                var bases = node["bases"][0];
                var baseClassName = FormatExpression(bases, ctx);
            }

            if (baseClass == "object")
                baseClass = "PythonObject";

            _out.WriteNewLine();
            _out.WriteLine($"public partial class {className.Replace("_", "")} : {baseClass.Replace("_", "")}");
            _out.WriteOpening("{");

            foreach (var entry in _config[className].Fields)
                _out.WriteLine(entry.Value);
            _out.WriteNewLine();

            GenerateBody(node["body"], ctx.EnterClass(className));

            _out.WriteClosing("}");

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateReturn(JToken node, Context ctx)
        {
            var mc = GetMethodConfig(ctx);

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

            return ValueConstraint.Any;
        }

        private void GenerateAssignRhs(JToken node, Context ctx, string type)
        {
            if (!string.IsNullOrEmpty(type))
                _out.Write($"CoerceInto{ConvertToCamelCase(type, true)}(");

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
                        _out.WriteLine("// Assignment of __all__");
                        return ValueConstraint.Any;
                    }

                    _out.WriteNewLine();
                    _out.WriteLine("public static partial class Helper");
                    _out.WriteOpening("{");
                }

                var id = GetNameProperty(target, "id");
                if (!_config[ctx.GetClassName()].StaticVariableTypes.TryGetValue(id, out type))
                    type = "object";
                _out.Write($"public static {type} {ConvertToCamelCase(id, true)} = ");
                GenerateAssignRhs(node, ctx, type);
                _out.WriteLine(";");

                if (withinNamespace)
                    _out.WriteClosing("}");

                return ValueConstraint.Any;
            }

            var targetsCount = targets.Count();
            var hasSetAttr = _config[ctx.GetClassName()].SpecialMethods.Contains("__setattr__");
            var useSetAttrs = new List<bool>();
            var types = new List<string>();
            var newLocals = new List<bool>();
            List<string> reassigns = null;

            for (var i = 0; i < targetsCount; ++i)
            {
                var target = targets[i];
                useSetAttrs.Add(hasSetAttr && IsMemberVariableAccess(target, ctx));
                if (ObjectNameOf(target) == "Name")
                {
                    var name = GetNameProperty(target, "id");
                    if (!ctx.FindLocal(name))
                    {
                        type = _config[ctx.GetClassName()].GetFieldTypeOf(name);
                        types.Add(type);
                        newLocals.Add(type == null);
                        if (type == null)
                            ctx.AddLocal(name);
                    }
                    else
                    {
                        types.Add(null); // Future work
                        newLocals.Add(false);
                    }
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
                    GenerateAssignRhs(node, ctx, type);
                }
            }

            for (var i = 0; i < targetsCount; ++i)
            {
                var target = targets[i];
                if (useSetAttrs[i])
                {
                    var attr = GetNameProperty(targets[0], "attr");
                    _out.Write($"Setattr(\"{ConvertToCamelCase(attr, true)}\", ");
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
                        _out.Write(ConvertAsLocal(GetNameProperty(target, "id")));
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
                                    ctx.AddLocal(name);
                                    localDefined = true;
                                    lhs.Add(ConvertAsLocal(name));
                                    continue;
                                }
                            }

                            if (localDefined)
                            {
                                var local = ctx.MakeLocal();
                                var exp = FormatExpression(t, ctx);
                                lhs.Add(local);

                                if (reassigns == null)
                                    reassigns = new List<string>();
                                reassigns.Add($"{exp} = {local};");
                            }
                        }

                        if (localDefined)
                            _out.Write("var ");

                        _out.Write($"({string.Join(", ", lhs)})");
                    }
                    else
                    {
                        // Subscript etc.
                        Generate(target, ctx);
                    }

                    _out.Write(" = ");
                    if (!string.IsNullOrEmpty(rhs))
                        _out.WriteLine($"{rhs};");
                }
            }

            if (string.IsNullOrEmpty(rhs))
            {
                GenerateAssignRhs(node, ctx, type);
                _out.WriteLine(";");
            }

            if (reassigns != null)
            {
                foreach (var r in reassigns)
                    _out.WriteLine(r);
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateFor(JToken node, Context ctx)
        {
            var target = node["target"];
            var localDefined = false;
            if (target["_Name"].Value<string>() == "Name")
                localDefined = ctx.TryAddLocal(GetNameProperty(target, "id"));
            else
            {
                if (target["_Name"].Value<string>() == "ValueTuple")
                {
                    foreach (var e in target["elts"])
                        localDefined = localDefined || ctx.TryAddLocal(GetNameProperty(e, "id"));
                }
            }

            _out.Write("foreach (var ");
            GenerateExpression(target, ctx);
            _out.Write(" in ");
            GenerateExpression(node["iter"], ctx);
            _out.WriteLine(")");
            _out.WriteOpening("{");
            GenerateBody(node["body"], ctx);
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
            _out.Write("if (IsTrue(");
            GenerateExpression(node["test"], ctx);
            _out.Write("))");
            _out.WriteOpening("{");

            var ctx2 = ApplyIsInstanceConstraint(test, ctx, true);
            GenerateBody(node["body"], ctx2);

            _out.WriteClosing("}");

            var orElese = node["orelse"];
            if (orElese.Count() > 0)
            {
                _out.WriteLine("else");
                _out.WriteOpening("{");
                GenerateBody(orElese, ctx);
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

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateTry(JToken node, Context ctx)
        {
            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateAssert(JToken node, Context ctx)
        {
            var exp = FormatExpression(node["test"], ctx);
            _out.WriteLine($"Assert({exp}, \"{exp.Replace("\"", "\\\"")}\");");

            ApplyIsInstanceConstraint(node["test"], ctx, false);

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
            { "Add", " + " },
            { "Sub", " - " },
            { "Mult", " * " },
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

            if (op == "Pow")
            {
                _out.Write("System.Math.Pow(");
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

        private void GenerateVariableList(JToken target, Context ctx)
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

            if (op == "IsNot")
            {
                _out.Write("!(");
                GenerateExpression(left, ctx);
                _out.Write(" is ");
                GenerateExpression(comparators[0], ctx);
                _out.Write(")");
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

            // Special case: kwarg.get["var"]

            if (ObjectNameOf(func) == "Attribute" &&
                ObjectNameOf(func["value"]) == "Name" &&
                GetNameProperty(func["value"], "id") == ctx.KeywordArgumentName)
            {
                if (GetNameProperty(func, "attr") == "get" &&
                    args.Count() == 1 && ObjectNameOf(args[0]) == "Constant")
                {
                    _out.Write(ConvertToCamelCase(GetNameProperty(args[0], "value"), false));
                    return ValueConstraint.Any;
                }
            }

            // Special case: getattr(obj, "prop", default)

//            if (ObjectNameOf(func) == "Name" && GetNameProperty(func, "id") == "getattr" &&
//                ObjectNameOf(args[1]) == "Constant")
//            {
//                _out.Write("(");
//                GenerateExpression(args[0], ctx);
//                _out.Write(")?.");
//                _out.Write(ConvertToCamelCase(GetNameProperty(args[1], "value"), true));
//                if (args.Count() == 3)
//                {
//                    _out.Write(" ?? ");
//                    GenerateExpression(args[2], ctx);
//                }
//
//                return ValueConstraint.Any;
//            }

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

            GenerateCommaSeparated(args, ctx);

            bool hasArgs = args.Count() > 0;
            foreach (var keyword in keywords)
            {
                var arg = keyword["arg"];
                if (IsNone(arg) && GetNameProperty(keyword["value"], "id") == ctx.KeywordArgumentName)
                {
                    var mc = GetMethodConfig(ctx);
                    if (mc.KeywordArguments.Count > 0)
                    {
                        if (hasArgs)
                            _out.Write(", ");
                        hasArgs = true;
                        _out.Write(string.Join(", ", mc.KeywordArguments.Select(x => {
                            var s = ConvertToCamelCase(x, false);
                            return $"{s}: {s}";
                        })));
                    }
                }
                else
                {
                    if (hasArgs)
                        _out.Write(", ");
                    hasArgs = true;
                    _out.Write(ConvertToCamelCase(StripQuotes(arg.Value<string>()), false));
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

            if (value[0] == '\'')
            {
                value = value.Substring(1, value.Length - 2).Replace("\"", "\\");
                value = "\"" + value + "\"";
                constraint = ValueConstraint.String;
            }

            if (value[0] == '"')
                constraint = ValueConstraint.String;

            if (value == "True")
            {
                value = "true";
                constraint = ValueConstraint.Bool;
            }

            if (value == "False")
            {
                value = "false";
                constraint = ValueConstraint.Bool;
            }

            if (value == "None") value = "null";

            _out.Write(value);

            return constraint;
        }

        public ValueConstraint GenerateAttribute(JToken node, Context ctx)
        {
            GenerateExpression(node["value"], ctx);
            var attr = ConvertToCamelCase(StripQuotes(node["attr"].Value<string>()), true);
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
                _out.Write(ConvertToCamelCase(GetNameProperty(slice["value"], "value"), false));
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
            var id = node["id"].Value<string>();
            if (id == "'self'")
                _out.Write("this");
            else
            {
                var n = StripQuotes(id);
                if (ctx.FindLocal(n))
                    _out.Write(ConvertAsLocal(ctx.GetAliasForLocal(n)));
                else
                {
                    if (_config.Replacements.TryGetValue(n, out var rep))
                        _out.Write(rep);
                    else if (!funcName && char.IsUpper(n[0]))
                        _out.Write($"typeof({n})");
                    else
                        _out.Write(ConvertToCamelCase(n, true));
                }
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateList(JToken node, Context ctx)
        {
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
                var mc = GetMethodConfig(ctx);
                _out.Write(string.Join(", ", mc.KeywordArguments.Select(x => ConvertToCamelCase(x, false))));
            }
            else
            {
                _out.Write(ConvertToCamelCase(StripQuotes(arg.Value<string>()), false));
                _out.Write(": ");
                GenerateExpression(node["value"], ctx);
            }

            return ValueConstraint.Any;
        }

        public ValueConstraint GenerateStarred(JToken node, Context ctx)
        {
            GenerateExpression(node["value"], ctx);

            return ValueConstraint.Any;
        }

        #endregion
    }
}
