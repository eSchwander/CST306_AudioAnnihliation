using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public float speed;
	//public NavMeshAgent nav;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		//nav = GetComponent<NavMeshAgent>();
		//nav.enabled = true;
		//nav.SetDestination (GameObject.FindWithTag("EnemyGoal").transform.position);
		//Debug.Log ("in nav");
	}

	void Awake(){
		nav = GetComponent<NavMeshAgent>();
		nav.enabled = true;
		nav.SetDestination (GameObject.FindWithTag("EnemyGoal").transform.position);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
