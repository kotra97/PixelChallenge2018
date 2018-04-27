using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour {

    public bool isDisplay;
    public Color colorCheck;

	void Start (){}

    public void stockColor(Color tmp) {colorCheck = tmp;}

    public void chooseDisplay() {GetComponent<SpriteRenderer>().enabled = isDisplay;}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
            isDisplay = other.GetComponent<WallScript>().checkColor(colorCheck);
        else if (other.gameObject.tag == "border")
            isDisplay = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
            isDisplay = other.GetComponent<WallScript>().checkColor(colorCheck);
        else if (other.gameObject.tag == "border")
            isDisplay = false;
    }
}
