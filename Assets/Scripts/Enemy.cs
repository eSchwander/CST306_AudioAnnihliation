using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

	public float health;
	public float speed;
	public int bounty;
	//public NavMeshAgent nav;
	NavMeshAgent nav;


	void Start () {
		//nav = GetComponent<NavMeshAgent>();
		//nav.enabled = true;
		//nav.SetDestination (GameObject.FindWithTag("EnemyGoal").transform.position);
		//Debug.Log ("in nav");
	}

	void Awake(){
		nav = GetComponent<NavMeshAgent>();
		//nav.enabled = true;
		//nav.SetDestination (GameObject.FindWithTag("EnemyGoal").transform.position);
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Bullet")
			health -= 1;
	}

	// Update is called once per frame
	void Update () {
		if (nav.Equals (null)) {
			nav = GetComponent<NavMeshAgent>();
		}
		else if (nav.enabled.Equals (false)) {
			nav.enabled = true;
			nav.speed = speed;
			nav.acceleration = 50f;
			nav.angularSpeed = 120f;
		} 
		else {
			nav.SetDestination (GameObject.FindWithTag ("EnemyGoal").transform.position);
		}
		var distance = Vector3.Distance(GameObject.FindWithTag("EnemyGoal").transform.position, transform.position);
		//Debug.Log (distance);
		if (distance < 5f || health <= 0f) {
			//Debug.Log (distance);
			DestroyObject(gameObject);
		}

	}

	public void loseHealth(int dam){
		health -= dam;
	}

}
