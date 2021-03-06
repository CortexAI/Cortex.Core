﻿using System;
using System.Linq;
using Cortex.Core.Model;
using Cortex.Core.Nodes.Logic;
using Cortex.Core.Nodes.Types;
using Cortex.Core.Nodes.Util;

namespace Cortex.Core.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var source1 = new NetTypeNode<int>(10);
            var source2 = new NetTypeNode<int>(20);
            var add = new Addition();
            var log = new DebugLog();

            var c1 = new Connection(source1, source1.Output, add, add.A);
            var c2 = new Connection(source2, source2.Output, add, add.B);
            var c3 = new Connection(add, add.Outputs.First(), log, log.Inputs.First());

            var graph = new ProcessGraph();
            graph.AddElement(source1);
            graph.AddElement(source2);
            graph.AddElement(add);
            graph.AddElement(log);
            graph.AddConnection(c1);
            graph.AddConnection(c2);
            graph.AddConnection(c3);

            var session = new Session(graph);
            session.Start();*/
            
            var source = new NetTypeNode<int>(100);
            var repeat = new Repeat();
            var log = new DebugLog();

            var graph = new ProcessGraph();
            graph.AddElement(source);
            graph.AddElement(repeat);
            graph.AddElement(log);
            graph.AddConnection(new Connection(source, source.Output, repeat, repeat.Inputs.First()));
            graph.AddConnection(new Connection(repeat, repeat.Outputs.First(), log, log.Inputs.First()));

            var session = new Session(graph);
            session.Start();

            Console.ReadKey();
        }
    }
}
