using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// what's the status of the game
// enum's are like bools for states instead of true/false (kind of not really but it helps to think this way)
public enum gameStatus {
	next, play, gameover, win
}

public class GameManager : Singelton<GameManager> {

	// let's create a public spawn point! (can change as game is running)
	[SerializeField] private GameObject spawnPoint;
	[SerializeField] private GameObject[] enemies; //a public array for enemies


	// let's make some controls
	[SerializeField] private int maxEnemiesObScreen; //limit enemies to be spawned
	[SerializeField] private int totalEnemies; //how many are on the screen at the time
	[SerializeField] private int enemiesPerSpawn; //how many at a time? More control

	// GUI-related variables
	[SerializeField] private int totalWaves = 10;	// total waves for game
	[SerializeField] private Text totalMoneyLbl;	// need to import unityengine.ui for this
	[SerializeField] private Text currentWaveLbl;	// current wave

	[SerializeField] private Text playButtonLbl;	// label for the playbutton (Start, stop, etc)
	[SerializeField] private Button playBtn;	// object for the button to be dragged in
	[SerializeField] private Text totalEscapedLbl;	// amount of enemies that escaped

	private int waveNumber = 0;	// current wave
	private int totalMoney = 10;	// money user has
	private int totalEscaped = 0;	// total that got out
	private int roundEscaped = 0; 	// total that got out THIS ROUND
	private int totalKilled = 0;	// how many you killed this wave
	private int whichEnemiesToSpawn = 0;	// which enemy do you spawn? from the enemies array

	private gameStatus currentState = gameStatus.play;

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
		// our button will trigger this
		// StartCoroutine (spawn ());
		playBtn.gameObject.SetActive(false);	// hide button when game first starts
		showMenu();	// show the menu!
	}
		
	
	// Update is called once per frame
	void Update () {
		handleEscape ();
	}

	// getter AND setter for money
	public int TotalMoney {
		get {
			return totalMoney;
		}
		set {
			totalMoney = value;
			totalMoneyLbl.text = totalMoney.ToString ();
		}

	}
	// add money
	public void addMoney(int amount){
		TotalMoney += amount;
	}
	// subtract money
	public void subtractMoney(int amount){
		TotalMoney -= amount;
	}

	// show menu after state change
	// VERY good example of "switch" and "case"
	public void showMenu() {
		switch (currentState) {
		case gameStatus.gameover:
			playButtonLbl.text = "Play Again!";
			// add gameover sound
			break;
		case gameStatus.next:
			playButtonLbl.text = "Next Wave";
			break;
		case gameStatus.play:
			playButtonLbl.text = "Play";
			break;
		case gameStatus.win:
			playButtonLbl.text = "Play";
			break;
		}
		playBtn.gameObject.SetActive (true);
	}


	private void handleEscape(){
		// if escape key is pressed
		if (Input.GetKeyDown (KeyCode.Escape)) {
			// stop it from dragging
			TowerManager.Instance.disableDragSprite ();
			TowerManager.Instance.towerBtnPressed = null;	// null out towerSelected
		}
	}
}
