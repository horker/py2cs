using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Python2CSharp.MXNet
{
    public class CTypesPointerHook : Generator, IHook
    {
        static private Dictionary<string, string> _typeMap = new Dictionary<string, string>()
        {
            { "c_char_p", "string" },
            { "c_int", "int" },
            { "c_uint", "int" },
            { "mx_int", "int" },
            { "mx_uint", "int" },
            { "NDArrayHandle", "NDArrayHandle" },
            { "ctypes.c_int", "int" },
            { "ctypes.c_int64", "long" },
            { "ctypes.c_char_p", "string" }
        };

        public CTypesPointerHook(Formatter @out, Config config)
            : base(@out, config)
        { }

        private string GetPointerString(JToken node)
        {
            var nodeName = ObjectNameOf(node);
            if (nodeName == "Name")
                return _typeMap[GetNameId(node)];
            else if (nodeName == "Attribute" && GetNameId(node["value"]) == "ctypes")
                return _typeMap[GetNameProperty(node, "attr")];

            if (nodeName == "Call" &&
                ObjectNameOf(node["func"]) == "Attribute" &&
                GetNameId(node["func"]["value"]) == "ctypes" &&
                GetNameProperty(node["func"], "attr") == "POINTER" &&
                node["args"].Count() == 1)
                return "List<" + GetPointerString(node["args"][0]) + ">";

            throw new ArgumentException("Unsupported ctypes.POINTER syntax");
        }

        private string GetClrTypeName(JToken node, Context ctx)
        {
            string type = null;
            if (ObjectNameOf(node) == "Name")
            {
                type = GetNameProperty(node, "id");
            }
            else if (ObjectNameOf(node) == "Attribute")
            {
                type = GetNameProperty(node["value"], "id") + "." + GetNameProperty(node, "attr");
            }

            return _typeMap[type];
        }

        public ValueConstraint TryGenerate(JToken node, Context ctx)
        {
            // p = ctypes.POINTER(ctypes.c_char_p)()

            if (!IsNone(node) &&
                ObjectNameOf(node) == "Call" &&
                IsNone(node["args"]) &&
                ObjectNameOf(node["func"]) == "Call" &&
                ObjectNameOf(node["func"]["func"]) == "Attribute" &&
                GetNameId(node["func"]["func"]["value"]) == "ctypes" &&
                GetNameProperty(node["func"]["func"], "attr") == "POINTER" &&
                node["func"]["args"].Count() == 1)
            {
                var type = GetPointerString(node["func"]);
                _out.Write($"new {type})");
                return ValueConstraint.Any;
            }

            // c_array(ctypes.cint64, data)

            if (!IsNone(node) &&
                ObjectNameOf(node) == "Call" &&
                GetNameId(node["func"]) == "c_array" &&
                node["args"].Count() == 2 &&
                (ObjectNameOf(node["args"][0]) == "Name" || (ObjectNameOf(node["args"][0]) == "Attribute" && ObjectNameOf(node["args"][0]["value"]) == "Name")))
            {
                GenerateExpression(node["args"][1], ctx);
                var type = GetClrTypeName(node["args"][0], ctx);
                _out.Write($".Cast<{type}>().ToArray()");
                return ValueConstraint.Any;
            }

            return ValueConstraint.NotApplicable;
        }
    }
}
