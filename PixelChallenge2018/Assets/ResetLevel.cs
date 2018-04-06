using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Joystick Start"))
        {
            Debug.Log("restart");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
