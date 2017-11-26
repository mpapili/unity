using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] float timeBetweenAttacks;
	[SerializeField] private float attackRadius;
	//we've created the projectile class already
	private Projectile projectile;
	//type "enemy" we'll be targeting
	private Enemy targetEnemy = null;
	private float attackCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//get ALL enemies in range
	private List<Enemy> GetEnemiesInRange() {
		List<Enemy> enemiesInRange = new List<Enemy> () ;
		//use the getter from GameManager to get the EnemyList
		foreach(Enemy enemy in GameManager.Instance.EnemyList){
			if((Vector2.Distance(transform.position, enemy.transform.position)) <= attackRadius){
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
			if (Vector2.Distance (transform.position, enemy.transform.position) < smallestDistance) {
				nearestEnemy = enemy;
				smallestDistance = Vector2.Distance (transform.position, enemy.transform.position);
			}
		}
		return nearestEnemy;
	}

}
