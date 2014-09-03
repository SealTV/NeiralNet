using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NeuronNet;
using NeuronNet.Serialize;

namespace TestApplication.ExamplesData
{
    public class ExamplesDataHelper
    {
        public List<Example> Examples = new List<Example>();
        public void LoadExamples()
        {
            Stream stream = null;
            try
            {
                stream = File.OpenRead("Examples.json");
                var reader = new StreamReader(stream);

                Examples = new List<Example>();
                while (!reader.EndOfStream)
                {
                    var data = reader.ReadLine();
                    if (string.IsNullOrEmpty(data)) continue;
                    var e = Deserializer.DeserializeExample(data);
                    Examples.Add(e);
                }
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

        public void SaveExamples()
        {
            var strings = new string[Examples.Count];
            var i = 0;
            foreach (var st in Examples.Select(Serializer.SerializeExample))
            {
                strings[i++] = st;
            }
            File.WriteAllLines("Examples.json", strings);
        }
    }
}
