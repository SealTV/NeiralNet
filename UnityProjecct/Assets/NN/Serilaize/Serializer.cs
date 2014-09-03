using SimpleJSON;

namespace NeuroNet.Serilaize
{
    public class Serializer
    {
        public static string SerilaizeNet(NeuralNetwork net)
        {
            JSONClass json = new JSONClass();
            json.Add(SerializeConfig.ActivationFuncType, new JSONData((int)net.Type));
            json.Add(SerializeConfig.Alpha, new JSONData(net.Alpha));
            json.Add(SerializeConfig.InputLayerNeuronsCount, new JSONData(net.InputNeurons.Count));
            json.Add(SerializeConfig.MiddleLayerNeuronsCount, new JSONData(net.MiddleNeurons.Count));
            json.Add(SerializeConfig.OutputLayerNeuronsCount, new JSONData(net.OutputsNeurons.Count));

            JSONArray firstList = new JSONArray();
            JSONArray seconList = new JSONArray();

            for (int i = 0; i < net.MiddleNeurons.Count; i++)
            {
                JSONArray firstLinks = new JSONArray();
                for (int j = 0; j < net.InputNeurons.Count; j++)
                {
                    firstLinks.Add(j.ToString(), new JSONData(net.InputNeurons[j].OutputLinks[i].Weight));
                }

                firstList.Add(i.ToString(), firstLinks);

                JSONArray secondLinks = new JSONArray();
                for (int j = 0; j < net.OutputsLinks.Count; j++)
                {
                    secondLinks.Add(j.ToString(), new JSONData(net.OutputsNeurons[j].InputLinks[i].Weight));
                }
                seconList.Add(i.ToString(), secondLinks);
            }

            json.Add(SerializeConfig.FirstLinkLayer, firstList);
            json.Add(SerializeConfig.SecondLinkLayer, seconList);
            return json.ToString("");
        }

        public static string SerializeExample(Example example)
        {
            JSONClass json = new JSONClass();
            JSONArray inputs = new JSONArray();
            for (int i = 0; i < example.InputValues.Length; i++)
            {
                inputs.Add(i.ToString(), new JSONData(example.InputValues[i]));
            }
            json.Add(SerializeConfig.InputExampleValues, inputs);

            JSONArray outputs = new JSONArray();
            for (int i = 0; i < example.OutputValues.Length; i++)
            {
                outputs.Add(i.ToString(), new JSONData(example.OutputValues[i]));
            }
            json.Add(SerializeConfig.OutputExampleValues, outputs);

            return json.ToString();
        }
    }
}
