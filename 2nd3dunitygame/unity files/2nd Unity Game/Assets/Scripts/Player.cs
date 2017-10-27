using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private float jumpforce = 100;

	//create an animator object --> searches animator object 
	private Animator anim;
	private Rigidbody rigidBody;
	private bool jump = false;
	[SerializeField] private AudioClip sfxJump;	//going to be sound effect
	private AudioSource audioSource;

	//always make everything private if you can! DATA ENCAPSULATION	

	// Use this for initialization
	void Start () {
		//will search object script is assigned-to for an animator component (our zombie player has one!)
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();	//will search for rigidbody component 
		audioSource = GetComponent<AudioSource> ();	//will get audio source from audiosource component
	}
	
	// Update is called once per frame
	void Update () {

		//let's capture the input of a mouse-click or tap
		if (Input.GetMouseButtonDown (0)) {		//"0" means left-click!
			rigidBody.useGravity = true;	//turn on gravity after first click! :)
			anim.Play("jump");	//will play the jump animation
			jump = true;
		}
		//play ONCE the audio noise
		audioSource.PlayOneShot (sfxJump);

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

}
