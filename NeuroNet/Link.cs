namespace NeuronNet
{
    public class Link
    {
        public double Value { get; set; }

        public double Weight { get; set; }

          
        public Link(double weight)
        {
            Weight = weight;
        }


        public double GetResultValue()
        {
            return Value*Weight;
        }
    }
}
