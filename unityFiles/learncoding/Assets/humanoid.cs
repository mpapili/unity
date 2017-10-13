using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//let's make blueprints for a humanoid based on things all humanoid characters will have
public class humanoid : MonoBehaviour {

	//protected is a private class that can ONLY be accessed by child-classes!
	protected int health;
	protected int attackDamage;
	protected float movementSpeed;

	//make sure to include "virtual" (explained below)
	public virtual int Attack(){
		return attackDamage;	//default return
	}

	// "virtual" means child-classes can call it OR override it without warning
	public  virtual void Move() {
		// one way to move things in unity, you don't have to understand
		// "typical" way you move forward
		transform.Translate (Vector3.forward * Time.deltaTime);
	}

	public virtual void TakeDamage(int damageToTake) {
		health -= damageToTake;
	}

	public void Die() {


	}

}