using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsScript : MonoBehaviour {

	//Makes a private variable that the "inspector" in unity can see
	[SerializeField] float objectSpeed = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//ACCESS ASSIGNED OBJECT'S TRANSFORM COMPONENT
		//MOVE LEFT 20 * [time since last frame]
		transform.Translate(Vector3.right * (objectSpeed * Time.deltaTime));
	}
}
