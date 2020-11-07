using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Python2CSharp
{
    public static class VariableRenamer
    {
        public static void RenameVariables(JToken node, IEnumerable<string> variables)
        {
            var builder = new GraphBuilder();
            var graph = builder.Build(node);

            var conv = new SsaConverter();
            conv.ConvertToSsa(graph, variables);
            SsaBackConverter.ConvertFromSsa(graph);
        }
    }
}
