using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//create an animator object --> searches animator object 
	Animator anim;

	// Use this for initialization
	void Start () {
		//will search object script is assigned-to for an animator component (our zombie player has one!)
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		//let's capture the input of a mouse-click or tap
		if (Input.GetMouseButtonDown (0)) {		//"0" means left-click!
			anim.Play("jump");	//will play the jump animation
		}

	}
}
