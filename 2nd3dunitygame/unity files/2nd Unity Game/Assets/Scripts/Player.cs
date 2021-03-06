﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;	//assertions import

public class Player : MonoBehaviour {

	[SerializeField] private float jumpforce = 100;

	//create an animator object --> searches animator object 
	private Animator anim;
	private Rigidbody rigidBody;
	private bool jump = false;
	[SerializeField] private AudioClip sfxJump;	//going to be sound effect
	private AudioSource audioSource;
	[SerializeField] private AudioClip sfxDeath;	//sound upon death
	[SerializeField] private AudioClip sfxCoin;	//coin
	private Vector3 startingVector;
	private bool playerAlive = true;
	//built-in unity function - see unity docs
	void Awake() {

		//creates red error unless these are assigned
			//only works in debug mode
		Assert.IsNotNull (sfxJump);
		Assert.IsNull (sfxDeath);

	}

	//always make everything private if you can! DATA ENCAPSULATION	

	// Use this for initialization
	void Start () {
		//will search object script is assigned-to for an animator component (our zombie player has one!)
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();	//will search for rigidbody component 
		audioSource = GetComponent<AudioSource> ();	//will get audio source from audiosource component
		startingVector = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {

		if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
			//let's capture the input of a mouse-click or tap
			if (Input.GetMouseButtonDown (0)) {		//"0" means left-click!
				GameManager.instance.PlayerStartedGame();
				rigidBody.useGravity = true;	//turn on gravity after first click! :)
				anim.Play ("jump");	//will play the jump animation
				jump = true;
				//play ONCE the audio noise
				audioSource.PlayOneShot (sfxJump);
			}
			if (!playerAlive) {
				rigidBody.useGravity = false;	//turn off gravity again
				transform.position = startingVector;
				rigidBody.velocity = new Vector3 (0,0,0);
				rigidBody.detectCollisions = true;	//turn physics BACK ON		
				playerAlive = true;
			}
		}
	}

	//FixedUpdate > Update for rigidbodies
	//controls framerate for update rate
	void FixedUpdate() {

		if (jump == true) {

			jump = false;
			//here's how you add physics force to a rigidbody
				//use autocomplete on "." to check out the types of forcemodes
			rigidBody.velocity = new Vector2 (0,0);
			rigidBody.AddForce(new Vector2(0, jumpforce), ForceMode.Impulse);

		}

	}

	void OnCollisionEnter(Collision collision) {
		//game objects have tags! Create tags in unity
		if (collision.gameObject.tag == "obstacle") {
			rigidBody.AddForce (new Vector2 (80, 30), ForceMode.Impulse);	//apply some force to him
			rigidBody.detectCollisions = false;		//pull physics away from him so he dies!
			audioSource.PlayOneShot (sfxDeath);	//play the death sound
			GameManager.instance.PlayerCollided();	//player colided set bool to true!
			playerAlive = false;
		}
		if (collision.gameObject.tag == "collectable") {
			GameManager.instance.PlayerGotCoin ();
			//collision.gameObject.SetActive (false);	//let's see if we can destroy the coin!
			//collision.gameObject.transform.position = new Vector3 (collision.gameObject., transform.position.y, transform.position.z);
			collision.gameObject.transform.position = new Vector3 (-80.5f, gameObject.transform.position.y, gameObject.transform.position.z);
			audioSource.PlayOneShot (sfxCoin);
		}


	}

}
