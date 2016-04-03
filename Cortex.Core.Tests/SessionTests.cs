using Cortex.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using Cortex.Core.Model;
using Cortex.Core.Nodes.Types;
using Cortex.Core.Tests.Utilities;

namespace Cortex.Core.Tests
{
    [TestClass()]
    public class SessionTests
    {
        [TestMethod()]
        public void SessionIsRunningTest()
        {
            var source = new NetTypeNode<object>(new object());
            var delay = new Delay(5000);

            var graph = new ProcessGraph();
            graph.AddElement(source);
            graph.AddElement(delay);
            graph.AddConnection(new Connection(source, source.Output, delay, delay.Inputs.First()));

            var session = new Session(graph);
            Assert.IsFalse(session.IsRunning);
            session.Start();
            Thread.Sleep(1000);
            Assert.IsTrue(session.IsRunning);
            Thread.Sleep(1000);
            session.Stop();
            Thread.Sleep(1000);
            Assert.IsFalse(session.IsRunning);
        }

        [TestMethod()]
        public void StartTest()
        {
            Assert.Fail();
        }
    }
}