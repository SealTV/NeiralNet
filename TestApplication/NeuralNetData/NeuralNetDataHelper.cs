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
        public NeuralNetwork Network;

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
                //Console.WriteLine(data);
                this.Network = Deserializer.DeserializeNet(data);
                stream.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                return;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

        public void SaveNeuralNet()
        {
            var data = Serializer.SerializeNet(this.Network);
            File.WriteAllText("NeuralNet.json", data, Encoding.Unicode);
        }
    }
}
