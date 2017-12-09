using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//clicking the buttons will return tower objects
public class TowerBtn : MonoBehaviour {

	//we just need a gameobject to start
	[SerializeField]
	private GameObject towerObject;
	[SerializeField]
	private Sprite dragSprite;
	[SerializeField] private int towerPrice;	// how much towers cost

	//NOTICE THE CASES
	public GameObject TowerObject{
		get{
			return towerObject;
		}
	}
	//getter!
	public Sprite DragSprite{
		get{
			return dragSprite;
		}
	}

	public int TowerPrice{
		get{
			return towerPrice;
		}
	}
}
