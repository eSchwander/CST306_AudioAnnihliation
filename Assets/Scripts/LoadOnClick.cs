using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public static string pathToSelectedSong;
	
	public void setPath(string path){
		pathToSelectedSong = path;
	}

	public void goToScene(string sceneName){
		Debug.Log ("Pressed Start");
		Application.LoadLevel (sceneName);
	}

	public void quitGame(){
		Debug.Log ("Pressed Quit");
		Application.Quit ();
	}
}
