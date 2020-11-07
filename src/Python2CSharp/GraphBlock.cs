using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Python2CSharp.JsonUtils;

namespace Python2CSharp
{
    public class GraphBlock : IComparable<GraphBlock>
    {
        private static int _nextId = 0;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<JToken> Nodes { get; private set; }
        public List<GraphBlock> InBlocks { get; private set; }
        public List<GraphBlock> OutBlocks { get; private set; }
        public GraphBlock IDom { get; internal set; }
        public HashSet<GraphBlock> Dominators { get; internal set; }
        public List<GraphBlock> DominantChildren { get; internal set; }
        public HashSet<GraphBlock> DominanceFrontiers { get; internal set; }

        private List<string> _variables;
        public List<string> Variables
        {
            get
            {
                CollectVariables();
                return _variables;
            }
        }

        public bool Exited { get; set; }

        public GraphBlock(string name = "")
        {
            Id = _nextId++;
            Name = name;
            Nodes = new List<JToken>();
            InBlocks = new List<GraphBlock>();
            OutBlocks = new List<GraphBlock>();
            IDom = null;
            Dominators = new HashSet<GraphBlock>();
            DominantChildren = new List<GraphBlock>();
            DominanceFrontiers = new HashSet<GraphBlock>();
        }

        public int CompareTo([AllowNull] GraphBlock other)
        {
            return Id - other.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is GraphBlock b && Id == b.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public void AddNode(JToken node)
        {
            if (node.Type != JTokenType.Object)
                throw new ArgumentException("Attemp to add non-object node");
            Nodes.Add(node);
        }

        public void ConnectTo(GraphBlock to)
        {
            if (Exited || OutBlocks.Contains(to))
                return;

            OutBlocks.Add(to);
            to.InBlocks.Add(this);
        }

        private void CollectVariables()
        {
            if (_variables != null)
                return;

            _variables = new List<string>();

            foreach (var node in Nodes)
            {
                var objectName = ObjectNameOf(node);
                IEnumerable<JToken> targets = null;
                if (objectName == "Assign")
                    targets = node["targets"];
                else if (objectName == "AugAssign")
                    targets = new[] { node["target"] };
                else
                    continue;

                foreach (var target in targets)
                {
                    if (ObjectNameOf(target) == "Name")
                        _variables.Add(GetNameProperty(target, "id"));
                    if (ObjectNameOf(target) == "Tuple")
                    {
                        foreach (var t in target["elts"])
                        {
                            if (ObjectNameOf(t) == "Name")
                                _variables.Add(GetNameProperty(t, "id"));
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            var inBlocks = string.Join(", ", InBlocks.Select(x => x.Id));
            var outBlocks = string.Join(", ", OutBlocks.Select(x => x.Id));
            var idom = IDom == null ? "null" : IDom.Id.ToString();
            var doms = string.Join(", ", Dominators.Select(x => x.Id));
            var children = string.Join(", ", DominantChildren.Select(x => x.Id));
            var df = string.Join(", ", DominanceFrontiers.Select(x => x.Id));
            var variables = string.Join(", ", Variables);

            return $"Block {Id} ({Name}): nodes={Nodes.Count}, exited={Exited}, in=({inBlocks}), out=({outBlocks}), idom={idom}, doms=({doms}), domchildren=({children}), df=({df}), variables=({variables})";
        }

        public string ToNodesString()
        {
            return string.Join("\n", Nodes.Select((x, i) => $"[Node {i}]\n " + x.ToString()));
        }
    }
}
