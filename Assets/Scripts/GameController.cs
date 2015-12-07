using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour, AudioProcessor.AudioCallbacks {

	public GameObject TowerPositionParent;
	Transform newPosition;
	public Transform enemySpawnPosition;
	public GameObject EnemyParent;
	public float sizeMultiplyer = 10;
	
	public float spawnRate = 0.1f;
	private float Timer;
	private float spawnTime;

	public float health;
	public float difficulty;

	bool startMusic = false;

	// Use this for initialization
	void Start () {
		Timer = Time.time;
		spawnTime = Time.time;
		health = 100;
		difficulty = 1;

		//fill TowerPositionParent object with tower positions
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++){
				//create object
				GameObject TowerPositionChild = (GameObject)Instantiate(Resources.Load("TowerPosition"));
				TowerPositionChild.transform.parent = TowerPositionParent.transform;
				TowerPositionChild.transform.position = new Vector3(i*sizeMultiplyer,0f,j*sizeMultiplyer);
			}
		}
		Debug.Log (LoadOnClick.pathToSelectedSong);
		//Start the music
		AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = Resources.Load(LoadOnClick.pathToSelectedSong) as AudioClip;
		audioSource.Play();
	}

	public void onOnbeatDetected()
	{

		//Debug.Log ("spawn");
		if ((Time.time - spawnTime) > spawnRate) {
			SpawnWave ();
			//Debug.Log (Time.time - spawnTime);
			spawnTime = Time.time;

		}
		//SpawnWave ();

	}

	public void onSpectrum(float[] spectrum)
	{
		//The spectrum is logarithmically averaged
		//to 12 bands
	}

	//spawn individual enemies
	void SpawnWave(){
		GameObject enemyChild = (GameObject)Instantiate(Resources.Load("BasicEnemy"));
		//enemyChild.transform.parent = EnemyParent.transform;
		enemyChild.transform.position = enemySpawnPosition.position;
		enemyChild.AddComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer + Time.time > 1f && startMusic == false) {
			startMusic = true;
			AudioProcessor processor = FindObjectOfType<AudioProcessor>();
			processor.addAudioCallback(this);
		}
		/* This is now done in onOnbeatDetected
		//create enemies
		if (Timer < Time.time) {
			SpawnWave();
			Timer = Time.time + spawnRate;
		}
		*/
	}
}
