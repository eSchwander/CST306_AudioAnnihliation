using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour, AudioProcessor.AudioCallbacks {

	public GameObject TowerPositionParent;
	Transform newPosition;
	public Transform enemySpawnPosition;
	public GameObject EnemyParent;
	public float sizeMultiplyer = 1f;
	public int boardSize = 20;
	
	public float spawnRate = 0.05f;
	private float Timer;
	private float spawnTime;

	public float health;
	public float difficulty;

	bool startMusic = false;

	//variables for visualizer
	public GameObject visObject;
	public float visMultiplyer = 500f;

	// Use this for initialization
	void Start () {
		Timer = Time.time;
		spawnTime = Time.time;
		health = 100;
		difficulty = 1;

		//fill TowerPositionParent object with tower positions
		for (int i = 0; i < boardSize; i++) {
			for (int j = 0; j < boardSize; j++){
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

		visObject = GameObject.FindGameObjectWithTag ("Visualizer");
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

		Debug.Log ("SPECTRUM: " + spectrum[6]);
		visObject.transform.localScale = new Vector3 (spectrum [6]*visMultiplyer, 0f, spectrum [6]*visMultiplyer);
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
