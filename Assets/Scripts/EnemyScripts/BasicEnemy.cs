using UnityEngine;
using System.Collections;

public class BasicEnemy : Enemy {
	
	void Start () {
		totalHealth = 10f;
		currentHealth = totalHealth;
		speed = 5f;
		bounty = 2;

	}

}
