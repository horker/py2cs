using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static Python2CSharp.JsonUtils;

namespace Python2CSharp
{
    class SsaConverter
    {
        private Graph _graph;
        private List<string> _variables;
        private HashSet<(string, GraphBlock)> _inserted;
        private Dictionary<string, Stack<int>> _countStacks;
        private Dictionary<string, int> _nextCounts;

        public SsaConverter()
        { }

        public void ConvertToSsa(Graph graph, IEnumerable<string> variables)
        {
            InsertPhiFunctions(graph, variables);
            RenameVariables(graph, variables);
        }

        private void InsertPhiFunctions(Graph graph, IEnumerable<string> variables)
        {
            var inserted = new HashSet<(GraphBlock, string)>();
            var enqueued = new HashSet<(GraphBlock, string)>();
            var queue = new Queue<GraphBlock>();

            foreach (var v in variables)
            {
                foreach (var block in graph.VisitBlocks())
                {
                    if (block.Variables.Contains(v))
                    {
                        queue.Enqueue(block);
                        enqueued.Add((block, v));
                    }
                }

                while (queue.Count > 0)
                {
                    var block = queue.Dequeue();
                    foreach (var df in block.DominanceFrontiers)
                    {
                        if (df == graph.Exit && graph.Exit.Nodes.Count == 0)
                            continue;

                        if (!inserted.Contains((df, v)))
                        {
                            var literal = "\"" + v + "\"";
                            var json = string.Format(_phiJson,
                                v,
                                string.Join(", ", Enumerable.Repeat(literal, df.InBlocks.Count)));
                            var newNode = JToken.Parse(json);
                            df.Nodes[0].AddBeforeSelf(newNode);
                            df.Nodes.Insert(0, newNode);
                            inserted.Add((df, v));

                            if (!enqueued.Contains((df, v)))
                            {
                                queue.Enqueue(df);
                                enqueued.Add((df, v));
                            }
                        }
                    }
                }
            }
        }

        private Dictionary<string, Stack<int>> Copy(Dictionary<string, Stack<int>> d)
        {
            var result = new Dictionary<string, Stack<int>>();
            foreach (var (k, v) in d)
                result[k] = new Stack<int>(v);

            return result;
        }

        private Dictionary<string, int> Copy(Dictionary<string, int> d)
        {
            return new Dictionary<string, int>(d);
        }

        private void CollectVariables(JToken node, string ctxType, List<JToken> output)
        {
            Debug.Assert(node.Type == JTokenType.Object);

            var objectName = ObjectNameOf(node);
            if (objectName == "Name" && node["ctx"]["_Name"].Value<string>() == ctxType)
            {
                var name = GetNameProperty(node, "id");
                name = Regex.Replace(name, @"_ssa\d+$", "");
                if (_variables.Contains(name))
                    output.Add(node);
            }

            if (objectName == "AugAssign" && ctxType == "Load" && node["rhs_target"] == null)
            {
                var rhsTarget = node["target"].DeepClone();
                rhsTarget["ctx"]["_Name"] = "Load";
                (node as JObject).Add("rhs_target", rhsTarget);
            }

            foreach (var n in node.Children())
                CollectVariablesSub(n, ctxType, output);
        }

        private void CollectVariablesSub(JToken node, string ctxType, List<JToken> output)
        {
            while (true)
            {
                if (node.Type == JTokenType.Property)
                {
                    var prop = (JProperty)node;
                    node = prop.Value;
                    continue;
                }
                if (node.Type == JTokenType.Object)
                {
                    var objectName = ObjectNameOf(node);
                    if (objectName == "body" || objectName == "orelse" || objectName == "handlers" || objectName == "finalbody")
                        return;

                    CollectVariables(node, ctxType, output);
                    return;
                }
                if (node.Type == JTokenType.Array)
                {
                    foreach (var n in node)
                        CollectVariablesSub(n, ctxType, output);
                    return;
                }

                break;
            }
        }

        private List<JToken> CollectVariableLoads(JToken node)
        {
            var output = new List<JToken>();
            CollectVariables(node, "Load", output);
            return output;
        }

        private List<JToken> CollectVariableStores(JToken node)
        {
            var output = new List<JToken>();
            CollectVariables(node, "Store", output);
            return output;
        }

        private void RenameVariables(Graph graph, IEnumerable<string> variables)
        {
            _graph = graph;
            _variables = new List<string>(variables);
            _inserted = new HashSet<(string, GraphBlock)>();

            _countStacks = new Dictionary<string, Stack<int>>();
            _nextCounts = new Dictionary<string, int>();
            foreach (var v in variables)
            {
                _countStacks[v] = new Stack<int>();
                _countStacks[v].Push(0);
                _nextCounts[v] = 1;
            }

            RenameVariables(_graph.Entry);
        }

        private static readonly string _phiJson = @"
            {{
                ""_Name"": ""Phi"",
                ""target"": {{
                    ""_Name"": ""Name"",
                    ""id"": ""'{0}'"",
                    ""ctx"": {{
                        ""_Name"": ""Store""
                    }}
                }},
                ""args"": [ {1} ]
            }}";

        private void RenameVariables(GraphBlock block)
        {
            var stackPushes = new List<string>();

            foreach (var node in block.Nodes)
            {
                var objectName = ObjectNameOf(node);

                // Rename variable references (except phi functions)

                if (objectName != "Phi")
                {
                    var refs = CollectVariableLoads(node);
                    foreach (var n in refs)
                    {
                        var name = GetNameProperty(n, "id");
                        name = Regex.Replace(name, @"_ssa\d+$", "");
                        var index = _countStacks[name].Peek();
                        if (index > 0)
                            n["id"] = $"'{name}_ssa{index}";
                    }
                }

                // Rename lhs variables

                if (objectName == "Assign" || objectName == "AugAssign" || objectName == "Phi")
                {
                    var lhs = CollectVariableStores(node);

                    foreach (var n in lhs)
                    {
                        var name = GetNameProperty(n, "id");
                        name = Regex.Replace(name, @"_ssa\d+$", "");
                        var index = _nextCounts[name];
                        if (index > 0)
                            n["id"] = $"'{name}_ssa{index}";
                        _countStacks[name].Push(index);
                        _nextCounts[name] = index + 1;
                        stackPushes.Add(name);
                    }
                }
            }

            // Rename variable references in phi functions

            foreach (var b in block.OutBlocks)
            {
                var argPos = b.InBlocks.IndexOf(block);
                foreach (var phi in b.Nodes.TakeWhile(x => ObjectNameOf(x) == "Phi"))
                {
                    var name = phi["args"][argPos].Value<string>();
                    name = Regex.Replace(name, @"_ssa\d+$", "");
                    var index = _countStacks[name].Peek();
                    if (index > 0)
                        phi["args"][argPos] = $"{name}_ssa{index}";
                    else
                        phi["args"][argPos] = name;
                }
            }

            // Process children

            foreach (var b in block.DominantChildren)
                RenameVariables(b);

            // Unstack values from _countStakcs

            foreach (var p in stackPushes)
                _countStacks[p].Pop();
        }
    }
}
