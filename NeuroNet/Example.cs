using System.Linq;

namespace NeuronNet
{
    public class Example
    {
        public double[] InputValues;
        public double[] OutputValues;

        public override string ToString()
        {
            var toString = InputValues.Aggregate(string.Empty, (current, t) => current + (t + " "));
            toString += "    ";
            toString = OutputValues.Aggregate(toString, (current, t) => current + (t + " "));
            return toString;
        }
    }
}