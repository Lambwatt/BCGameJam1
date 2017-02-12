using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

	public Cloud[] gases;
	public float radius;
	public int initialClouds;


	float timeToNextCloud;


	// Use this for initialization
	void Start () {
		for(int i = 0; i<initialClouds; i++){
			spawnCloud();
		}

		//timeToNextCloud = Random.Range(.25, 1);
		InvokeRepeating("spawnCloud", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void spawnMultipleClouds(){
//		int numClouds = s
//	}

	void spawnCloud(){
		float angle = Random.Range(0,360);
		float magnitude = Random.Range(0, radius);

		Vector3 newPos = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up * magnitude + new Vector3(0, 0, -1);

		Instantiate(gases[Random.Range(0, gases.Length)], newPos, Quaternion.identity);
	}
}
