using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	private AudioSource source;
	public AudioClip movementAudio;
    float timeUpdate = 0.2f;
    float timeLeft = 0;
    Vector3 moveDirection;
    float distCommune = 0.5f;

    // Use this for initialization
    void Start ()
    {
		source = GetComponent<AudioSource>();
	}

	void moveSound() {
		source.PlayOneShot(movementAudio, 1f);
	}

    private void movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Joystick Direction X"), -Input.GetAxis("Joystick Direction Y"), 0);
        if (Mathf.Abs(moveDirection.x) == 1 || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
			moveSound();
            if (moveDirection.x > 0 || Input.GetKey(KeyCode.RightArrow))
			{
                //AJOUT SON WRONG et OK
                if (!GetComponent<PlayerColor>().checkDummy(0))
                    return;
                transform.position += new Vector3(distCommune, 0, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, 90f);
			}
            else
			{
                if (!GetComponent<PlayerColor>().checkDummy(1))
                    return;
                transform.position += new Vector3(-distCommune, 0, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, -90f);
			}
            timeLeft = timeUpdate;
            GetComponent<PlayerColor>().testAround();
        }
        else if (Mathf.Abs(moveDirection.y) == 1 || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
			moveSound();
            if (moveDirection.y > 0 || Input.GetKey(KeyCode.UpArrow))
			{
                if (!GetComponent<PlayerColor>().checkDummy(2))
                    return;
                transform.position += new Vector3(0, distCommune, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, 180f);
			}
            else
			{
                if (!GetComponent<PlayerColor>().checkDummy(3))
                    return;
                transform.position += new Vector3(0, -distCommune, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
            timeLeft = timeUpdate;
            GetComponent<PlayerColor>().testAround();
        }
    }

    void Update ()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            if  (timeLeft < 0)
                GetComponent<PlayerColor>().displayArmy();
            return;
        }
        movement();
    }

}