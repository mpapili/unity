using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour {

	[SerializeField] Vector3 topPosition;
	[SerializeField] Vector3 bottomPosition;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {

		StartCoroutine (Move (bottomPosition));
	}
	
	//IEnumerator is an advanced C# topic (google it)
	//target will be the top or bottom!
	IEnumerator Move(Vector3 target) {

		//we need absolute value for distance!
		//NOTICE how we do math on vector3's THEN take the "y" value!
		while (Mathf.Abs((target - transform.localPosition).y) > 0.20f) {

			//notice above we use ">" instead of "==" because games often skip values!

			//Ternary expressions! Very powerful! Three expressions
			//[section to be true or false] ? action if true : action if false;
			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * Time.deltaTime * speed;

			//IEnumerator can return things, but if it returns nothing it'll loop!
			//return null to tell it to loop again, will go forever!
			yield return null;

		}

		print("Reached the target");	//use print whenever you inherit from monobehavior
		//debug.log has multiple parameters too!

		yield return new WaitForSeconds(0.5f);	//wait half a second
		//powerful ternary - created a vector3 called "newTarget"
		//-it'll be bottomPosition if we're currently topPosition ELSE it becomes topPosition
		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

		//starting this as a coroutine (looks like recursion almost!)
		StartCoroutine(Move(newTarget));

			}
}
