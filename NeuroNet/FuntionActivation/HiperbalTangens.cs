using System;

namespace NeuronNet.FunctionActivation
{
    class HiperbalTangens:IActivationFunction
    {
        private readonly double _alpha;

        public HiperbalTangens(double a)
        {
            _alpha = a;
        }

        public double GetValue(double value)
        {
            return (float) Math.Tanh(value/_alpha);
        }
    }
}
