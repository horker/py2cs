using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Python2CSharp
{

    public class Graph
    {
        public GraphBlock Entry { get; set; }
        public GraphBlock Exit { get; set; }
        public IEnumerable<GraphBlock> Blocks => VisitBlocks();

        public Graph(GraphBlock entry, GraphBlock exit)
        {
            Entry = entry;
            Exit = exit;
        }

        public IEnumerable<GraphBlock> VisitBlocks(GraphBlock start = null)
        {
            if (start == null)
                start = Entry;

            var visited = new HashSet<GraphBlock>();
            var stack = new Stack<GraphBlock>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var b = stack.Pop();
                if (visited.Contains(b))
                    continue;

                yield return b;

                visited.Add(b);
                foreach (var o in b.OutBlocks)
                    stack.Push(o);
            }
        }

        public IEnumerable<GraphBlock> ReverseVisitBlocks(GraphBlock start = null)
        {
            if (start == null)
                start = Exit;

            var visited = new HashSet<GraphBlock>();
            var stack = new Stack<GraphBlock>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var b = stack.Pop();
                if (visited.Contains(b))
                    continue;

                yield return b;

                visited.Add(b);
                foreach (var o in b.InBlocks)
                    stack.Push(o);
            }
        }

        public void CombineEmptyBlocks()
        {
            foreach (var b in VisitBlocks())
            {
                if (b.Nodes.Count != 0 || b == Exit)
                    continue;

                if (b.OutBlocks.Count == 1)
                {
                    var succ = b.OutBlocks[0];
                    succ.InBlocks.Remove(b);
                    foreach (var ib in b.InBlocks)
                    {
                        ib.OutBlocks.Remove(b);
                        ib.OutBlocks.Add(succ);
                        succ.InBlocks.Add(ib);
                    }
                }
                else if (b.InBlocks.Count == 1)
                {
                    var pred = b.InBlocks[0];
                    pred.OutBlocks.Remove(b);
                    foreach (var ob in b.OutBlocks)
                    {
                        ob.InBlocks.Remove(b);
                        ob.InBlocks.Add(pred);
                        pred.OutBlocks.Add(ob);
                    }
                }
            }
        }

        public void FillDominators()
        {
            var blocks = VisitBlocks().ToArray();
            Entry.Dominators.Add(Entry);
            foreach (var b in blocks)
            {
                if (b == Entry)
                    continue;
                foreach (var bb in blocks)
                    b.Dominators.Add(bb);
            }

            bool modified;
            do
            {
                modified = false;
                foreach (var b in blocks)
                {
                    var old = new List<GraphBlock>(b.Dominators);

                    if (b.InBlocks.Count >= 1)
                    {
                        b.Dominators = new HashSet<GraphBlock>(b.InBlocks[0].Dominators);
                        for (var i = 1; i < b.InBlocks.Count; ++i)
                            b.Dominators.IntersectWith(b.InBlocks[i].Dominators);
                        b.Dominators.Add(b);
                    }

                    if (!b.Dominators.SetEquals(old))
                        modified = true;
                }
            } while (modified);
        }

        public void FillIDoms()
        {
            var blocks = VisitBlocks().ToArray();
            foreach (var b in blocks)
            {
                var sd = b.Dominators.Except(new[] { b }).ToArray();

                foreach (var d in sd)
                {
                    if (d.Dominators.SetEquals(sd))
                    {
                        b.IDom = d;
                        break;
                    }
                }
            }
        }

        public void FillDominantChildren()
        {
            foreach (var b in VisitBlocks())
                b.IDom?.DominantChildren.Add(b);

            foreach (var b in VisitBlocks())
                b.DominantChildren.Sort();
        }

        public void FillDominanceFrontiers()
        {
            FillDominanceFrontiers(Entry);
        }

        public void FillDominanceFrontiers(GraphBlock block)
        {
            foreach (var b in block.OutBlocks)
            {
                if (b.IDom != block)
                    block.DominanceFrontiers.Add(b);
            }

            foreach (var b in block.DominantChildren)
            {
                FillDominanceFrontiers(b);
                foreach (var df in b.DominanceFrontiers)
                {
                    if (!df.Dominators.Contains(block))
                        block.DominanceFrontiers.Add(df);
                }
            }
        }

        public string GetGraphString()
        {
            var result = new StringBuilder();
            var visited = new HashSet<GraphBlock>();

            GetGraphString(Entry, 0, result, visited);

            return result.ToString();
        }

        private void GetGraphString(GraphBlock block, int indent, StringBuilder result, HashSet<GraphBlock> visited)
        {
            if (visited.Contains(block))
                return;
            visited.Add(block);

            result.Append(new string(' ', indent * 2));
            result.AppendLine(block.ToString());

            foreach (var b in block.OutBlocks)
                GetGraphString(b, indent + 1, result, visited);
        }

        public string GetDotString()
        {
            var result = new StringBuilder(@"
digraph {
");

            foreach (var b in VisitBlocks())
            {
                var lineNumber = b.Nodes.Count > 0 ? "\\nline=" + ((IJsonLineInfo)b.Nodes[0]).LineNumber : "";
                var variables = b.Variables.Count > 0 ? "\\n[" + string.Join(", ", b.Variables) + "]" : "";
                result.AppendLine($"_{b.Id} [label=\"Block {b.Id} ({b.Name}){lineNumber}{variables}\"];");
            }

            foreach (var b in VisitBlocks())
            {
                foreach (var o in b.OutBlocks)
                    result.AppendLine($"_{b.Id} -> _{o.Id}");
            }

            result.AppendLine("}");

            return result.ToString();
        }
    }
}
