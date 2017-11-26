using UnityEngine;

//create a pulblic enumerator type!
//this is a special kind of object containing all types of projectiles
public enum proType {
	rock, arrow, fireball
}

public class Projectile : MonoBehaviour {

	//how strong is this variable?
	[SerializeField] private int attackStrength;

	[SerializeField] private proType projectileType;

	//getters!
	public int AttackStrength{
		get{
			return attackStrength;
		}
	}

	public proType ProjectileType{
		get{
			return projectileType;
		}
	}
}
