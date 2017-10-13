using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : humanoid {

	private int spinAttackDamage = 10;

	public override void Move(){
		base.Move ();	//call's Move() from humanoid.cs
	}

	//overrides basic attack() from hummanoid!
	public override int Attack ()
	{
		return attackDamage + spinAttackDamage;
	}
}
