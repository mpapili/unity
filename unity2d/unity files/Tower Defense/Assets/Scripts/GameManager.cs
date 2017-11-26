using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singelton<GameManager> {

	//let's create a public spawn point! (can change as game is running)
	[SerializeField] private GameObject spawnPoint;
	[SerializeField] private GameObject[] enemies; //a public array for enemies


	//let's make some controls
	[SerializeField] private int maxEnemiesObScreen; //limit enemies to be spawned
	[SerializeField] private int totalEnemies; //how many are on the screen at the time
	[SerializeField] private int enemiesPerSpawn; //how many at a time? More control

	//list of enemies on screen
	public List<Enemy> EnemyList = new List<Enemy> ();

	const float spawnDelay = 0.5f;	//delay between spawns!


	IEnumerator spawn(){
		if (enemiesPerSpawn > 0 && EnemyList.Count < totalEnemies) {
			for (int i = 0; i < enemiesPerSpawn; i++) {
				if (EnemyList.Count < maxEnemiesObScreen) {
					//create enemy and cast as GameObject
					GameObject newEnemy = Instantiate (enemies [0]) as GameObject;
					//move created enemy to spawnPoint right away
					newEnemy.transform.position = spawnPoint.transform.position;
				}
			}
		}
		yield return new WaitForSeconds (spawnDelay);
		StartCoroutine (spawn ());
	}

	//register our enemy and add them to our list
	public void RegisterEnemy(Enemy enemy){
		EnemyList.Add (enemy);
	}

	public void UnregisterEnemy(Enemy enemy){
		EnemyList.Remove (enemy);
		//at this point we definitely want the gameobject gone
		Destroy (enemy.gameObject);
	}

	//board-wipe!
	public void DestroyAllEnemies(){
		//for loops through lists!
		foreach (Enemy enemy in EnemyList) {
			Destroy (enemy.gameObject);
		}
		//reset entirely
		EnemyList.Clear ();
	}
		

	void Start () {
		StartCoroutine (spawn ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
