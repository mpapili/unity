using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : Singelton<TowerManager> {

	//some unity-stuff!
	private TowerBtn towerBtnPressed;

	void Start () {
	}

	void Update () {
	}

	//set selected tower to be whichever tower button was pressed
	public void selectedTower(TowerBtn towerSelected){

		towerBtnPressed = towerSelected;
		Debug.Log ("Pressed: " + towerSelected);

	}

}
