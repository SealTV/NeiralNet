using System;

namespace NeuroNet.FuntionActivation
{
    public class Sigma : IActivationFunc
    {
        private readonly float _alpha;

        public Sigma(float a)
        {
            _alpha = a;
        }
        public float ActivationFunc(float value)
        {
            return (float) (1/(1+Math.Exp(-_alpha*value)));
        }
    }
}
