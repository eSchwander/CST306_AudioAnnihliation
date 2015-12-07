using UnityEngine;
using System.Collections;

public class BasicTowerBehavior : TowerBehavior {

	public Transform bulletTransform;
	public float shotDamage;
	public float shotDelay;
	public float time = Time.time;

	public GameObject target;

	// Use this for initialization
	void Start () {
		shotDamage = 10f;
		shotDelay = 1;
		target = null;
	}

	//fire bullet at enemy
	void fireBullet(Vector3 velocity, float speed, float size, float damage){
		Transform bulletProjectile = (Transform) Instantiate (bulletTransform, transform.position, Quaternion.identity);
		Rigidbody bulletProjectileRb = bulletProjectile.GetComponent<Rigidbody>();
		Physics.IgnoreCollision(bulletProjectile.GetComponent<Collider>(), GetComponent<Collider>());
		bulletProjectileRb.velocity = velocity*speed; // setting velocity is yet another way to make an object move
		//Debug.Log (bulletProjectileRb.velocity);
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Enemy" && target == null) {
			Debug.Log ("triggered");
			target = col.gameObject;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject == target) {
			target = null;
		}
	}

	// Update is called once per frame
	void Update () {
		/*
		if ((Time.time - time) > shotDelay) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			//this is your bullets direction
			//Vector3 bulletDirection = closestEnemy.transform.position-transform.position;
			Vector3 bulletDirection = enemies[0].transform.position-transform.position;
			fireBullet (bulletDirection, 3f, 2f, shotDamage);
			time = Time.time;
		}
		*/
		if ((Time.time - time) > shotDelay && target != null) {
			Vector3 bulletDirection = target.transform.position-transform.position;
			//Debug.Log(bulletDirection);
			fireBullet (bulletDirection, 3f, 2f, shotDamage);
			time = Time.time;
		}


	}
}
