using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public static GameManager instance = null;	//one single instance

	//let's create a public spawn point! (can change as game is running)
	public GameObject spawnPoint;
	public GameObject[] enemies; //a public array for enemies


	//let's make some controls
	public int maxEnemiesObScreen; //limit enemies to be spawned
	public int totalEnemies; //how many are on the screen at the time
	public int enemiesPerSpawn; //how many at a time? More control

	private int enemiesOnScreen = 0;

	void Awake() {
			//check if instance of gameManager is null, if it is, set it equal to itself
		if (instance == null) {
			instance = this;
		}
			//destroy it if there's another one!
		else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad (gameObject);
		print ("created gameManager instance");
	}

	void spawnEnemy(){
		print ("ruinning spawnEnemy");
		if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies) {
			print ("spawning enemies");
			for (int i = 0; i < enemiesPerSpawn; i++) {
				if (enemiesOnScreen < maxEnemiesObScreen) {
					//create enemy and cast as GameObject
					GameObject newEnemy = Instantiate (enemies [0]) as GameObject;
					//move created enemy to spawnPoint right away
					newEnemy.transform.position = spawnPoint.transform.position;
					enemiesOnScreen += 1;	//increment private counter
				}
			}
		}
	}

	void Start () {
		spawnEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
