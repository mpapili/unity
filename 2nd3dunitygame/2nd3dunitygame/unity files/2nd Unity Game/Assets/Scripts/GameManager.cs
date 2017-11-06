using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//create gamemanager maned 'instance'
	public static GameManager instance = null;

	//we need to serialize the main menu gameobject!
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject replayButton;

	//has the player STARTED playing?
	private bool playerActive = false;
	//is the game over?
	private bool gameOver = false;
	//has the game started?
	private bool gameStarted = false;

	//my code starts here
	private int score = 0;

	void Awake() {
		//make sure there's only one gamemanager object
		if (instance == null) {
			//this means "ME" (this gamemanager script)
			instance = this;
		} else if (instance != this) {
			//destroy second gamemanagers if one is created
			Destroy (gameObject);
		}

		//allows this object to persist BETWEEN SCENES
		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (mainMenu);
	}

	// Use this for initialization
	void Start () {
		replayButton.SetActive (false);	//hide replay button!
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//setters vs getters!


	//setters!

	//player has colided
	public void PlayerCollided() {
		gameOver = true;
		replayButton.SetActive (true);
	}

	//player got a coin
	public void PlayerGotCoin() {
		score += 1;
		print(score);
	}

	//player started game
	public void PlayerStartedGame() {
		playerActive = true;
	}
	public void enterGame(){
		gameStarted = true;
		//DISABLE THE MAIN MENU WHEN GAME STARTS
		mainMenu.SetActive (false);
	}

	public void resetGame(){
		gameOver = false;
		playerActive = false;
		replayButton.SetActive (false);
	}

	//getters!
	public bool PlayerActive {
		get { return playerActive; }
	}
		

	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStarted {
		get { return gameStarted; }
	}

	public int GetScore {
		get { return score; }
	}



}
