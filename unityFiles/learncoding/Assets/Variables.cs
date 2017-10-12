using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//strings
		string name = "Thanos";	//thanos is stored as a string in 'name'
								//semicolon ends the statement
		string equippedWeapon = "Infinity Gauntlet";
		string favoriteFurniture = "throne";

		Debug.Log(equippedWeapon);
		Debug.Log(name);
		Debug.Log (favoriteFurniture);
		Debug.Log (equippedWeapon.ToUpper());

		//numbers
		int hp = 100;	//ints for whole numbers
		float shieldPower = 76.5f; //floats for decimals
								   //the "f" makes it a FLOAT instead of a DOUBLE
								   //called a "float literal"
		int laserDamage = 15;
		double actualDamagePercent = .5;

		// -= is an existing-operation, subtract from existing total
		int actualDamage = (int)(laserDamage * actualDamagePercent);
		//note that we case this as an integer with (int)
			//decimal points are dropped

		hp -= actualDamage;
		// we needed to declare actualDamage as an integer so that it can affect
		//-hp which is an integer without erroring out

		shieldPower = shieldPower - (laserDamage - actualDamage);

		Debug.Log ("hp: " + hp);
		Debug.Log ("Shield Power: " + shieldPower);

		int slices = 10 / 5;	//division
		print(slices);	//another way to print to console

		int newDamage = 10 / 3;
		print (newDamage);	//division operator gives no remainder
		int newDamageRemainder = 10 % 3;	//modular!
		print("10 divided by 3 equals " + newDamage + " with remainder of " + newDamageRemainder);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
