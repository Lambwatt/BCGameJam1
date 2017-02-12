using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	Vector3 dockPoint;
	Vector3 target;
	Cloud targetCloud;
	bool cloudContacted = false;

	public void init(Cloud cloud){
		targetCloud = cloud;
		target = cloud.transform.position;
		dockPoint = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if(target!=null){
			transform.position = Vector3.Lerp(transform.position, target, 1);

			if(Vector3.Distance(transform.position, target)<0.5f){

				if(cloudContacted){
					Destroy(gameObject);
				}else{
					targetCloud.destroyCloud();
					target = dockPoint;
					cloudContacted = true;
				}
			}
		}
	}
}
