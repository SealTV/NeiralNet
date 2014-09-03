using System.Collections.Generic;
using NeuroNet;
using NeuroNet.Serilaize;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelController : MonoBehaviour
    {

        public NeuralNetwork NeuralNetwork;
        public GameObject ChaserPrefab;
        public GameObject RunnerPrefab;
        public GameObject Runner;
        public List<GameObject> Chasers; 
        public string NetFile;
        public int ChasersCount;
        void Start ()
        {
            //NeuralNetwork=new NeuralNetwork(8,15,2,ActivationFuncTypeEnum.Sigma, 0.5f);
            NeuralNetwork = Deserilizer.DeserializeNet(Resources.Load<TextAsset>(NetFile).text);
            //Debug.Log(Resources.Load<TextAsset>(NetFile).text);
            //Debug.Log(Serializer.SerilaizeNet(NeuralNetwork));
            Runner = (GameObject)Instantiate(RunnerPrefab, new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f)), Quaternion.identity);
           
            RunnerController runController = Runner.AddComponent<RunnerController>();
            runController.Set(this);
            runController.NeuralNetwork = NeuralNetwork;

            for (int i = 0; i < ChasersCount; i++)
            {
                GameObject chaser =(GameObject)Instantiate(
                    ChaserPrefab, new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f)), Quaternion.identity);
                Chasers.Add(chaser);
                ChaserController controller = chaser.AddComponent<ChaserController>();
                controller.Set(this);
                controller.NeuralNetwork = NeuralNetwork; ;
            }

        }
	
        // Update is called once per frame
        void Update () {
	        
        }
    }
    
}
