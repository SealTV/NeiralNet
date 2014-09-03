using System;
using System.Linq;

namespace NeuronNet
{
    public class Neuron
    {
        public Link[] InputLinks;

        private readonly IActivationFunction activationFunction;
        private double rawValue;


        public Neuron(IActivationFunction activationFunction)
        {
            this.activationFunction = activationFunction;
            rawValue = 0;
            InputLinks = new Link[0];
        }

        public double[] GetWeights()
        {
            double[] result = new double[InputLinks.Length];
            for (int i = 0; i < InputLinks.Length; i++)
            {
                result[i] = InputLinks[i].Weight;
            }
            return result;
        }

        public void SetInputVector(double[] vector)
        {
            if (vector.Length != InputLinks.Length)
                throw new IndexOutOfRangeException();
            for (int i = 0; i < vector.Length; i++)
            {
                InputLinks[i].Value = vector[i];
            }
        }

        public double GetResutValue()
        {
            double result = InputLinks.Sum(inputLink => inputLink.GetResultValue());
            return activationFunction.GetValue(result);
        }

        public double GetValuesFromInputLinks()
        {
            rawValue = 0;
            foreach (Link link in InputLinks)
            {
                rawValue += link.Value;
            }
            return rawValue;
        }
    }

}
