using UnityEngine;
using System.Collections;

public class BasicEnemy : Enemy {
	
	void Start () {
		totalHealth = 10f;
		currentHealth = totalHealth;
		speed = 3.5f;
		bounty = 2;

	}

}
