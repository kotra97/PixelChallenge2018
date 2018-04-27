using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    bool okToPlay = false;
    public string nextScene;

	void Start ()
    {
        StartCoroutine(waitForPlay());
	}

    IEnumerator waitForPlay()
    {
        yield return new WaitForSeconds(0.7f);
        okToPlay = true;
        yield return null;
    }

    void Update ()
    {
        if (okToPlay == false)
            return;
        if (Input.GetButtonDown("Joystick Start") || Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(nextScene);
    }
}
