using System;

namespace NeuronNet.FunctionActivation
{
    public class FunctionsFactory
    {
        public static IActivationFunction GetActivationFunc(ActivationFunctionType type, double alpha)
        {
            switch (type)
            {
                case ActivationFunctionType.HiberBallTangens:
                    return new HiperbalTangens(alpha);
                case ActivationFunctionType.Sigma:
                    return new Sigma(alpha);
                case ActivationFunctionType.SimpleTest:
                    return new SimpleTest();
                default:
                    throw new Exception("Unknown Activation Function Type");
            }
        }
    }
}
