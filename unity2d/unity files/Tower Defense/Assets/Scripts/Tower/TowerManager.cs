using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : Singelton<TowerManager> {

	//some unity-stuff!
	private TowerBtn towerBtnPressed;

	void Start () {
	}

	//this is the only way we can keep track of the user's input real-time
	void Update () {
		// "0" is left "1" is right
		if (Input.GetMouseButton (0)) {
			//get world point from PERSPECTIVE of the camera!
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//notice Input.mousePosition!
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			if (hit.collider.tag == "buildsite") {
				placeTower (hit);
			}
		}
	}

	//set selected tower to be whichever tower button was pressed
	public void selectedTower(TowerBtn towerSelected){

		towerBtnPressed = towerSelected;

	}

	public void placeTower(RaycastHit2D hit) {
		// UI isn't a game object
		if (!EventSystem.current.IsPointerOverGameObject () && towerBtnPressed != null) {
			//create the tower
			GameObject newTower = Instantiate (towerBtnPressed.TowerObject);
			//set newTower transform position to equal the raycast's transform position
			newTower.transform.position = hit.transform.position;
		}
	}

}
