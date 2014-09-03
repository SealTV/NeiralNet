namespace NeuroNet.FuntionActivation
{
    public class SimpleTest : IActivationFunc
    {
        public float ActivationFunc(float value)
        {
            return 1/(1+value);
        }
    }
}
