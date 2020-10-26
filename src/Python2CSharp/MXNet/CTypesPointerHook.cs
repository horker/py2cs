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
            { "NDArrayHandle", "NDArrayHandle" }
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

        public ValueConstraint TryGenerate(JToken node, Context ctx)
        {
            // p = ctypes.POINTER(ctypes.c_char_p)()

            if (IsNone(node) ||
                ObjectNameOf(node) != "Call" ||
                !IsNone(node["args"]) ||
                ObjectNameOf(node["func"]) != "Call" ||
                ObjectNameOf(node["func"]["func"]) != "Attribute" ||
                GetNameId(node["func"]["func"]["value"]) != "ctypes" ||
                GetNameProperty(node["func"]["func"], "attr") != "POINTER" ||
                node["func"]["args"].Count() != 1)
                return ValueConstraint.NotApplicable;

            var type = GetPointerString(node["func"]);
            _out.Write($"new {type})");

            return ValueConstraint.Any;
        }
    }
}
