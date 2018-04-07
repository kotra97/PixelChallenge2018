using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	private AudioSource source;
	public AudioClip movementAudio1;
    public AudioClip movementAudio2;
    public AudioClip movementAudio3;
    public AudioClip wrongAudio;
    public AudioClip deathAudio;
    public AudioClip getColorAudio;
    public AudioClip lostAudio;
    public AudioClip snowAudio;

    float timeUpdate = 0.2f;
    float timeLeft = 0;
    Vector3 moveDirection;
    float distCommune = 0.5f;

    // Use this for initialization
    void Start ()
    {
		source = GetComponent<AudioSource>();
	}

    int nbColor()
    {
        int res = 0;
        SpriteRenderer tmp = GetComponent<SpriteRenderer>();
        if (tmp.color.b != 0)
            res++;
        if (tmp.color.g != 0)
            res++;
        if (tmp.color.r != 0)
            res++;
        return (res);
    }

	public void moveSound()
    {
        int nb = nbColor();
        Debug.Log(nb);
        if (nb == 1)
    		source.PlayOneShot(movementAudio1, 1f);
        if (nb == 2)
            source.PlayOneShot(movementAudio2, 1f);
        if (nb == 3)
            source.PlayOneShot(movementAudio3, 1f);
    }

    void moveWrongSound()
    {
        source.PlayOneShot(wrongAudio, 1f);
    }

    public void getColorSound()
    {
        source.PlayOneShot(getColorAudio, 1f);
    }

    public void lostSound()
    {
        source.PlayOneShot(lostAudio, 1f);
    }

    public void  deathSound()
    {
        source.PlayOneShot(deathAudio, 1f);
    }

    public void snowSound()
    {
        source.PlayOneShot(snowAudio, 1f);
    }

    private void movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Joystick Direction X"), -Input.GetAxis("Joystick Direction Y"), 0);
        if (Mathf.Abs(moveDirection.x) == 1 || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (moveDirection.x > 0 || Input.GetKey(KeyCode.RightArrow))
			{
                //AJOUT SON WRONG et OK
                if (!GetComponent<PlayerColor>().checkDummy(0))
                {
                    moveWrongSound();
                    return;
                }
                transform.position += new Vector3(distCommune, 0, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, 90f);
			}
            else
			{
                if (!GetComponent<PlayerColor>().checkDummy(1))
                {
                    moveWrongSound();
                    return;
                }
                transform.position += new Vector3(-distCommune, 0, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, -90f);
			}
            moveSound();
            timeLeft = timeUpdate;
            GetComponent<PlayerColor>().testAround();
        }
        else if (Mathf.Abs(moveDirection.y) == 1 || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            if (moveDirection.y > 0 || Input.GetKey(KeyCode.UpArrow))
			{
                if (!GetComponent<PlayerColor>().checkDummy(2))
                {
                    moveWrongSound();
                    return;
                }
                transform.position += new Vector3(0, distCommune, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, 180f);
                moveSound();
            }
            else
			{
                if (!GetComponent<PlayerColor>().checkDummy(3))
                {
                    moveWrongSound();
                    return;
                }
                transform.position += new Vector3(0, -distCommune, 0); ;
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
            moveSound();
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