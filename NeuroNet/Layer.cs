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

        public Layer(LayerType layerType, int neuronsCount, int intputlinkCount, ActivationFunctionType functionType, double alpha)
        {
            LayerType = layerType;
            LayerNeurons = new Neuron[neuronsCount];

            double[][] linksWeight = GenerateRandomWeights(neuronsCount, intputlinkCount);

            for (int i = 0; i < neuronsCount; i++)
            {
                LayerNeurons[i] = new Neuron(FunctionsFactory.GetActivationFunc(functionType, alpha));
                LayerNeurons[i].InputLinks = new Link[linksWeight.Length];
                for (int j = 0; j < intputlinkCount; j++)
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
                LayerNeurons[i].InputLinks = new Link[linksWeight.GetLength(1)];
                for (int j = 0; j < linksWeight.GetLength(1); j++)
                {
                    LayerNeurons[i].InputLinks[j] = new Link(linksWeight[i][j]);
                }
            }
        }
        private double[][] GenerateRandomWeights(int neuronsCount, int inputCount)
        {
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
