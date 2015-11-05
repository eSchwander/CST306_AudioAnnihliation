using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject TowerPositionParent;
	Transform newPosition;
	public float sizeMultiplyer = 10;

	// Use this for initialization
	void Start () {
		//fill TowerPositionParent object with tower positions
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++){
				//create object
				GameObject TowerPositionChild = (GameObject)Instantiate(Resources.Load("TowerPosition"));
				TowerPositionChild.transform.parent = TowerPositionParent.transform;
				TowerPositionChild.transform.position = new Vector3(i*sizeMultiplyer,0f,j*sizeMultiplyer);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
