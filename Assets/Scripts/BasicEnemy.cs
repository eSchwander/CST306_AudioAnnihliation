using UnityEngine;
using System.Collections;

public class BasicEnemy : Enemy {
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		health = 100f;
		speed = 20f;
		bounty = 2;
		nav = GetComponent<NavMeshAgent>();
	}

	void awake(){
		nav.speed = speed;
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
