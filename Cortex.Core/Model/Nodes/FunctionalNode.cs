using System;
using Cortex.Core.Model.Pins;

namespace Cortex.Core.Model.Nodes
{
    public class FunctionalNode<TIn1, TIn2, TOut> : BaseNode
    {
        private readonly Func<TIn1, TIn2, TOut> _func;
        private readonly IInputPin<TIn1> _input1;
        private readonly IInputPin<TIn2> _input2;
        private readonly IOutputPin<TOut> _output;

        public FunctionalNode(Func<TIn1, TIn2, TOut> func)
        {
            _func = func;
            _input1 = new InputPin<TIn1>("Input 1");
            _input2 = new InputPin<TIn2>("Input 2");
            _output = new OutputPin<TOut>("Output");

            AddInputPin(_input1);
            AddInputPin(_input2);
            AddOutputPin(_output);
        }

        protected override void Handler()
        {
            _output.Emit(_func.Invoke(_input1.Take(), _input2.Take()));
        }
    }

    public class FunctionalNode<TIn, TOut> : BaseNode
    {
        private readonly Func<TIn, TOut> _func;
        private readonly IInputPin<TIn> _input;
        private readonly IOutputPin<TOut> _output;

        public FunctionalNode(Func<TIn, TOut> func)
        {
            _func = func;
            _input = new InputPin<TIn>("Input");
            _output = new OutputPin<TOut>("Output");

            AddInputPin(_input);
            AddOutputPin(_output);
        }

        protected override void Handler()
        {
            _output.Emit(_func.Invoke(_input.Take()));
        }
    }
}