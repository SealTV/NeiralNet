using NeuronNet.FunctionActivation;

namespace NeuronNet
{
    public class NeuralNetwork
    {
        public Layer[] Layers;
        public ActivationFunctionType Type;
        public double Alpha;
        private ActivationFunctionType activationFunctionType;

        public NeuralNetwork(int[] neuronsInLayers, ActivationFunctionType functionType, double alpha)
        {
            activationFunctionType = functionType;
            Alpha = alpha;

            Layers = new Layer[neuronsInLayers.Length];
            for (int i = 0; i < neuronsInLayers.Length; i++)
            {
                LayerType layerType = LayerType.Middle;
                if (i == 0)
                {
                    layerType = LayerType.Input;
                    Layers[i] = new Layer(layerType, neuronsInLayers[i], 1, functionType, alpha);
                    continue;
                }
                if (i == neuronsInLayers.Length - 1)
                {
                    layerType = LayerType.Output;
                }
                Layers[i] = new Layer(layerType, neuronsInLayers[i], neuronsInLayers[i - 1], functionType, alpha);
            }
        }

        public NeuralNetwork(int[] neuronsInLayers, double[][][] weights, ActivationFunctionType functionType, double alpha)
        {
            activationFunctionType = functionType;
            Alpha = alpha;

            Layers = new Layer[neuronsInLayers.Length];
            for (int i = 0; i < neuronsInLayers.Length; i++)
            {
                LayerType layerType = LayerType.Middle;
                if (i == 0)
                {
                    layerType = LayerType.Input;
                    Layers[i] = new Layer(layerType, neuronsInLayers[i], weights[i], functionType, alpha);
                    continue;
                }
                if (i == neuronsInLayers.Length - 1)
                {
                    layerType = LayerType.Output;
                }
                Layers[i] = new Layer(layerType, neuronsInLayers[i], weights[i], functionType, alpha);
            }
        }

        /// <summary>
        /// Return result of work NET.
        /// </summary>
        /// <param name="inputValues"></param>
        /// <returns></returns>
        public double[] NextStep(double[] inputValues)
        {
            //if (inputValues.Length != InputLinks.Count)
            //{
            //    throw new IndexOutOfRangeException("Incorrect Lenght of input array.");
            //}
            //for (int i = 0; i < inputValues.Length; i++)
            //{
            //    InputLinks[i].Value = inputValues[i];
            //}
            //foreach (Neuron neuron in InputNeurons)
            //{
            //    neuron.GetValuesFromInputLinks();
            //    neuron.SetValuesToOutputLinks();
            //}
            //foreach (Neuron neuron in MiddleNeurons)
            //{
            //    neuron.GetValuesFromInputLinks();
            //    neuron.SetValuesToOutputLinks();
            //}
            //foreach (Neuron neuron in OutputsNeurons)
            //{
            //    neuron.GetValuesFromInputLinks();
            //    neuron.SetValuesToOutputLinks();
            //}
            var result = new double[0];
            //for (int i = 0; i < OutputsLinks.Count; i++)
            //{
            //    result[i] = OutputsLinks[i].Value;
            //}
            return result;
        }

        public void BackPropagation(Example example, double learningSpeed, int count)
        {
            //for (int i = 0; i < count; i++)
            //{
            //    NextStep(example.InputValues);
            //    //delta _k = o_k(1 - o_k)(t_k - o_k).
            //    for (int j = 0; j < OutputsNeurons.Count; j++)
            //    {
            //        var k = OutputsNeurons[j].GetRawValue();
            //        OutputsNeurons[j].Sigma = k * (1 - k) * (example.OutputValues[j] - k);
            //    }
            //}
        }

        public void TeachNeuronNet(Example example, double speed)
        {
            throw new System.NotImplementedException();
        }
    }


}
