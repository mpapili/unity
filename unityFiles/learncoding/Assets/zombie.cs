using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : humanoid {

	private int poisonDamage = 3;

	public override void Move() {
		base.Move ();	//uses move function from  humanoid
		transform.Translate (Vector3.left * 3 * Time.deltaTime); //does custom code!
	}

	public int AcidPukeAttack() {
		return attackDamage + poisonDamage;
	}

}
