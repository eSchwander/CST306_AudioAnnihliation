using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToScene(string sceneName){
		Debug.Log ("Pressed");
		Application.LoadLevel (sceneName);
	}
}
