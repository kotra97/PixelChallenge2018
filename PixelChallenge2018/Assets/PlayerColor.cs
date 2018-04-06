using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {

	private SpriteRenderer sr;
	private int isColored = 0;
	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Color") 
		{
			float red = other.gameObject.GetComponent<SpriteRenderer>().color.r;
			float gre = other.gameObject.GetComponent<SpriteRenderer>().color.g;
			float blu = other.gameObject.GetComponent<SpriteRenderer>().color.b;
			if (isColored == 1)
			{
				red += sr.color.r;
				gre += sr.color.g;
				blu += sr.color.b;
			}
			else
			{
				isColored = 1;
			}
			sr.color = new Color(red, gre, blu);
			Destroy(other.gameObject);
		}
	}
}
