using System;
using NeuronNet.FunctionActivation;

namespace NeuronNet
{
    public class Layer
    {
        public Neuron[] LayerNeurons;
        public int NeuronsCountInLayer
        {
            get {
                if (LayerNeurons == null)
                {
                    LayerNeurons = new Neuron[0];
                }
                return LayerNeurons.Length;
            }
        }

        private LayerType LayerType;

        public Layer(LayerType layerType, int neuronsCount, int intputLinksCount, ActivationFunctionType functionType, double alpha)
        {
            LayerType = layerType;
            LayerNeurons = new Neuron[neuronsCount];

            double[][] linksWeight = GenerateRandomWeights(neuronsCount, intputLinksCount);

            for (int i = 0; i < neuronsCount; i++)
            {
                LayerNeurons[i] = new Neuron(FunctionsFactory.GetActivationFunc(functionType, alpha));
                LayerNeurons[i].InputLinks = new Link[intputLinksCount];
                for (int j = 0; j < intputLinksCount; j++)
                {
                    LayerNeurons[i].InputLinks[j] = new Link(linksWeight[i][j]);
                }
            }
        }


        public Layer(LayerType layerType, int neuronsCount, double[][] linksWeight, ActivationFunctionType functionType, double alpha)
        {
            LayerType = layerType;
            LayerNeurons = new Neuron[neuronsCount];
            for (int i = 0; i < neuronsCount; i++)
            {
                LayerNeurons[i] = new Neuron(FunctionsFactory.GetActivationFunc(functionType, alpha));
                LayerNeurons[i].InputLinks = new Link[linksWeight[i].Length];

                for (int j = 0; j < linksWeight[i].Length; j++)
                {
                    LayerNeurons[i].InputLinks[j] = new Link(linksWeight[i][j]);
                }
            }
        }
        private double[][] GenerateRandomWeights(int neuronsCount, int inputCount)
        {
            Console.WriteLine(neuronsCount + "   " + inputCount);
            double[][] result = new double[neuronsCount][];
            Random random = new Random();
            for (int i = 0; i < neuronsCount; i++)
            {
                result[i] = new double[inputCount];
                for (int j = 0; j < inputCount; j++)
                {
                    result[i][j] = LayerType == LayerType.Input ? 1 : random.NextDouble();
                }
            }
            return result;
        }

        public void SetInputVector(double[] vector)
        {
            if (LayerType == LayerType.Input)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    LayerNeurons[i].SetInputVector(new []{vector[i]});
                }
            }
            else
            {
                foreach (Neuron layerNeuron in LayerNeurons)
                {
                    layerNeuron.SetInputVector(vector);
                }
            }
        }

        public double[] GetResultVector()
        {
            double[] resultVector = new double[LayerNeurons.Length];
            for (int i = 0; i < resultVector.Length; i++)
            {
                resultVector[i] = LayerNeurons[i].GetResutValue();
            }
            return resultVector;
        }
    }

    public enum LayerType
    {
        Input, Middle, Output
    }
}
