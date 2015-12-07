using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	private float timer = Time.time;
	private Enemy target;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy") {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - timer > 1) {
			DestroyObject(gameObject);
		}
	}
}
