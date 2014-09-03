using System;
using System.IO;
using NeuronNet;
using NeuronNet.FunctionActivation;
using NeuronNet.Serialize;


namespace NeuralNetTest
{
    static class Program
    {
        private static void Main()
        {
            int[] arr1 = { 2, 8, 2 };
            NeuralNetwork testNet = new NeuralNetwork(arr1, ActivationFunctionType.Sigma, 0.4d);
            var stepValues = testNet.NextStep(new[] { 0.2d, 0.1d });
            foreach (var i in stepValues)
            {
                Console.WriteLine(i);
            }
            var str = Serializer.SerializeNet(testNet);
            Console.WriteLine(str);
            using (StreamWriter writer = new StreamWriter(File.Create("Output.json")))
            {
                writer.Write(str);
                writer.Close();
            }

            string str1 = string.Empty;
            using (StreamReader reader = new StreamReader(File.OpenRead("Output.json")))
            {
                var s = reader.ReadLine();
                reader.Close();
                var net = Deserializer.DeserializeNet(s);
                str1 = Serializer.SerializeNet(net);
            }

            using (StreamWriter writer = new StreamWriter(File.Open("Output.json", FileMode.Append)))
            {
                writer.WriteLine();
                writer.WriteLine();
                writer.Write(str1);
                writer.Close();
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(str1);
            Console.WriteLine();
            Console.WriteLine();


            Console.ReadKey();
        
        }
    }
}
