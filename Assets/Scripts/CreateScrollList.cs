using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//This class holds the title and path of songs
[System.Serializable]
public class Song{
	private string path;
	private string title;

	public Song(string path){
		this.path = parsePath(path);
		this.title = parseTitle (path);
	}

	private string parsePath(string path){
		char[] delimiters = {'/', '.'};
		string[] temp = path.Split (delimiters);
		string toReturn = temp [4] + "/" + temp [5];
		Debug.Log (toReturn);
		return(toReturn);
	}

	private string parseTitle(string path){
		char[] delimiters = {'/', '.'};

		string[] temp = path.Split (delimiters);
		string toReturn = temp [5];
		//Debug.Log (temp[5].ToString());
		//Debug.Log (path);
		return(toReturn);
	}

	public string getPath(){
		return(path);
	}

	public string getTitle(){
		return(title);
	}
}

//Used to populate the scroll list in song selection
public class CreateScrollList : MonoBehaviour {

	public GameObject songButton;
	public Transform contentPanel;
	public string[] itemList;
	public List<Song> songList;

	//Populates song selection menu if it is empty
	public void PopulateList(){
		if (songList.Count == 0) {
			itemList = Directory.GetFiles ("./Assets/Resources/Music/", "*.mp3");
			foreach (string x in itemList) {
				songList.Add (new Song (x));
				//Debug.Log (x);
			}
			foreach (Song item in songList) {
				GameObject newButton = Instantiate (songButton) as GameObject;
				SongButton newSongButton = newButton.GetComponent<SongButton> ();
				newSongButton.title.text = item.getTitle ();
				newSongButton.setPath (item.getPath ());
				newButton.transform.SetParent (contentPanel);
				newButton.transform.localScale = new Vector3(1f,1f,1f);
			}
		}
	}


}
