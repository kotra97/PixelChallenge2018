using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouillieMove : MonoBehaviour {

    Vector3 moveDirection;
    public GameObject door;
    float speed = 0.09f;
    float secondSpeed = 0.3f;
    //float gravity = 1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveDirection = new Vector3(Input.GetAxis("Joystick Axe X"), - Input.GetAxis("Joystick Axe Y"), 0);
        moveDirection = transform.TransformDirection(moveDirection);
        if (Input.GetButton("Joystick A"))
            moveDirection *= secondSpeed;
        else
           moveDirection *= speed;
        transform.position += moveDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "button")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            collision.gameObject.tag = "Active";
            if (GameObject.FindWithTag("button") == null)
            {
                Debug.Log("Pe");
                Destroy(door);
            }
        }
    }
}
