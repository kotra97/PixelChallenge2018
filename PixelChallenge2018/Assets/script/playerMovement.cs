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
			{
                transform.position += new Vector3(distCommune, 0, 0);
				transform.rotation = Quaternion.Euler(0, 0, 90f);
			}
            else
			{
                transform.position += new Vector3(-distCommune, 0, 0);
				transform.rotation = Quaternion.Euler(0, 0, -90f);
			}
            timeLeft = timeUpdate;
        }
        else if (Mathf.Abs(moveDirection.y) == 1)
        {
            if (moveDirection.y > 0)
			{
                transform.position += new Vector3(0, distCommune, 0);
				transform.rotation = Quaternion.Euler(0, 0, 180f);
			}
            else
			{
                transform.position += new Vector3(0, -distCommune, 0);
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
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