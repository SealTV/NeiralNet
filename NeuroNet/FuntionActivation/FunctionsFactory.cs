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
                    return new ThresholdFunction();
                case ActivationFunctionType.Sigma:
                    return new SigmoidFunction(alpha);
                case ActivationFunctionType.SimpleTest:
                    return new BipolarSigmoidFunction();
                default:
                    throw new Exception("Unknown Activation Function Type");
            }
        }
    }
}
