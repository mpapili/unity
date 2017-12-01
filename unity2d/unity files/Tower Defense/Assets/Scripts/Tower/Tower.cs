using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	// time to reset attackCounter to
	[SerializeField] float timeBetweenAttacks;
	[SerializeField] private float attackRadius;
	//we've created the projectile class already
	[SerializeField] private Projectile projectile;
	//type "enemy" we'll be targeting
	private Enemy targetEnemy = null;
	//time between attacks!
	private float attackCounter;
	private bool isAttacking = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//frame-rate agnostic
		attackCounter -= Time.deltaTime;

		//if we don't have a target, GET ONE
		if (targetEnemy == null) {
			Enemy nearestEnemy = GetNearestEnemyInRange ();
			//if an enemy is in ragne and it's radius is within attack radius
			if (nearestEnemy != null && Vector2.Distance (transform.position, nearestEnemy.transform.position) <= attackRadius) {
				targetEnemy = nearestEnemy;
			}
		} else {
			if (attackCounter <= 0) {
				isAttacking = true;
				attackCounter = timeBetweenAttacks;
			} else {
				isAttacking = false;
			}
			// if enemy that was targeted is out of range, set targetEnemy to null
			if(Vector2.Distance(transform.position, targetEnemy.transform.position) > attackRadius){
				targetEnemy = null;	
			}
		}

	}

	// the actual attack method
	public void Attack(){
		// reset isAttacking
		isAttacking = false;
		// create a new object
		Projectile newProjectile = Instantiate(projectile) as Projectile;
		// new projectile spawns at tower's position
		newProjectile.transform.localPosition = transform.localPosition;
		// destroy it if it was created without a target (yes it's possible!)
		if (targetEnemy == null) {
			Destroy (newProjectile);
		} else {
			// move projectile to enemy
			// start our coroutine to be going in the background 
			StartCoroutine(MoveProjectile(newProjectile));
		}
	}

	// use fixedupdate instead of update for moving objects
	void FixedUpdate(){
		if (isAttacking){
			Attack ();
		}
	}

	//IEnumerator to move projectile towards enemy
	IEnumerator MoveProjectile(Projectile projectile){
		Debug.Log ("Starting Coroutine!!!");
		while (getTargetDistance (targetEnemy) > 0.200f != null && targetEnemy != null) {
			//first let's find DIRECTION
			var dir = targetEnemy.transform.localPosition - transform.localPosition;
			// REMEMBER TRIG? atan = y/x in radians!
				// we're actually using arctangent in unity
			// gets us angle in degrees!
			var angleDirection = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			//rotate the object using the quanternion angle
				//don't be scared, we're only using vector3 for the ".forward"
			projectile.transform.rotation = Quaternion.AngleAxis(angleDirection, Vector3.forward);
			//the actual move (third argument is speed)
			var oldPosition = projectile.transform.localPosition;
			float translation = Time.deltaTime * 5.0f;
			projectile.transform.localPosition = Vector2.MoveTowards(projectile.transform.localPosition, targetEnemy.transform.localPosition, translation);
			Debug.Log ("old position was" + oldPosition + "new position is" + projectile.transform.localPosition);
			yield return null;
		}
		// if enemy goes out of range or dies we destroy the projectile
		if (projectile != null || targetEnemy == null) {
			Destroy (projectile);
		}
	}

	private float getTargetDistance(Enemy thisEnemy){
		// make sure we DO have an enemy in range
		if (thisEnemy == null) {
			thisEnemy = GetNearestEnemyInRange ();
		}
		if (thisEnemy == null) {
			return 0f;
		}
		// return distance as an absolute value float
		return Mathf.Abs(Vector2.Distance(transform.localPosition, thisEnemy.transform.localPosition));
	}

	//get ALL enemies in range
	private List<Enemy> GetEnemiesInRange() {
		List<Enemy> enemiesInRange = new List<Enemy> () ;
		//use the getter from GameManager to get the EnemyList
		foreach(Enemy enemy in GameManager.Instance.EnemyList){
					if((Vector2.Distance(transform.localPosition, enemy.transform.localPosition)) <= attackRadius){
				enemiesInRange.Add(enemy);
			}
		}
		return enemiesInRange;
	}

	//get NEAREST enemies from enemies in range list
	private Enemy GetNearestEnemyInRange(){
		Enemy nearestEnemy = null;
		float smallestDistance = float.PositiveInfinity;	//anything compared to it is smaller
		foreach (Enemy enemy in GetEnemiesInRange()) {
					if (Vector2.Distance (transform.localPosition, enemy.transform.localPosition) < smallestDistance) {
				nearestEnemy = enemy;
						smallestDistance = Vector2.Distance (transform.localPosition, enemy.transform.localPosition);
			}
		}
		return nearestEnemy;
	}

}
