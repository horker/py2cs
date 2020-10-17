using System;
using System.Collections.Generic;
using System.Text;

namespace Python2CSharp
{
    public class ValueConstraint
    {
        public string Type { get; }

        private static readonly ValueConstraint _any = new ValueConstraint(null);
        public static ValueConstraint Any => _any;
        public bool IsAny() => Type == null;

        private static readonly ValueConstraint _bool = new ValueConstraint("bool");
        public static ValueConstraint Bool => _bool;
        public bool IsBool() => Type == "bool";

        private static readonly ValueConstraint _string = new ValueConstraint("string");
        public static ValueConstraint String => _string;
        public bool IsString() => Type == "string";

        public ValueConstraint(string type)
        {
            Type = type;
        }
    }
}
