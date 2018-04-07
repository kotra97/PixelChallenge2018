using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public Scene nextScene;
    public Sprite spriteWall = null;
    public Sprite spriteLight = null;
    public RuntimeAnimatorController animatorLight = null;
    public Sprite spritePlayer = null;
    public RuntimeAnimatorController animatorPlayer = null;
    public RuntimeAnimatorController animatorPlayerDeath = null;
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = spritePlayer;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().runtimeAnimatorController = animatorPlayer;
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(nextScene.name);
    }
}