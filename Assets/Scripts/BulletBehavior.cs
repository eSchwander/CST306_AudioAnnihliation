using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	private float timer = Time.time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timer > 1) {
			DestroyObject(gameObject);
		}
	}
}
