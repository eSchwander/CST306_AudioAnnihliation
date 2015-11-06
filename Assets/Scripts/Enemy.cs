using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public float speed;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		nav.enabled = true;
		nav.SetDestination (GameObject.FindWithTag("EnemyGoal").transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
