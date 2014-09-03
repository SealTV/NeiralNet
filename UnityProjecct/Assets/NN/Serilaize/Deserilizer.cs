using NeuroNet.FuntionActivation;
using SimpleJSON;
using UnityEngine;

namespace NeuroNet.Serilaize
{
    public class Deserilizer
    {
        public static NeuralNetwork DeserializeNet(string json)
        {
            NeuralNetwork net = new NeuralNetwork();
            JSONClass jsonClass = JSON.Parse(json).AsObject;
            net.Alpha = jsonClass[SerializeConfig.Alpha].AsFloat;
            net.Type = (ActivationFuncTypeEnum) jsonClass[SerializeConfig.ActivationFuncType].AsInt;

            int inputCount = jsonClass[SerializeConfig.InputLayerNeuronsCount].AsInt;
            int midleCount = jsonClass[SerializeConfig.MiddleLayerNeuronsCount].AsInt;
            int outputCount = jsonClass[SerializeConfig.OutputLayerNeuronsCount].AsInt;

            ActivationFuncFactory factory = new ActivationFuncFactory();
            for (int i = 0; i < inputCount; i++)
            {
                Link link = new Link(1);
                net.InputLinks.Add(link);
                Neuron neuron = new Neuron(factory.GetActivationFunc(net.Type, net.Alpha));
                link.OutputNeuron = neuron;
                neuron.InputLinks.Add(link);
                net.InputNeurons.Add(neuron);
            }

            for (int i = 0; i < outputCount; i++)
            {
                Link link = new Link(1);
                net.OutputsLinks.Add(link);
                Neuron neuron = new Neuron(factory.GetActivationFunc(net.Type, net.Alpha));
                link.InputNeuron = neuron;
                neuron.OutputLinks.Add(link);
                net.OutputsNeurons.Add(neuron);
            }
            JSONArray firstList = jsonClass[SerializeConfig.FirstLinkLayer].AsArray;
            JSONArray secondList = jsonClass[SerializeConfig.SecondLinkLayer].AsArray;
           
            for (int i = 0; i < midleCount; i++)
            {
                Neuron neuron = new Neuron(factory.GetActivationFunc(net.Type, net.Alpha));


                JSONArray firstLinks = firstList[i].AsArray;
                for (int j = 0; j < inputCount; j++)
                {
                    float w = firstLinks[j].AsFloat;
                    Link link = new Link(w);
                    link.OutputNeuron = neuron;
                    link.InputNeuron = net.InputNeurons[j];
                    neuron.InputLinks.Add(link);
                    net.InputNeurons[j].OutputLinks.Add(link);
                }

                JSONArray secondLinks = secondList[i].AsArray;
                for (int j = 0; j < outputCount; j++)
                {
                    float w = secondLinks[j].AsFloat;
                    Link link = new Link(w);
                    link.OutputNeuron = net.OutputsNeurons[j];
                    link.InputNeuron = neuron;
                    neuron.OutputLinks.Add(link);
                    net.OutputsNeurons[j].InputLinks.Add(link);
                }

                net.MiddleNeurons.Add(neuron);
            }

            return net;
        }

        public static Example DeserializeExample(string json)
        {
            if (string.IsNullOrEmpty(json)) return null;
            Example example = new Example();
            JSONClass jsonClass = JSON.Parse(json).AsObject;
            JSONArray inputs = jsonClass[SerializeConfig.InputExampleValues].AsArray;
            example.InputValues = new float[inputs.Count];

            for (int i = 0; i < inputs.Count; i++)
            {
                example.InputValues[i] = inputs[i].AsFloat;
            }
            JSONArray outputs = jsonClass[SerializeConfig.OutputExampleValues].AsArray;
            example.OutputValues = new float[outputs.Count];

            for (int i = 0; i < outputs.Count; i++)
            {
                example.OutputValues[i] = outputs[i].AsFloat;
            }

            return example;
        }
    }
}
