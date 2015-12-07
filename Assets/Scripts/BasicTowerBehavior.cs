using UnityEngine;
using System.Collections;

public class BasicTowerBehavior : TowerBehavior {

	public Transform bulletTransform;
	public float shotDamage;
	public float shotDelay;
	public float time = Time.time;

	// Use this for initialization
	void Start () {
		shotDamage = 10f;
		shotDelay = 1;
	}

	//fire bullet at enemy
	void fireBullet(Vector3 velocity, float speed, float size, float damage){
		Transform bulletProjectile = (Transform) Instantiate (bulletTransform, transform.position, Quaternion.identity);
		Rigidbody bulletProjectileRb = bulletProjectile.GetComponent<Rigidbody>();
		bulletProjectileRb.velocity = velocity*speed; // setting velocity is yet another way to make an object move
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Enemy") {
			Debug.Log ("triggered");
			if ((Time.time - time) > shotDelay) {
				Vector3 bulletDirection = col.transform.position-transform.position;
				fireBullet (bulletDirection, 3f, 2f, shotDamage);
				time = Time.time;
			}
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


	}
}
