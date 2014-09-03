namespace NeuroNet
{
    public class Link
    {

        private float _weight;
        private float _value;
        public Neuron InputNeuron;
        public Neuron OutputNeuron;

        
        public float Value
        {
            get { return _value * _weight; }
            set { _value = value; }
        }

        public float Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }


        public Link(float w)
        {
            _weight = w;
        }

    }
}
