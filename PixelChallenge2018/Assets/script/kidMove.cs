using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kidMove : MonoBehaviour {

    Vector3 moveDirection;
    public GameObject door;
    float speed = 0.09f;
    float secondSpeed = 0.3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(Input.GetAxis("Joystick Axe X"), 0, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        if (Input.GetButton("Joystick A"))
            moveDirection *= secondSpeed;
        else
            moveDirection *= speed;
        transform.position += moveDirection;
    }
}
