using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnListScript : MonoBehaviour {

    public Sprite sprite = null;
    public RuntimeAnimatorController animator = null;

	// Use this for initialization
	void Start ()
    {
        SpriteRenderer[] list;
        Animator[] listAnim;

        list = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer t in list)
        {
            t.sprite = sprite;
        }

        if (animator == null)
            return;
        listAnim = gameObject.GetComponentsInChildren<Animator>();
        foreach (Animator t in listAnim)
        {
            t.runtimeAnimatorController = animator;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
