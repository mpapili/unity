using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals2 : MonoBehaviour {

	// Use this for initialization
	int towersRemainingP1 = 3;
	int towersRemainingP2 = 3;
	bool mainTowerDestroyedP1 = false;
	bool mainTowerDestroyedP2 = false;
	float timer = 200;

	void Start () {
		//like in python you can use booleans without " == true" !!
		if (mainTowerDestroyedP1 || mainTowerDestroyedP2) {

			if (mainTowerDestroyedP1) {
				Debug.Log ("player 1 lost");
			} else if (mainTowerDestroyedP2) {
				Debug.Log ("player 2 lost");
			} else if (timer <= 0) {
				Debug.Log ("time is up");
				if (towersRemainingP1 > towersRemainingP2) {
					Debug.Log ("player 1 wins");
				} else if (towersRemainingP2 > towersRemainingP1) {
					Debug.Log ("player 2 wins");
				} else {
					Debug.Log ("the game was a draw");
				}
			}
		}

		//example of binary operators "==", "||", "!=", "&&"
		//binary operators work on two things, one on the left and one on the right
		if (true == false || false != true && 1 == 1) {
			Debug.Log ("your example was a success!");	//this executes
		}
	}
	// Update is called once per frame
	void Update () {
		timer -= 20;
	}
}
