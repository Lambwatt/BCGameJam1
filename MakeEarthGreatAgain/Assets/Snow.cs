using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {

	public float lifeTime;
	Atmosphere atmos;

	// Use this for initialization
	void Start () {
		atmos = FindObjectOfType<Atmosphere>();
		atmos.AddCloud("snow");
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime-= Time.deltaTime;
		if(lifeTime<=0){
			atmos.RemoveCloud("snow");
			Destroy(gameObject);
		}
	}
}
