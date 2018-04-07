using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    // Use this for initialization
    bool okToPlay = false;
    public Object nextScene;

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
    // Update is called once per frame
    void Update ()
    {
        if (okToPlay == false)
            return;
        if (Input.GetButtonDown("Joystick Start") || Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(nextScene.name);
    }
}
