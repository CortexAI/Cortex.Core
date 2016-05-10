using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core.Nodes.Util
{
    internal class Defenitions
    {
        [Export] 
        public static NodeGroupDefenition DebugNodes = 
            new NodeGroupDefenition(WellKnownGroups.Common, "Debug");

        [Export] 
        public static NodeDefenition DebugLog =
            new NodeDefenition<DebugLog>(DebugNodes, "Debug log", null, "Logs to visual studio debug output");

        [Export] 
        public static NodeDefenition SleepElement =
            new NodeDefenition<Sleep>(DebugNodes, "Sleep", null, "Thread sleep");
    }
}