using UnityEngine;
using System.Collections;

public class TowerControl : MonoBehaviour {

	//RaycastHit myHit = new RaycastHit();
	//Ray myRay = new Ray();
	RaycastHit hit;
	Ray mouseRay;
	public GameObject hitPlane;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			//ray click detection
			mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mouseRay, out hit)){
				if (hit.collider.tag.Equals("HitPlane")){
					//Debug.Log ("hit: " + hit.point.x);
					var distance = Vector3.Distance(new Vector3(hit.point.x,0f,hit.point.z), transform.position);
					if (distance < 0.5){
						Debug.Log(transform.position.x + " " + transform.position.z);
					}
				}
			}
		}
		//create 
	}
}
