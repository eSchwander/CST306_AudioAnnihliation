using UnityEngine;
using System.Collections;

public class BasicEnemy : Enemy {

	// Use this for initialization
	void Start () {
		health = 10;
		speed = 5;

	}

	/*//destroy enemy and incremend on collision with goal
	void OnCollisionEnter(Collider collision)
	{
		Debug.Log ("collided with something");
		if(collision.gameObject.tag == "EnemyGoal")
		{
			DestroyObject(collision.gameObject);
		}
	}*/
	
	/*
	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance(GameObject.FindWithTag("EnemyGoal").transform.position, transform.position);
		//Debug.Log (distance);
		if (health <= 0f) {
			DestroyObject(gameObject);
		}
	}
	*/
}
