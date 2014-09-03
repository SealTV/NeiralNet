using System;
using System.Collections.Generic;
using System.Linq;
using NeuroNet.FuntionActivation;

namespace NeuroNet
{
    public class NeuralNetwork
    {
        public readonly ActivationFuncFactory Factory;
        public readonly List<Neuron> InputNeurons;
        public readonly List<Neuron> MiddleNeurons;
        public readonly List<Neuron> OutputsNeurons;

        public readonly List<Link> InputLinks;
        public readonly List<Link> OutputsLinks;
        public ActivationFuncTypeEnum Type;
        public float Alpha;
        private readonly Random _rnd = new Random();

        public NeuralNetwork()
        {
            Type = ActivationFuncTypeEnum.Sigma;
            Alpha = 0;
            Factory = new ActivationFuncFactory();
            InputNeurons = new List<Neuron>();
            InputLinks = new List<Link>();
            MiddleNeurons = new List<Neuron>();
            OutputsNeurons = new List<Neuron>();
            OutputsLinks = new List<Link>();
        }

        public NeuralNetwork(int inputLayer, int middleLayer, int outputLayer, ActivationFuncTypeEnum type, float alpha)
        {
            Type = type;
            Alpha = alpha;
            Factory=new ActivationFuncFactory();
            InputNeurons = new List<Neuron>();
            InputLinks = new List<Link>();
            MiddleNeurons = new List<Neuron>();
            OutputsNeurons = new List<Neuron>();
            OutputsLinks = new List<Link>();
            for (int i = 0; i < inputLayer; i++)
            {
                var link = new Link(1);
                InputLinks.Add(link);
                InputNeurons.Add(new Neuron(Factory.GetActivationFunc(type, alpha)));
                InputNeurons[InputNeurons.Count - 1].InputLinks.Add(link);
            }

            for (int i = 0; i < outputLayer; i++)
            {
                var link = new Link(1);
                OutputsLinks.Add(link);
                OutputsNeurons.Add(new Neuron(Factory.GetActivationFunc(type, alpha)));
                OutputsNeurons[OutputsNeurons.Count - 1].OutputLinks.Add(OutputsLinks[OutputsLinks.Count - 1]);
            }
            for (int i = 0; i < middleLayer; i++)
            {
                MiddleNeurons.Add(new Neuron(Factory.GetActivationFunc(type, alpha)));
                for (int j = 0; j < inputLayer; j++)
                {
                    var link = new Link((float)_rnd.NextDouble());
                    link.InputNeuron = InputNeurons[j];
                    link.OutputNeuron = MiddleNeurons[i];
                    MiddleNeurons[i].InputLinks.Add(link);
                    InputNeurons[j].OutputLinks.Add(link);
                }
                for (int j = 0; j < outputLayer; j++)
                {
                    var link = new Link((float)_rnd.NextDouble());
                    link.InputNeuron = MiddleNeurons[i];
                    link.OutputNeuron = OutputsNeurons[j];
                    MiddleNeurons[i].OutputLinks.Add(link);
                    OutputsNeurons[j].InputLinks.Add(link);
                }
            }

        }

        /// <summary>
        /// Return result of work NET.
        /// </summary>
        /// <param name="inputValues"></param>
        /// <returns></returns>
        public float[] NextStep(float[] inputValues)
        {
            if (inputValues.Length != InputLinks.Count)
            {
                throw new IndexOutOfRangeException("Incorrect Lenght of input array.");
            }
            for (int i = 0; i < inputValues.Length; i++)
            {
                InputLinks[i].Value = inputValues[i];
            }
            foreach (Neuron neuron in InputNeurons)
            {
                neuron.GetValuesFromInputLinks();
                neuron.SetValuesToOutputLinks();
            }
            foreach (Neuron neuron in MiddleNeurons)
            {
                neuron.GetValuesFromInputLinks();
                neuron.SetValuesToOutputLinks();
            }
            foreach (Neuron neuron in OutputsNeurons)
            {
                neuron.GetValuesFromInputLinks();
                neuron.SetValuesToOutputLinks();
            }
            var result = new float[OutputsLinks.Count];
            for (int i = 0; i < OutputsLinks.Count; i++)
            {
                result[i] = OutputsLinks[i].Value;
            }
            return result;
        }


        /// <summary>
        /// Method for learnin NET!
        /// </summary>
        /// <param name="example"></param>
        /// <param name="speedOfTrening"></param>
        public void CorrectNeuralNet(Example example, float speedOfTrening)
        {
            NextStep(example.InputValues);
            for (int i = 0; i < OutputsNeurons.Count; i++)
            {
                OutputsNeurons[i].Sigma = OutputsNeurons[i].GetRawValue() * (1 - OutputsNeurons[i].GetRawValue()) *
                                (example.OutputValues[i] - OutputsNeurons[i].GetRawValue());
                for (int j = 0; j < OutputsNeurons[i].InputLinks.Count; j++)
                {
                    OutputsNeurons[i].InputLinks[j].Weight += speedOfTrening * OutputsNeurons[i].Sigma *
                                                              MiddleNeurons[j].GetRawValue();
                }

            }
            foreach (var t in MiddleNeurons)
            {
                t.Sigma = t.GetRawValue() * (1 - t.GetRawValue()) * t.OutputLinks.Sum(link => (link.Weight * link.OutputNeuron.Sigma));
                foreach (var link in t.InputLinks)
                {
                    link.Weight += speedOfTrening * t.Sigma * link.InputNeuron.GetRawValue();
                }
            }
        }
    }
}
