using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public static string pathToSelectedSong = null;

	// Would be used to set path if it was ever used
	public void setPath(string path){
		pathToSelectedSong = path;
	}
	
	// Changes to play scene
	public void goToScene(string sceneName){
		Debug.Log ("Pressed Start");
		Application.LoadLevel (sceneName);
	}

	// quits game
	public void quitGame(){
		Debug.Log ("Pressed Quit");
		Application.Quit ();
	}
}
