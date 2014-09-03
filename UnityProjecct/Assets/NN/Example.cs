using System.Linq;

namespace NeuroNet
{
    public class Example
    {
        public float[] InputValues;
        public float[] OutputValues;

        public override string ToString()
        {
            var toString = InputValues.Aggregate(string.Empty, (current, t) => current + (t + " "));
            toString += "    ";
            toString = OutputValues.Aggregate(toString, (current, t) => current + (t + " "));
            return toString;
        }
    }
}