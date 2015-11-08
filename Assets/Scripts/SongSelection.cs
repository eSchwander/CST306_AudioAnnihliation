using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class SongSelection : MonoBehaviour {
	string [] songs;
	string assestsPath;

	// Use this for initialization
	void Start () {

		assestsPath = Application.dataPath;
		songs = Directory.GetFiles(assestsPath + "\\Music", "*.mp3");

		foreach (string path in songs)
			Debug.Log (path);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
