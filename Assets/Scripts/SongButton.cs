using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This class is used for button creation on the song selection menu.
//Also sets the the global song path variable at some point
public class SongButton : MonoBehaviour {

	public Button button;
	public Text title;
	string path;

	public void setPath(string path){
		this.path = path;
	}

	public void selectedSong(){
		LoadOnClick.pathToSelectedSong = this.path;
		Debug.Log (LoadOnClick.pathToSelectedSong.ToString());
	}

}
