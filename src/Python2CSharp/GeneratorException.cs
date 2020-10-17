using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Python2CSharp
{
    public class GeneratorException : Exception
    {
        public JToken Node { get; private set; }
        public Context Context { get; private set; }

        public GeneratorException(JToken node, Context ctx, string message, Exception innerException = null)
            : base($"{(node as IJsonLineInfo).LineNumber}:{(node as IJsonLineInfo).LinePosition}: ${message}", innerException)
        {
            Node = node;
            Context = ctx;
        }
    }
}
