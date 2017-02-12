using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvideCarbon : MonoBehaviour {

	public CircleCollider2D collider;
	public int carbonReturn;
	bool targetable = true;

	Camera camera;

	Inventory inv;

	// Use this for initialization
	void Start () {
		inv = FindObjectOfType<Inventory>();
		camera = FindObjectOfType<Camera>();
	}

	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButtonDown(0) && targetable){

			Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);

			if( collider.OverlapPoint( new Vector2( mouseWorldPosition.x, mouseWorldPosition.y) ) && inv.canShoot("carbon") ){
				//Instantiate(snow, transform.position, Quaternion.identity);
				inv.addCarbon(2);
			}
		}
	}
}
