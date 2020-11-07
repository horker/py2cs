using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Python2CSharp.JsonUtils;

namespace Python2CSharp
{
    public class GraphBuilder
    {
        private GraphBlock _entry;
        private GraphBlock _exit;

        private List<GraphBlock> _loopEntries;
        private List<GraphBlock> _loopExits;
        private List<List<GraphBlock>> _exceptionHandlers;

        public GraphBuilder()
        { }

        private GraphBlock CreateBlockAfter(GraphBlock before, string name)
        {
            var block = new GraphBlock(name);
            before.ConnectTo(block);
            return block;
        }

        private void EnterLoop(GraphBlock entry, GraphBlock exit)
        {
            _loopEntries.Add(entry);
            _loopExits.Add(exit);
        }

        private void ExitLoop()
        {
            _loopEntries.RemoveAt(_loopEntries.Count - 1);
            _loopExits.RemoveAt(_loopExits.Count - 1);
        }

        private void EnterTry(List<GraphBlock> handlers)
        {
            _exceptionHandlers.Add(handlers);
        }

        private void ExitTry()
        {
            _exceptionHandlers.RemoveAt(_exceptionHandlers.Count - 1);
        }

        private void Exit(GraphBlock current)
        {
            current.ConnectTo(_exit);
            current.Exited = true;
        }

        public Graph Build(JToken node)
        {
            _entry = new GraphBlock("entry");
            _exit = new GraphBlock("exit");
            _loopEntries = new List<GraphBlock>();
            _loopExits = new List<GraphBlock>();
            _exceptionHandlers = new List<List<GraphBlock>>();
            _exceptionHandlers.Add(new List<GraphBlock>(new[] { _exit }));

            var last = Build(node, _entry);
            last.ConnectTo(_exit);

            var graph = new Graph(_entry, _exit);

            File.WriteAllText(@"..\..\graph0.dot", graph.GetDotString());

            graph.CombineEmptyBlocks();

            File.WriteAllText(@"..\..\graph.dot", graph.GetDotString());

            graph.FillDominators();
            graph.FillIDoms();

            graph.FillDominantChildren();
            graph.FillDominanceFrontiers();

            File.WriteAllText(@"..\..\graph.txt", graph.GetGraphString());

            return graph;
        }

        private GraphBlock Build(JToken nodes, GraphBlock current)
        {
            foreach (var n in nodes)
            {
                if (n.Type != JTokenType.Object)
                    throw new ArgumentException("Attempt to add non-object node");

                var name = ObjectNameOf(n);
                switch (name)
                {
                    case "For": current = BuildFor(n, current); break;
                    case "While": current = BuildWhile(n, current); break;
                    case "If": current = BuildIf(n, current); break;
                    case "Raise": current = BuildRaise(n, current); break;
                    case "Try": current = BuildTry(n, current); break;
                    case "Break": current = BuildBreak(n, current); break;
                    case "Continue": current = BuildContinue(n, current); break;
                    case "Call": current = BuildCall(n, current); break;
                    default:
                        current.AddNode(n);
                        break;
                }

                if (current.Exited)
                    break;
            }

            return current;
        }

        public GraphBlock BuildFor(JToken node, GraphBlock current)
        {
            var id = current.Id;

            var entry = CreateBlockAfter(current, $"{id}:for_entry");
            entry.AddNode(node);
            _loopEntries.Add(entry);

            var exit = new GraphBlock($"{id}:for_exit");

            var body = CreateBlockAfter(entry, $"{id}:for_body");

            EnterLoop(entry, exit);
            body = Build(node["body"], body);
            ExitLoop();

            body.ConnectTo(entry);
            body.ConnectTo(exit);

            return exit;
        }

        public GraphBlock BuildWhile(JToken node, GraphBlock current)
        {
            var id = current.Id;

            var entry = CreateBlockAfter(current, $"{id}:while_entry");
            entry.AddNode(node);
            _loopEntries.Add(entry);

            var body = CreateBlockAfter(entry, $"{id}:while_body");
            var exit = new GraphBlock($"{id}:while_exit");

            EnterLoop(entry, exit);
            body = Build(node["body"], body);
            ExitLoop();

            body.ConnectTo(entry);
            body.ConnectTo(exit);

            return exit;
        }

        public GraphBlock BuildIf(JToken node, GraphBlock current)
        {
            var id = current.Id;

            current.AddNode(node);

            var body = CreateBlockAfter(current, $"{id}:if_body");
            body = Build(node["body"], body);

            if (node["orelse"].Count() == 0)
            {
                var array = (JArray)node["orelse"];
                array.Add(JToken.Parse("{ \"_Name\": \"Pass\" }"));
            }

            var orelse = CreateBlockAfter(current, $"{id}:if_orelse");
            orelse = Build(node["orelse"], orelse);

            var exit = new GraphBlock($"{id}:if_exit");

            body.ConnectTo(exit);
            orelse.ConnectTo(exit);

            return exit;
        }

        public GraphBlock BuildRaise(JToken node, GraphBlock current)
        {
            current.AddNode(node);
            foreach (var e in _exceptionHandlers.Last())
                current.ConnectTo(e);

            current.Exited = true;

            return current;
        }

        public GraphBlock BuildTry(JToken node, GraphBlock current)
        {
            var id = current.Id;

            var exit = new GraphBlock($"{id}:try_exit");
            var handlers = new List<GraphBlock>();
            foreach (var handler in node["handlers"])
            {
                var h = Build(handler["body"], new GraphBlock($"{id}:eh"));
                h.ConnectTo(exit);

                handlers.Add(h);
            }

            if (handlers.Count > 0)
                _exceptionHandlers.Add(handlers);

            if (node["finalbody"].Count() > 0)
                throw new NotImplementedException("finally");

            EnterTry(handlers);
            var body = Build(node["body"], current);
            ExitTry();

            if (!body.Exited)
            {
                body.ConnectTo(exit);
                return exit;
            }

            return null;
        }

        public GraphBlock BuildBreak(JToken node, GraphBlock current)
        {
            current.AddNode(node);
            Exit(_loopExits.Last());
            return null;
        }

        public GraphBlock BuildContinue(JToken node, GraphBlock current)
        {
            current.AddNode(node);
            Exit(_loopEntries.Last());
            return null;
        }

        public GraphBlock BuildCall(JToken node, GraphBlock current)
        {
            current.AddNode(node);

            foreach (var e in _exceptionHandlers.Last())
                current.ConnectTo(e);

            return CreateBlockAfter(current, "next_to_call");
        }
    }
}
