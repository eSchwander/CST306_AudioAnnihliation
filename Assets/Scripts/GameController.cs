using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject TowerPositionParent;
	Transform newPosition;
	public Transform enemySpawnPosition;
	public GameObject EnemyParent;
	public float sizeMultiplyer = 10;

	public float spawnTime = 1f;
	public float spawnRate = 5f;

	private float Timer;

	// Use this for initialization
	void Start () {
		Timer = Time.time;

		//fill TowerPositionParent object with tower positions
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++){
				//create object
				GameObject TowerPositionChild = (GameObject)Instantiate(Resources.Load("TowerPosition"));
				TowerPositionChild.transform.parent = TowerPositionParent.transform;
				TowerPositionChild.transform.position = new Vector3(i*sizeMultiplyer,0f,j*sizeMultiplyer);
			}
		}

	}

	//spawn individual enemies
	void SpawnWave(){
		GameObject enemyChild = (GameObject)Instantiate(Resources.Load("BasicEnemy"));
		//enemyChild.transform.parent = EnemyParent.transform;
		enemyChild.transform.position = enemySpawnPosition.position;
	}
	
	// Update is called once per frame
	void Update () {
		//create enemies
		if (Timer < Time.time) {
			SpawnWave();
			Timer = Time.time + spawnRate;
		}
	}
}
