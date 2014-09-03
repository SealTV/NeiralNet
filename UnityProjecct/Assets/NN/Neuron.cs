using System.Collections.Generic;

namespace NeuroNet
{
    public class Neuron
    {
        public readonly List<Link> InputLinks;
        public readonly List<Link> OutputLinks;

        private readonly IActivationFunc _exemplar;

        private float _rawValue;

        public float Sigma { get; set; }

        public Neuron(IActivationFunc activationFunc)
        {
            _exemplar = activationFunc;
            _rawValue = 0;
            InputLinks = new List<Link>();
            OutputLinks = new List<Link>();
        }

        public float GetRawValue()
        {
            return _exemplar.ActivationFunc(_rawValue);
        }
        public float GetValuesFromInputLinks()
        {
            _rawValue = 0;
            foreach (Link link in InputLinks)
            {
                _rawValue += link.Value;
            }
            return _rawValue;
        }

        public void SetValuesToOutputLinks()
        {
            foreach (Link link in OutputLinks)
            {
                link.Value = _exemplar.ActivationFunc(_rawValue);
            }
        }

        public void AddInputLink(Link link)
        {
            InputLinks.Add(link);
        }

        public void AddOutputLink(Link link)
        {
            OutputLinks.Add(link);
        }


    }
    
    public delegate float ActivationFunc(float value);
}
