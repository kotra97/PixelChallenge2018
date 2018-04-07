using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public Object nextScene;
    public Sprite spriteWall = null;
    public Sprite spriteLight = null;
    public RuntimeAnimatorController animatorLight = null;
    public Sprite spritePlayer = null;
    public RuntimeAnimatorController animatorPlayer = null;
    public RuntimeAnimatorController animatorPlayerDeath = null;
    public RuntimeAnimatorController animatorFinish = null;
    public RuntimeAnimatorController animatorLayout = null;
    // Use this for initialization
    void Start()
    {
        GameObject[] go;

        go = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject t in go)
        {
            t.GetComponent<SpriteRenderer>().sprite = spriteWall;
        }

        go = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject t in go)
        {
            t.GetComponent<SpriteRenderer>().sprite = spriteLight;
        }

        if (animatorLight != null)
        {
            foreach (GameObject t in go)
            {
                t.GetComponent<Animator>().runtimeAnimatorController = animatorLight;
            }
        }
        if (animatorFinish != null)
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Animator>().runtimeAnimatorController = animatorFinish;
        if (spritePlayer != null)
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = spritePlayer;
        if (animatorPlayer != null)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = animatorPlayer;
    }
	
	void Update () {
		if (Input.GetButtonDown("Joystick Start") || Input.GetKeyDown(KeyCode.R))
        {
            restartScene();
        }
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			SceneManager.LoadScene("1990");
        }
		if (Input.GetKeyDown(KeyCode.Alpha2))
        {
			SceneManager.LoadScene("2000");
        }
		if (Input.GetKeyDown(KeyCode.Alpha3))
        {
			SceneManager.LoadScene("2010");
        }
	}

    IEnumerator endScene()
    {
        
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void restartScene()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().deathSound();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = animatorPlayerDeath;
        StartCoroutine(endScene());        
    }

    public void nextLevel()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);

        GameObject[] tmp =  GameObject.FindGameObjectsWithTag("WallList");
        foreach (GameObject i in tmp)
        {
            i.SetActive(false);
        }

        tmp = GameObject.FindGameObjectsWithTag("LightList");
        foreach (GameObject i in tmp)
        {
            i.SetActive(false);
        }
        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        if (animatorLayout != null)
            GameObject.FindGameObjectWithTag("Layout").GetComponent<Animator>().runtimeAnimatorController = animatorLayout;
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(nextScene.name);
        yield return null;
    }
}