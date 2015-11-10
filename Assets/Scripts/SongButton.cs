using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
