using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int target = 0;	//will be checkpoint array index!
	[SerializeField] private Transform exitPoint;	//transform is a location on the 2d map
	[SerializeField] private Transform[] wayPoints; //array of transforms
	[SerializeField] private float navigationUpdate;	//compared to delta-time for different speed computers
	[SerializeField] private int healthPoints;	// enemy dies when this is zero

	private Transform enemy;
	private float navigationTime = 0;
	private bool isDead = false;	// is enemy dead at this time?
	private Collider2D enemyCollider; // get this component in start!
	private Animator anim;	// our animator

	// Use this for initialization
	void Start () {

		enemyCollider = GetComponent<Collider2D>();
		anim = GetComponent<Animator> ();
		enemy = GetComponent<Transform> ();	//we're using the built-in script "transform" on our enemy
		//register our enemy!
		GameManager.Instance.RegisterEnemy(this);
	}
	

	void Update () {
		if (wayPoints != null && isDead != true) {
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
			//tell game manager to reduce our count of enemies on screen!
			GameManager.Instance.UnregisterEnemy (this);
		} else if (other.tag == "projectile") {	// else if it hits a projectile
			// get good at "get"!
			Projectile newP = other.gameObject.GetComponent<Projectile>();	//allows us to access the variables
			enemyHit(newP.attackStrength);
			Destroy(other.gameObject);	//should destroy whatever it's hit with!
		}
	}

	public void enemyHit(int hitpoints){
		// don't let it drop under zero!
		if (healthPoints - hitpoints > 0) {
			healthPoints -= hitpoints;	// take off health!
			// call hurt animation
			anim.Play("hurt");	// play hurt animation
		} else {
			// enemy should die
			die();
			// disabling components is easy! destroy the hitbox
			enemyCollider.enabled = false;
		}
	}

	// remember... MORE MODULAR
	public void die(){
		isDead = true;	// he dead
		anim.SetTrigger("didDie");	// we can all this out of any animation so we use a trigger for it instead
	}

	// getter for isDead
	public bool IsDead {
		get{
			return isDead;
		}
	}
}
