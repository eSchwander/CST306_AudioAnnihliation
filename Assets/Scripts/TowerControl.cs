using UnityEngine;
using System.Collections;

public class TowerControl : MonoBehaviour {

	//RaycastHit myHit = new RaycastHit();
	//Ray myRay = new Ray();
	RaycastHit hit;
	Ray mouseRay;
	public GameObject hitPlane;
	public bool selected;
	private Light myLight;
	private float selectionRadius;

	// Use this for initialization
	void Start () {
		selected = false;
		selectionRadius = 5;
		myLight = GetComponent<Light>();
		myLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			//ray click detection
			mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(mouseRay, out hit)){
				if (hit.collider.tag.Equals("HitPlane")){
					var distance = Vector3.Distance(new Vector3(hit.point.x,0f,hit.point.z), transform.position);
					if (distance < selectionRadius){
						selected = true;
						myLight.enabled = true;
						//Debug.Log(transform.position.x + " " + transform.position.z);
					} else {
						selected = false;
						myLight.enabled = false;
					}
				}
			}
		}
		//create 
	}
}
