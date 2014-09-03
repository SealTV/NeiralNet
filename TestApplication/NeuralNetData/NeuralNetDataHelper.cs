using System;
using System.IO;
using System.Text;
using NeuronNet;
using NeuronNet.FunctionActivation;
using NeuronNet.Serialize;

namespace TestApplication.NeuralNetData
{
    public class NeuralNetDataHelper
    {
        public NeuralNetwork NET;

        public ActivationFunctionType ActivationFunctionType;
        public void LoadNeuralNet()
        {
            Stream stream = null;
            try
            {
                stream = File.OpenRead("NeuralNet.json");
                var reader = new StreamReader(stream, Encoding.Unicode);
                var data = reader.ReadToEnd();
                if (string.IsNullOrEmpty(data)) return;
                this.NET = Deserializer.DeserializeNet(data);
                stream.Close();
            }
            catch (Exception exc)
            {
                return;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

        public void SaveNeuralNet()
        {
            var data = Serializer.SerializeNet(this.NET);
            File.WriteAllText("NeuralNet.json", data, Encoding.Unicode);
        }
    }
}
