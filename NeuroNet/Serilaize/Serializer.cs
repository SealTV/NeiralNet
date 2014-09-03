using SimpleJSON;

namespace NeuronNet.Serialize
{
    public class Serializer
    {
        public static string SerializeNet(NeuralNetwork net)
        {
            JSONClass json = new JSONClass
            {
                {SerializeConfig.ActivationFuncType, new JSONData((int) net.Type)},
                {SerializeConfig.Alpha, new JSONData(net.Alpha)},
            };

            JSONArray array = new JSONArray();
            for (int i = 0; i < net.Layers.Length; i++)
            {
                array.Add(i.ToString(), new JSONData(net.Layers[i].NeuronsCountInLayer));
            }
            json.Add(SerializeConfig.NeuronsInLayers, array);

            JSONArray weights = new JSONArray();
            for (int i = 0; i < net.Layers.Length; i++)
            {
                JSONArray layersArray = new JSONArray();
                for (int j = 0; j < net.Layers[i].NeuronsCountInLayer; j++)
                {
                    double[] neuronWeights = net.Layers[i].LayerNeurons[j].GetWeights();
                    JSONArray neuronsWeightsJsonArray = new JSONArray();
                    for (int k = 0; k < neuronWeights.Length; k++)
                    {
                        neuronsWeightsJsonArray.Add(k.ToString(), new JSONData(neuronWeights[i]));
                    }
                    layersArray.Add(j.ToString(), neuronsWeightsJsonArray);
                }
                weights.Add(i.ToString(), layersArray);
            }
            json.Add(SerializeConfig.Weights, weights);
            return json.ToString();
        }

        public static string SerializeExample(Example example)
        {
            JSONClass json = new JSONClass();
            JSONArray inputs = new JSONArray();
            for (int i = 0; i < example.InputValues.Length; i++)
            {
                inputs.Add(i.ToString(""), new JSONData(example.InputValues[i]));
            }
            json.Add(SerializeConfig.InputExampleValues, inputs);

            JSONArray outputs = new JSONArray();
            for (int i = 0; i < example.OutputValues.Length; i++)
            {
                outputs.Add(i.ToString(), new JSONData(example.OutputValues[i]));
            }
            json.Add(SerializeConfig.OutputExampleValues, outputs);

            return json.ToString();
        }
    }
}
