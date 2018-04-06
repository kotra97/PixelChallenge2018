using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {

	private SpriteRenderer sr;
	// Use this for initialization
	void Start ()
    {
		sr = gameObject.GetComponent<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    Color additionColor(Color one, Color two)
    {
        float red = one.r;
        float gre = one.g;
        float blu = one.b;
        red += two.r;
        gre += two.g;
        blu += two.b;

        if (red > 255)
            red = 255;
        if (blu > 255)
            blu = 255;
        if (gre > 255)
            gre = 255;
        return (new Color(red, gre, blu));
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Light")
		{
			sr.color = additionColor(sr.color, other.gameObject.GetComponent<SpriteRenderer>().color);
			Destroy(other.gameObject);
		}
        if (other.gameObject.tag == "Wall")
        {
            other.GetComponent<WallScript>().updatePlayer(this.gameObject);
        }
	}
}
