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

            double[] tempResult = new double[layers[0].NeuronsCount];
            for (int i = 0; i < inputValues.Length; i++)
            {
                layers[0][i].SetInputVector(new []{inputValues[i]});
                tempResult[i] = layers[0][i].GetResutValue();

            }
            for (int i = 1; i < LayersCount; i++)
            {
                double[] tempResult2 = new double[layers[i].NeuronsCount];
                for (int j = 0; j < layers[i].NeuronsCount; j++)
                {
                    layers[i][j].SetInputVector(tempResult);
                    tempResult2[j] = layers[i][j].GetResutValue();
                }
                tempResult = tempResult2;
            }
            return tempResult;
        }
    }


}
