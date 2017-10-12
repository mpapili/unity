using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCubes : MonoBehaviour {

	public GameObject cubePrefab;	//public so our scripts can use it
									//drag your cube prefab over to this script when you assign it to an object-
									//-like main camera!
	GameObject[] cubes = new GameObject[5];

	float spacer = 0.5f;

	// Use this for initialization
	void Start () {
		//go through array and create cubes accordingly

		//let's use a C# for-loop to accomplish this!
		for (int i = 0; i < cubes.Length; i++) {

			GameObject cube = Instantiate (cubePrefab);
			cubes [i] = cube;
			//let's move our cubes along the X-axis!
			cube.transform.position = new Vector3(i + (spacer * i),cube.transform.position.y);

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
