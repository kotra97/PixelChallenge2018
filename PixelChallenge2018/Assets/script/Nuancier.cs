using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuancier : MonoBehaviour {

    public Sprite[] sprites;
    private SpriteRenderer colPlayer;
    private SpriteRenderer rend;
	void Start ()
    {
        colPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        rend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		float r = colPlayer.color.r;
		float g = colPlayer.color.g;
		float b = colPlayer.color.b;

        if (r == 255)
        {
            if (g == 255)
            {
                if (b == 255)
                    rend.sprite = sprites[7];
                else
                    rend.sprite = sprites[6];
            }
            else if (b == 255)
                rend.sprite = sprites[5];
            else
                rend.sprite = sprites[2];
        }
        else if (g == 255)
        {
            if (b == 255)
                rend.sprite = sprites[4];
            else
                rend.sprite = sprites[1];
        }
        else if (b == 255)
            rend.sprite = sprites[3];
        else
			rend.sprite = sprites[0];
	}
}
