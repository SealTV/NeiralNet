using System;

namespace NeuronNet.FunctionActivation
{
    public class Sigma : IActivationFunction
    {
        private readonly double _alpha;

        public Sigma(double a)
        {
            _alpha = a;
        }
        public double GetValue(double value)
        {
            return (float) (1/(1+Math.Exp(-_alpha*value)));
        }
    }
}
