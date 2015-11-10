using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Song{
	private string path;
	private string title;

	public Song(string path){
		this.path = path;
		this.title = parseTitle (path);
	}

	private string parseTitle(string path){
		char[] delimiters = {'/', '.'};

		string[] temp = path.Split (delimiters);
		string toReturn = temp [4];
		//Debug.Log (temp[4].ToString());
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

public class CreateScrollList : MonoBehaviour {

	public GameObject songButton;
	public Transform contentPanel;
	public string[] itemList;
	public List<Song> songList;

	// Use this for initialization
	void Start () {
		//Debug.Log (Directory.GetCurrentDirectory ());
		//PopulateList ();
	}

	public void PopulateList(){
		if (songList.Count == 0) {
			itemList = Directory.GetFiles ("./Assets/Music/", "*.mp3");
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
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
