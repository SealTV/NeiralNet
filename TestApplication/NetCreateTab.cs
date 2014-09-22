using System;
using System.IO;
using System.Windows.Forms;

using NeuronNet;
using NeuronNet.FunctionActivation;
using NeuronNet.Serialize;
using TestApplication.NeuralNetData;

namespace TestApplication
{
    public class NetCreateTab
    {
        private NeuralNetwork neuronNet;

        public NeuralNetDataHelper NeuralNetDataHelper { get; set; }
        public TextBox AlphaValueTextBox { get; set; }
        public ComboBox ActivationFunckType { get; set; }
        public TextBox NeuronsInLayersTextBox { get; set; }
        public TextBox LayersCountTextBox { get; set; }

        public NetCreateTab(NeuralNetDataHelper neuralNetDataHelper)
        {
            this.NeuralNetDataHelper = neuralNetDataHelper;
            this.NeuralNetDataHelper.LoadNeuralNet();
            this.neuronNet = this.NeuralNetDataHelper.Network;
        }

        public void UpdateNetInfoFields()
        {
            LayersCountTextBox.Text = neuronNet.LayersCount.ToString();
            string result = string.Empty;
            if (neuronNet.LayersCount > 0)
            {
                for (int i = 0; i < neuronNet.LayersCount - 1; i++)
                {
                    result += neuronNet[i].NeuronsCount.ToString() + ',';
                }
                result += neuronNet[neuronNet.LayersCount - 1].NeuronsCount.ToString();
            }
            NeuronsInLayersTextBox.Text = result;
            ActivationFunckType.SelectedItem = this.neuronNet.Type;
            AlphaValueTextBox.Text = this.neuronNet.Alpha.ToString();
        }


        public void CreateNet()
        {
            int layersCount;
            int[] neuronsInLayer;
            double alpha;
            ActivationFunctionType activationFunctionType;
            try
            {
                layersCount = Int32.Parse(LayersCountTextBox.Text);
                neuronsInLayer = new int[layersCount];
                string[] values = NeuronsInLayersTextBox.Text.Split(',');
                if (values.Length != layersCount)
                    throw new InvalidDataException(string.Format("{0} layers count", values.Length));

                for (int i = 0; i < layersCount; i++)
                {
                    neuronsInLayer[i] = Int32.Parse(values[i]);
                }

                activationFunctionType = (ActivationFunctionType)ActivationFunckType.SelectedItem;
                string str = AlphaValueTextBox.Text.Replace('.', ',');
                alpha = double.Parse(str);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }

            neuronNet = new NeuralNetwork(neuronsInLayer, activationFunctionType, alpha);
            this.NeuralNetDataHelper.Network = neuronNet;
            this.NeuralNetDataHelper.SaveNeuralNet();

        }

        public void SetActive()
        {
            if (this.NeuralNetDataHelper.Network == null)
            {
                this.NeuralNetDataHelper.LoadNeuralNet();
            }
            this.UpdateNetInfoFields();
        }
    }
}
