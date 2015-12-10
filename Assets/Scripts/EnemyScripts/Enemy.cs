using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

	public float totalHealth;
	public float currentHealth;
	public float speed;
	public int bounty;

	//public NavMeshAgent nav;
	NavMeshAgent nav;
	Renderer rend;

	void Start () {
		//nav = GetComponent<NavMeshAgent>();
		//nav.enabled = true;
		//nav.SetDestination (GameObject.FindWithTag("EnemyGoal").transform.position);
		//Debug.Log ("in nav");
	}

	void Awake(){
		nav = GetComponent<NavMeshAgent>();
		rend = GetComponent<Renderer> ();
		rend.material.color = new Color(1f,0f,0f);

		//nav.speed = speed;
		//nav.enabled = true;
		//nav.SetDestination (GameObject.FindWithTag("EnemyGoal").transform.position);
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Bullet")
			currentHealth -= 1;
	}

	// Update is called once per frame
	void Update () {

		if (nav.Equals (null)) {
			nav = GetComponent<NavMeshAgent>();
			nav.enabled = false;
		}
		else if (nav.enabled.Equals (false)) {
			Debug.Log ("EnablingMesh");
			nav.enabled = true;
			nav.speed = speed;
			nav.acceleration = 50f;
			nav.angularSpeed = 120f;
			nav.radius = 1f;
			Debug.Log ("Destination Set");
			nav.SetDestination (GameObject.FindWithTag ("EnemyGoal").transform.position);

		}
		var distance = Vector3.Distance(GameObject.FindWithTag("EnemyGoal").transform.position, transform.position);
		//Debug.Log (distance);
		if (distance < 10f || currentHealth <= 0f) {
			//Debug.Log (distance);
			//Death grants the player the enemy's bounty
			MoneyManager moneyMan = MoneyManager.getInstance();
			moneyMan.gainMoney(bounty);
			DestroyObject(gameObject);
		}

	}

	public void loseHealth(int dam){
		currentHealth -= dam;
	}

}
