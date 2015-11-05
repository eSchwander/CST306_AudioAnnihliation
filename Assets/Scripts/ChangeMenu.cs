using UnityEngine;
using System.Collections;

public class ChangeMenu : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject PlayMenu;
	public GameObject OptionMenu;

	private GameObject ActiveMenu;

	// Use this for initialization
	void Start () {
		ActiveMenu = MainMenu;
		MainMenu.SetActive (true);
		PlayMenu.SetActive (false);
		OptionMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

}
