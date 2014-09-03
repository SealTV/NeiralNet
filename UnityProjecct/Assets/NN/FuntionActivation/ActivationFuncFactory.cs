using System;

namespace NeuroNet.FuntionActivation
{
    public class ActivationFuncFactory
    {
        public IActivationFunc GetActivationFunc(ActivationFuncTypeEnum type, float alpha)
        {
            switch (type)
            {
                case ActivationFuncTypeEnum.HiberBallTangens:
                    return new HiperbalTangens(alpha);
                case ActivationFuncTypeEnum.Sigma:
                    return new Sigma(alpha);
                case ActivationFuncTypeEnum.SimpleTest:
                    return new SimpleTest();
                default:
                    throw new Exception("Unknown Activation Function Type");
            }
        }
    }
}
