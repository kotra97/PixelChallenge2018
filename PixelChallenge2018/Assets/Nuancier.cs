using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuancier : MonoBehaviour {

	public GameObject player;
    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float r = player.GetComponent<SpriteRenderer>().color.r;
		float g = player.GetComponent<SpriteRenderer>().color.g;
		float b = player.GetComponent<SpriteRenderer>().color.b;
		if (r != 0)
			r = 1;
		if (g != 0)
			g = 1;
		if (b != 0)
			b = 1;
		if (r == 0 && g == 0 && b == 0)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
		if (r == 0 && g == 1 && b == 0)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
		if (r == 1 && g == 0 && b == 0)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
		if (r == 0 && g == 0 && b == 1)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
		if (r == 0 && g == 1 && b == 1)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
		if (r == 1 && g == 0 && b == 1)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
		if (r == 1 && g == 1 && b == 0)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
		if (r == 1 && g == 1 && b == 1)
			gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
	}
}
