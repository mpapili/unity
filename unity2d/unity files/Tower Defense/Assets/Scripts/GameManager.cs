using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singelton<GameManager> {

	//let's create a public spawn point! (can change as game is running)
	public GameObject spawnPoint;
	public GameObject[] enemies; //a public array for enemies


	//let's make some controls
	public int maxEnemiesObScreen; //limit enemies to be spawned
	public int totalEnemies; //how many are on the screen at the time
	public int enemiesPerSpawn; //how many at a time? More control

	private int enemiesOnScreen = 0;
	const float spawnDelay = 0.5f;	//delay between spawns!


	IEnumerator spawn(){
		if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies) {
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
		yield return new WaitForSeconds (spawnDelay);
		StartCoroutine (spawn ());
	}


	public void removeEnemyFromScreen(){

		if (enemiesOnScreen > 0) {
			enemiesOnScreen -= 1;
		}

	}

	void Start () {
		StartCoroutine (spawn ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
