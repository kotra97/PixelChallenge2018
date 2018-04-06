using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    float timeUpdate = 0.4f;
    float timeLeft = 0;
    Vector3 moveDirection;
    float distCommune = 0.6f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            return;
        }
        moveDirection = new Vector3(Input.GetAxis("Joystick Direction X"), -Input.GetAxis("Joystick Direction Y"), 0);
        if (Mathf.Abs(moveDirection.x) > 0.8f)
        {
            Debug.Log("Pe");
            if (moveDirection.x > 0)
                moveDirection = transform.TransformDirection(distCommune, 0, 0);
            else
                moveDirection = transform.TransformDirection(-distCommune, 0, 0);
            transform.position += moveDirection;
            timeLeft = timeUpdate;
        }
        else if (Mathf.Abs(moveDirection.y) > 0.8f)
        {
            if (moveDirection.y > 0)
                moveDirection = transform.TransformDirection(0, distCommune, 0);
            else
                moveDirection = transform.TransformDirection(0, -distCommune, 0);
            transform.position += moveDirection;
            timeLeft = timeUpdate;
        }
    }

}