using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetButtonDown("Joystick Start") || Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
