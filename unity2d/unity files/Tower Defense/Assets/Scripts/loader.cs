using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loader : MonoBehaviour {

	public GameObject gameManager;

	//called once when game is loaded
	void Awake () {
		// if gamemanager wasn't create, create the singelton
		if (GameManager.instance == null) {
			Instantiate (gameManager);
		}
	}

}
