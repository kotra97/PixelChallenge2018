using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {
    public GameObject[] dummyList;
	private SpriteRenderer sr;
	// Use this for initialization
	void Start ()
    {
		sr = gameObject.GetComponent<SpriteRenderer>();
        testAround();
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

    public void displayArmy()
    {
        foreach (GameObject obj in dummyList)
        {
            obj.GetComponent<DummyScript>().chooseDisplay();
        }
    }

    public void testAround()
    {
        foreach (GameObject obj in dummyList)
        {
            obj.GetComponent<SpriteRenderer>().enabled = false;
            obj.GetComponent<DummyScript>().stockColor(sr.color);
            obj.GetComponent<DummyScript>().isDisplay = true;
        }
        dummyList[0].transform.position = transform.position + new Vector3(0.5f, 0, 0);
        dummyList[1].transform.position = transform.position + new Vector3(-0.5f, 0, 0);
        dummyList[2].transform.position = transform.position + new Vector3(0, 0.5f, 0);
        dummyList[3].transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    public bool checkDummy(int nb)
    {
        return (dummyList[nb].GetComponent<SpriteRenderer>().enabled);
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Light")
		{
            GetComponent<playerMovement>().getColorSound();
            sr.color = additionColor(sr.color, other.gameObject.GetComponent<SpriteRenderer>().color);
			Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            GetComponent<playerMovement>().lostSound();
            other.GetComponent<WallScript>().updatePlayer(this.gameObject);
        }
        if (other.gameObject.tag == "Finish" && (sr.color.g != 0 || sr.color.r != 0 || sr.color.b != 0))
        {
            GetComponent<playerMovement>().snowSound();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().nextLevel();
        }
    }
}
