using System;

namespace NeuroNet.FuntionActivation
{
    class HiperbalTangens:IActivationFunc
    {
        private readonly float _alpha;

        public HiperbalTangens(float a)
        {
            _alpha = a;
        }

        public float ActivationFunc(float value)
        {
            return (float) Math.Tanh(value/_alpha);
        }
    }
}
