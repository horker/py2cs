using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using YamlDotNet.Serialization.NodeDeserializers;

namespace Python2CSharp.MXNet
{
    public class UFuncHelperHook : Generator, IHook
    {
        public UFuncHelperHook(Formatter @out, Config config)
            : base(@out, config)
        { }

        private void GenerateFanctor(JToken arg, Context ctx, string lhs, string rhs)
        {
            if (ObjectNameOf(arg) != "Lambda")
            {
                Generate(arg, ctx);
                _out.Write($"({ConvertAsLocal(lhs)}, {ConvertAsLocal(rhs)})");
            }
            else
            {
                var ctx2 = ctx.DeepCopy();
                ctx2.SetAliasForLocal("x", lhs);
                ctx2.SetAliasForLocal("y", rhs);
                Generate(arg["body"], ctx2);
            }
        }

        public ValueConstraint TryGenerate(JToken node, Context ctx)
        {
            if (IsNone(node) || ObjectNameOf(node) != "Call" || GetNameId(node["func"]) != "_ufunc_helper")
                return ValueConstraint.NotApplicable;

            var args = node["args"];

            var lhs = GetNameId(args[0]);
            var rhs = GetNameId(args[1]);

            var mc = ctx.GetMethodConfig();
            var lhsType = GetLocalOrParamType(lhs, ctx, mc);
            if (string.IsNullOrEmpty(lhsType))
                return ValueConstraint.NotApplicable;
            var rhsType = GetLocalOrParamType(rhs, ctx, mc);
            if (string.IsNullOrEmpty(rhs))
                return ValueConstraint.NotApplicable;

            _out.Write("/* _ufunc_helper expanded */ ");
            if (lhsType == "NDArray")
            {
                if (rhsType == "NDArray")
                    GenerateFanctor(args[2], ctx, lhs, rhs);
                else
                    GenerateFanctor(args[4], ctx, lhs, rhs);
            }
            else {
                if (rhsType == "NDArray")
                {
                    if (IsConstantNone(args[5]))
                        GenerateFanctor(args[4], ctx, rhs, lhs);
                    else
                        GenerateFanctor(args[5], ctx, rhs, lhs);
                }
                else
                    GenerateFanctor(args[3], ctx, lhs, rhs);
            }

            return ValueConstraint.Any;
        }
    }
}
