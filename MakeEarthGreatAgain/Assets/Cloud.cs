using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public CircleCollider2D collider;
	public string gasType;

	Camera camera;
	Atmosphere atmos;
	Inventory inv;
	bool targetable = true;


	void Start(){
		camera = FindObjectOfType<Camera>();
		atmos = FindObjectOfType<Atmosphere>();

		atmos.AddCloud(gasType);
		inv = FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!targetable){
			inv.launchRobot(gasType);
			Destroy(gameObject);
		}
		
		if( Input.GetMouseButtonDown(0) && targetable){

			Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);

			if( collider.OverlapPoint( new Vector2( mouseWorldPosition.x, mouseWorldPosition.y) ) && inv.canShoot(gasType) ){
//				inv.createRobot(this);
//				targetable = false;

				destroyCloud();
				
			}
		}
			
	}

	public void destroyCloud(){
		atmos.RemoveCloud(gasType);
		targetable = false;
	}
}
