using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int target = 0;	//will be checkpoint array index!
	[SerializeField] private Transform exitPoint;	//transform is a location on the 2d map
	[SerializeField] private Transform[] wayPoints; //array of transforms
	[SerializeField] private float navigationUpdate;	//compared to delta-time for different speed computers

	private Transform enemy;
	private float navigationTime = 0;

	// Use this for initialization
	void Start () {

		enemy = GetComponent<Transform> ();	//we're using the built-in script "transform" on our enemy
		
	}
	

	void Update () {
		if (wayPoints != null) {
			navigationTime += Time.deltaTime;	//time since navigation time created
			if (navigationTime > navigationUpdate) {
				if (target < wayPoints.Length) {
					// move enemy towards next point
					enemy.position = Vector2.MoveTowards (enemy.position, wayPoints [target].position, navigationTime);
				} else {
					enemy.position = Vector2.MoveTowards (enemy.position, exitPoint.position, navigationTime);
				}
				navigationTime = 0;	//reset the timer after each move!
			}
		}
	}

	//if we hit something this will be triggered! make sure it's 2d!
	// "other" is passed-in collided-with object!
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Checkpoint") {
			target += 1;	//increase index for checkpoint array when we hit each new checkpoint
		} else if (other.tag == "Finish") {
			//if we hit the end, DESTROY me!
			Destroy (gameObject);
			//tell game manager to reduce our count of enemies on screen!
			GameManager.Instance.removeEnemyFromScreen();
		}
	}

}
