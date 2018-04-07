using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour {

    public bool isDisplay;
    public Color colorCheck;
	// Use this for initialization
	void Start () {
		
	}

    public void stockColor(Color tmp)
    {
        colorCheck = tmp;
    }

    public void chooseDisplay()
    {
        GetComponent<SpriteRenderer>().enabled = isDisplay;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (other.GetComponent<WallScript>().checkColor(colorCheck))
                isDisplay = true;
            else
                isDisplay = false;
        }
        else if (other.gameObject.tag == "border")
        {
            isDisplay = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (other.GetComponent<WallScript>().checkColor(colorCheck))
                isDisplay = true;
            else
                isDisplay = false;
        }
        else if (other.gameObject.tag == "border")
        {
            Debug.Log("AH");
            isDisplay = false;
        }
    }
}
