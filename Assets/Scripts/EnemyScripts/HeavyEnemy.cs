using UnityEngine;
using System.Collections;

public class HeavyEnemy : Enemy {
	
	void Start () {
		totalHealth = 40f;
		currentHealth = totalHealth;
		speed = 3.5f;
		bounty = 10;
	}
}