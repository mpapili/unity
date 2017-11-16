using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating a generic singelton class
public class Singelton<T> : MonoBehaviour where T: MonoBehaviour {

	private static T instance;	//one single instance

	//capital "I" this time! This is our public getter!
	public static T Instance {
		get {
				//check if instance of gameManager is null, if it is, set it equal to itself
			if (instance == null) {
				//find any class name named "T" (gameManager for example)
				instance = FindObjectOfType<T>();
			}
				//destroy it if there's another one!
			else if (instance != FindObjectOfType<T>()) {
				Destroy(FindObjectOfType<T>());
			}

			DontDestroyOnLoad (FindObjectOfType<T>());
			print ("created gameManager instance");
			return instance;
		}
	}

}
