using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uptownFunctionuup : MonoBehaviour {

	int health = 100;
	int attackPower = 25;
	bool shieldOn = true;
	int shieldAmt = 15;

	//private means no one else can access it
	//public means other scripts can
	public void Attack() {
		//health = health - attackPower;
		int damageToInflict = GetAttackDamage(shieldOn, shieldAmt, attackPower); 
		health-= damageToInflict;
		Debug.Log ("Health after attack: " + health);
	}

	//gives random amount of health to the player!
	public void Heal() {
		int healAmount = GetRandomNumber ();
		health += healAmount;

		Debug.Log ("Received " + healAmount + " health");
		Debug.Log ("You now have " + health + " health");
	}

	//private function to decide random number!
	private int GetRandomNumber() {
		return Random.Range (2, 10);	//random in between 2 and 10
		//included in unity :)
		//returns work just like they do in python!
	}

	//you pass data into these little buckets and it renames them as it's called
	//similar to python you've just got to declare the types ahead-of-time!
	private int GetAttackDamage(bool isShieldOn, int theShieldAmount, int theAttackPower) {

		int damage = 0;

		if (isShieldOn) {
			//NEW WAY TO CAST AS INT AFTER CASTING AS FLOAT
			//THE FLOAT HAPPENS FIRST, ALLOWING THE MATH TO HAPPEN SAFELY
			//THEN THE INT HAPPENS WHICH DROPS DECIMALS AND GIVES US WHAT WE WANNA RETURN
			damage = theAttackPower - (int)(float)(theShieldAmount * 0.10f);
		} else {
			damage = theAttackPower;
		}

		return damage;

	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Health at start:  " + health);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
