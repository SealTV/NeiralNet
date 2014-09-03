using Assets.Scripts;
using NeuroNet;
using UnityEngine;
using System.Collections;

public class ChaserController : MonoBehaviour {


    public float radius;
    public NeuralNetwork NeuralNetwork;
    private float maxSpeed = 10;
    private Vector3 speed;
    private LevelController levelController;
    private float pi2;

    public void Set(LevelController levelController)
    {
        this.levelController = levelController;
    }

    void Start()
    {
        speed = new Vector3();
        pi2 = Mathf.PI * 2;
        radius = 50;
    }


	

	void Update () {
        float[] inputParams = new[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };
            Vector3 direction = levelController.Runner.transform.position - transform.position;
            if (direction.magnitude < radius)
            {
                int i = (int)(Vector3.Angle(direction, Vector3.right) * 8f / 360f);
                if (inputParams[i] > direction.magnitude / radius)
                {
                    inputParams[i] = direction.magnitude / radius;
                }
            }


        float[] outputParams = NeuralNetwork.NextStep(inputParams);
        //speed += new Vector3(Mathf.Cos(pi2 * outputParams[1]), 0, Mathf.Sin(pi2 * outputParams[1]))*outputParams[0]*maxSpeed;
        //transform.position += speed;
        transform.position -= new Vector3(Mathf.Cos(pi2 * outputParams[1]), 0, Mathf.Sin(pi2 * outputParams[1])) * outputParams[0] * maxSpeed * Time.deltaTime;
	}
}
