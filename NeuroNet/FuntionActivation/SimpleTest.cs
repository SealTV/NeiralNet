namespace NeuronNet.FunctionActivation
{
    public class SimpleTest : IActivationFunction
    {
        public double GetValue(double value)
        {
            return 1/(1+value);
        }
    }
}
