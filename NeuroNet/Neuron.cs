using System;
using System.Linq;

namespace NeuronNet
{
    public class Neuron
    {
        public Link[] InputLinks;

        /// <summary>
        /// Threshold value
        /// </summary>
        /// 
        /// <remarks>The value is added to inputs weighted sum.</remarks>
        /// 
        protected double threshold = 0.0f;

        public double Threshold
        {
            get { return this.threshold; }
            set { this.threshold = value; }
        }

        private readonly IActivationFunction activationFunction;
        private double rawValue;

        public double this[int index]
        {
            get { return InputLinks[index].Weight; }
            set { InputLinks[index].Weight = value; }
        }

        public IActivationFunction ActivationFunction
        {
            get { return this.activationFunction; }
        }
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
            result += threshold;
            return activationFunction.Function(result);
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
