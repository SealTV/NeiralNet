using NeuronNet.FunctionActivation;

namespace NeuronNet
{
    public class NeuralNetwork
    {
        private readonly Layer[] layers;
        public ActivationFunctionType Type;
        public double Alpha;

        public int LayersCount { get { return layers.Length; }}
        public Layer this[int index]
        {
            get { return this.layers[index]; }
            set { this.layers[index] = value; }
        }

        public NeuralNetwork(int[] neuronsInLayers, ActivationFunctionType functionType, double alpha)
        {
            Alpha = alpha;

            layers = new Layer[neuronsInLayers.Length];
            for (int i = 0; i < neuronsInLayers.Length; i++)
            {
                LayerType layerType = LayerType.Middle;
                if (i == 0)
                {
                    layerType = LayerType.Input;
                    layers[i] = new Layer(layerType, neuronsInLayers[i], 1, functionType, alpha);
                    continue;
                }
                if (i == neuronsInLayers.Length - 1)
                {
                    layerType = LayerType.Output;
                }
                layers[i] = new Layer(layerType, neuronsInLayers[i], neuronsInLayers[i - 1], functionType, alpha);
            }
        }

        public NeuralNetwork(int[] neuronsInLayers, double[][][] weights, ActivationFunctionType functionType, double alpha)
        {
            Alpha = alpha;

            layers = new Layer[neuronsInLayers.Length];
            for (int i = 0; i < neuronsInLayers.Length; i++)
            {
                LayerType layerType = LayerType.Middle;
                if (i == 0)
                {
                    layerType = LayerType.Input;
                    layers[i] = new Layer(layerType, neuronsInLayers[i], weights[i], functionType, alpha);
                    continue;
                }
                if (i == neuronsInLayers.Length - 1)
                {
                    layerType = LayerType.Output;
                }
                layers[i] = new Layer(layerType, neuronsInLayers[i], weights[i], functionType, alpha);
            }
        }

        /// <summary>
        /// Return result of work NET.
        /// </summary>
        /// <param name="inputValues"></param>
        /// <returns></returns>
        public double[] NextStep(double[] inputValues)
        {
            var result = new double[0];
            return result;
        }
    }


}
