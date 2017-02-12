using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnow : MonoBehaviour {

	public CircleCollider2D collider;
	public GameObject snow;
	bool targetable = true;

	Camera camera;
	Inventory inv;

	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<Camera>();
		inv = FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButtonDown(0) && targetable){

			Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);

			if( collider.OverlapPoint( new Vector2( mouseWorldPosition.x, mouseWorldPosition.y) ) && inv.canShoot("water") ){
				Instantiate(snow, transform.position, Quaternion.identity);
			}
		}
	}
}
