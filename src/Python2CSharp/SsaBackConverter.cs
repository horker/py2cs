using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Core.Tokens;
using static Python2CSharp.JsonUtils;

namespace Python2CSharp
{
    public class SsaBackConverter
    {
        private static readonly string _json = @"
            {{
              ""_Name"": ""Assign"",
              ""targets"": [
                {{
                  ""_Name"": ""Name"",
                  ""id"": ""'{0}'"",
                  ""ctx"": {{
                    ""_Name"": ""Store""
                  }}
                }}
              ],
              ""value"": {{
                ""_Name"": ""Name"",
                ""id"": ""'{1}'"",
                ""ctx"": {{
                  ""_Name"": ""Load""
                }}
              }},
              ""type_comment"": ""None""
            }}
";

        public static void ConvertFromSsa(Graph graph)
        {
            foreach (var block in graph.VisitBlocks())
            {
                for (var i = 0; i < block.Nodes.Count && ObjectNameOf(block.Nodes[i]) == "Phi"; ++i)
                {
                    var node = block.Nodes[i];
                    var lhs = GetNameProperty(node["target"], "id");
                    var rhs = node["args"].Select(x => (string)x).ToArray();
                    for (var j = 0; j < block.InBlocks.Count; ++j)
                    {
                        var json = string.Format(_json, lhs, rhs[j]);
                        var newNode = JToken.Parse(json);
                        var n = block.InBlocks[j].Nodes;
                        n[n.Count - 1].AddAfterSelf(newNode);
                    }

                    node.Remove();
                }
            }

        }
    }
}
