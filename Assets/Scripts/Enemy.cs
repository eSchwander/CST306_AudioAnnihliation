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

	/*//destory enemy and incremend on collision with goal
	void OnColliderHit(Collider collision)
	{
		Debug.Log ("collided with something");
		if(collision.gameObject.tag == "EnemyGoal")
		{
			DestroyObject(collision.gameObject);
		}
	}*/

	// Update is called once per frame
	void Update () {
		var distance = Vector3.Distance(GameObject.FindWithTag("EnemyGoal").transform.position, transform.position);
		Debug.Log (distance);
		if (distance < 50) {
			Debug.Log (distance);
			DestroyObject(gameObject);
		}
	}
}
