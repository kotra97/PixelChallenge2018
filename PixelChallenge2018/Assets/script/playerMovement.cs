using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    float timeUpdate = 0.2f;
    float timeLeft = 0;
    Vector3 moveDirection;
    float distCommune = 0.5f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
    private void movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Joystick Direction X"), -Input.GetAxis("Joystick Direction Y"), 0);
        if (Mathf.Abs(moveDirection.x) == 1)
        {
            if (moveDirection.x > 0)
                moveDirection = transform.TransformDirection(distCommune, 0, 0);
            else
                moveDirection = transform.TransformDirection(-distCommune, 0, 0);
            transform.position += moveDirection;
            timeLeft = timeUpdate;
        }
        else if (Mathf.Abs(moveDirection.y) == 1)
        {
            if (moveDirection.y > 0)
                moveDirection = transform.TransformDirection(0, distCommune, 0);
            else
                moveDirection = transform.TransformDirection(0, -distCommune, 0);
            transform.position += moveDirection;
            timeLeft = timeUpdate;
        }
    }

    void Update ()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            return;
        }
        movement();
    }

}