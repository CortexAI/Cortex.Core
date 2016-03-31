using Cortex.Core.Model;

namespace Cortex.Core.Elements
{
    public abstract class ProcessorElement<TIn1, TIn2, TOut> : BaseElement
    {
        private readonly CachedInputPin<TIn1> _input1;
        private readonly CachedInputPin<TIn2> _input2;
        private readonly OutputPin<TOut> _output;

        protected ProcessorElement()
        {
            _output = new OutputPin<TOut>(typeof(TOut).Name);
            _input1 = new CachedInputPin<TIn1>(typeof (TIn1).Name, Handler1);
            _input2 = new CachedInputPin<TIn2>(typeof(TIn2).Name, Handler2);

            AddInputPin(_input1);
            AddInputPin(_input2);
            AddOutputPin(_output);
        }
        private void Handler1(IInputPin pin, TIn1 arg)
        {
            _output.Emit(ConcreteHandler(_input1.CachedValue, _input2.CachedValue));
        }

        private void Handler2(IInputPin pin, TIn2 arg)
        {
            _output.Emit(ConcreteHandler(_input1.CachedValue, _input2.CachedValue));
        }

        protected abstract TOut ConcreteHandler(TIn1 input1, TIn2 input2);
    }

    public abstract class ProcessorElement<TIn, TOut> : BaseElement
    {
        private readonly OutputPin<TOut> _output;

        protected ProcessorElement()
        {
            _output = new OutputPin<TOut>(typeof (TOut).Name);
            AddInputPin(new InputPin<TIn>(typeof(TIn).Name, Handler));
            AddOutputPin(_output);
        }

        private void Handler(IInputPin pin, TIn arg)
        {
            _output.Emit(ConcreteHandler(arg));
        }

        protected abstract TOut ConcreteHandler(TIn input);
    }
}