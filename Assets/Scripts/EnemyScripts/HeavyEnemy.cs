using UnityEngine;
using System.Collections;

public class HeavyEnemy : Enemy {
	
	void Start () {
		totalHealth = 40f;
		currentHealth = totalHealth;
		speed = 2.5f;
		bounty = 10;
	}
}