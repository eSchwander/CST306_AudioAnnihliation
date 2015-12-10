using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour, AudioProcessor.AudioCallbacks {
	//Board variables
	public GameObject TowerPositionParent;
	Transform newPosition;
	public Transform enemySpawnPosition;
	public GameObject EnemyParent;
	public float sizeMultiplyer = 1f;
	public int boardSize = 20;

	//Variables used for spawning waves
	public float spawnRate = 0.05f;
	private float Timer;
	private float spawnTime;
	private int beatCounter = 0;
	private int nthBeat = 15;

	//Difficulty stuff
	public float health;
	public float difficulty;

	//false till music is playing
	bool startMusic = false;

	//variables for visualizer
	public GameObject visObject;
	public float volume;
	public Vector3 initialScale;
	public float visMultiplyer = 5f;
	public ParticleSystem particleVis;
	//public GameObject planeVis;

	//UI Text for Money tracking
	public Text moneyText;
	private string moneyMessage = "Shekels: ";
	private MoneyManager moneyMan;

	// Use this for initialization
	void Start () {
		moneyMan = MoneyManager.getInstance ();
		Timer = Time.time;
		//spawnTime = Time.time;
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

		visObject = GameObject.FindGameObjectWithTag ("Visualizer");;
	}

	public void onOnbeatDetected()
	{
		beatCounter += 1;

		if (beatCounter % nthBeat == 0) {
			Debug.Log ("spawn");
			if(Random.Range(0,10) >= 9 && beatCounter > nthBeat * 10){
				SpawnWave ("HeavyEnemy");
			}
			else
				SpawnWave("BasicEnemy");
			//Debug.Log (Time.time - spawnTime);
			//spawnTime = Time.time;

		}
		//SpawnWave ();

	}

	public void onSpectrum(float[] spectrum)
	{
		//The spectrum is logarithmically averaged
		//to 12 bands

		//Debug.Log ("SPECTRUM: " + spectrum[6]);

		visObject.transform.localScale = new Vector3 (spectrum [6]*visMultiplyer, 0f, spectrum [6]*visMultiplyer);

		for (int i = 0; i < 11; i++) {
			volume += spectrum[i];
		}
		volume = volume / 2;
		initialScale = transform.localScale;
		//visObject.transform.localScale = Vector3.Lerp (Transform.localScale, volume*visMultiplyer, 0f, volume*visMultiplyer);
		visObject.transform.localScale = Vector3.Lerp (initialScale, new Vector3(volume*visMultiplyer, 0f, volume*visMultiplyer), Time.deltaTime*1000f);

		//change particle system
		particleVis.GetComponent<ParticleSystem> ().startColor = new Color (spectrum[1]*visMultiplyer, spectrum[6]*visMultiplyer, spectrum[10]*visMultiplyer, volume*visMultiplyer);
		particleVis.GetComponent<ParticleSystem> ().startSpeed = volume*visMultiplyer;
		particleVis.GetComponent<ParticleSystem> ().emissionRate = volume * visMultiplyer;

		//planeVis.GetComponent<Renderer> ().material.color = Color.green;

	}

	//spawn individual enemies
	void SpawnWave(string enemy){
		GameObject enemyChild = (GameObject)Instantiate(Resources.Load(enemy));
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


		moneyText.text = moneyMessage + moneyMan.getMoney ();

		/* This is now done in onOnbeatDetected
		//create enemies
		if (Timer < Time.time) {
			SpawnWave();
			Timer = Time.time + spawnRate;
		}
		*/
	}
}
