using System;
using NeuronNet.FunctionActivation;
using SimpleJSON;

namespace NeuronNet.Serialize
{
    public class Deserializer
    {
        public static NeuralNetwork DeserializeNet(string json)
        {
           
            JSONClass jsonClass = JSON.Parse(json).AsObject;

            double alpha = jsonClass[SerializeConfig.Alpha].AsFloat;
            ActivationFunctionType type = (ActivationFunctionType)jsonClass[SerializeConfig.ActivationFuncType].AsInt;

            JSONArray jsonArray = jsonClass[SerializeConfig.NeuronsInLayers].AsArray;
            int[] neuronsInLayers = new int[jsonArray.Count];
            for (int i = 0; i < neuronsInLayers.Length; i++)
            {
                neuronsInLayers[i] = jsonArray[i].AsInt;
            }

            JSONArray weighsJsonArray = jsonClass[SerializeConfig.Weights].AsArray;
            double[][][] weights = new double[weighsJsonArray.Count][][];
            for (int i = 0; i < weighsJsonArray.Count; i++)
            {
                JSONArray layers = weighsJsonArray[i].AsArray;
                weights[i] = new double[layers.Count][];
                for (int j = 0; j < layers.Count; j++)
                {
                    JSONArray neurons = layers[j].AsArray;
                    weights[i][j] = new double[neurons.Count];
                    for (int k = 0; k < neurons.Count; k++)
                    {
                        weights[i][j][k] = neurons[k].AsDouble;
                    }
                }
            }
            Console.WriteLine(neuronsInLayers);
            Console.WriteLine(type);
            Console.WriteLine(alpha);
            Console.WriteLine(weights.ToString());
            return new NeuralNetwork(neuronsInLayers, weights, type, alpha);
        }

        public static Example DeserializeExample(string json)
        {
            if (string.IsNullOrEmpty(json)) return null;
            Example example = new Example();
            JSONClass jsonClass = JSON.Parse(json).AsObject;
            JSONArray inputs = jsonClass[SerializeConfig.InputExampleValues].AsArray;
            example.InputValues = new double[inputs.Count];

            for (int i = 0; i < inputs.Count; i++)
            {
                example.InputValues[i] = inputs[i].AsFloat;
            }
            JSONArray outputs = jsonClass[SerializeConfig.OutputExampleValues].AsArray;
            example.OutputValues = new double[outputs.Count];

            for (int i = 0; i < outputs.Count; i++)
            {
                example.OutputValues[i] = outputs[i].AsFloat;
            }

            return example;
        }
    }
}
