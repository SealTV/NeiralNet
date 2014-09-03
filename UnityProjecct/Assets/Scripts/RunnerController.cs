using System;
using System.CodeDom;
using Assets.Scripts;
using NeuroNet;
using UnityEngine;

namespace Assets
{
    public class RunnerController : MonoBehaviour
    {
        public float radius;
        public NeuralNetwork NeuralNetwork;

        private Vector3 speed;
        private LevelController levelController;
        private float pi2;
        public float maxSpeed = 10f;
        public float[] OUT;
        public float[] IN;
        public void Set(LevelController levelController)
        {
            this.levelController = levelController;
        }
        // Use this for initialization
        void Start()
        {
            speed = new Vector3();
            pi2 = Mathf.PI * 2;
            radius = 100;
        }

        // Update is called once per frame
        void Update()
        {
            float[] inputParams = new []{1f,1f,1f,1f,1f,1f,1f,1f};
            foreach (var chaser in levelController.Chasers)
            {
                Vector3 direction = chaser.transform.position - transform.position;
                if (direction.magnitude < radius)
                {
                    int i = (int)(Vector3.Angle(direction, Vector3.right) * 8f /360f);
                    if (inputParams[i] > direction.magnitude / radius)
                    {
                        inputParams[i] = direction.magnitude / radius;
                    }
                }
            }

            float[] outputParams = NeuralNetwork.NextStep(inputParams);
            OUT = outputParams;
            IN = inputParams;
            //speed += new Vector3(Mathf.Cos(pi2 * outputParams[1]), 0, Mathf.Sin(pi2 * outputParams[1]))*outputParams[0]*maxSpeed;
            //transform.position += speed;
            transform.position += new Vector3(Mathf.Cos(pi2 * outputParams[1]), 0, Mathf.Sin(pi2 * outputParams[1])) * outputParams[0] * maxSpeed*Time.deltaTime;
        }
    }
}
