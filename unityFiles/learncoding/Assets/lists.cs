using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lists : MonoBehaviour {

	string[] playersList = new string[4];
	//we have the array but we need to initialize it
	//immediatly reserves 4 slots in memory. uses them whether it's there or not

	string[] players = { "Johnnykill25", "bambambunnerlover", "devslopes", "ponyl0ver" };


	void Start () {
		//players [0] = "Johnnykiller25";
		//players [1] = "bambambunnylover18";
		//players [2] = "devslopes";
		//players [3] = "Ponyl0ver";
		Debug.Log ("Player One: " + players [0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
