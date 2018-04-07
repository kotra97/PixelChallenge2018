using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    public bool re;
    public bool bl;
    public bool gr;
    Color tmp = new Color(0, 0, 0);

    private void Start()
    {
        if (re)
            tmp.r = 255;
        if (bl)
            tmp.b = 255;
        if (gr)
            tmp.g = 255;
        GetComponent<SpriteRenderer>().color = tmp;
        tmp = new Color(0, 0, 0);
    }

}
