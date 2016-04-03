using System.ComponentModel.Composition;
using Cortex.Core.Model;

namespace Cortex.Core
{
    public class WellKnownGroups
    {
        [Export]
        public static NodeGroupDefenition Common = new NodeGroupDefenition("Common");
        
        [Export]
        public static NodeGroupDefenition MachineLearning = new NodeGroupDefenition("Machine Learning");

        [Export]
        public static NodeGroupDefenition Statistics = new NodeGroupDefenition("Statistics");

        [Export]
        public static NodeGroupDefenition Imaging = new NodeGroupDefenition("Imaging");

        [Export]
        public static NodeGroupDefenition SignalProcessing = new NodeGroupDefenition("Signal Processing");

        [Export]
        public static NodeGroupDefenition Plugins = new NodeGroupDefenition("Plugins");
    }
}
