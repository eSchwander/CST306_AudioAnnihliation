using UnityEngine;
using System.Collections;

public class PositionControl : MonoBehaviour {

	//RaycastHit myHit = new RaycastHit();
	//Ray myRay = new Ray();
	RaycastHit hit;
	Ray mouseRay;
	GameObject hitPlane;
	GameObject towerParent;
	public bool selected;
	private Light myLight;
	private float selectionRadius;

	// Use this for initialization
	void Start () {
		selected = false;
		selectionRadius = 5;
		myLight = GetComponent<Light>();
		myLight.enabled = false;

		//set GameObjects
		hitPlane = GameObject.Find("HitPlane");  
		towerParent = GameObject.Find("TowerParent");
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

						//instantiate new tower object if you have the money for it
						MoneyManager moneyMan = MoneyManager.getInstance();
						if(moneyMan.getMoney() >= 5){ //5 is the basic tower cost. This should be shifted over to a var at some point
							GameObject towerChild = (GameObject)Instantiate(Resources.Load("BasicTower"));
							towerChild.transform.parent = towerParent.transform;
							towerChild.transform.position = transform.position;
							moneyMan.spendMoney(5);
						}
						//Debug.Log(transform.position.x + " " + transform.position.z);
					} else {
						selected = false;
						myLight.enabled = false;
					}
				}
			}
		}
	}
}
