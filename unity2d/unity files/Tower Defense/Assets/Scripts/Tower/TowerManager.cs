using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : Singelton<TowerManager> {

	//some unity-stuff!
	public TowerBtn towerBtnPressed{get; set;}	// one-line getter and setter!
	private SpriteRenderer spriteRenderer;	//create our sprite renderer object

	void Start () {
		
		spriteRenderer = GetComponent<SpriteRenderer> ();	//looks for our spriterenderer component
		//add this as a component to your tower manager object
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
				//define this tag
				hit.collider.tag = "buildSiteFull";
				placeTower (hit);
			}
		}
		if (spriteRenderer.enabled) {
			followMouse ();
		}
	}

	//set selected tower to be whichever tower button was pressed
	public void selectedTower(TowerBtn towerSelected){

		towerBtnPressed = towerSelected;
		enableDragSprite (towerBtnPressed.DragSprite);
	}

	public void followMouse(){
		transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//this is a hacky way to make sure everything is on top of the page
		transform.position = new Vector2 (transform.position.x, transform.position.y);
	}

	//sprite renderer's sprite is the spirte we pass in
	public void enableDragSprite(Sprite Sprite) {
		spriteRenderer.enabled = true;
		spriteRenderer.sprite = Sprite;
	}

	public void disableDragSprite(){
		spriteRenderer.enabled = false;
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
