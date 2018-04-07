using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

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

    Color soustractionColor(Color one, Color two)
    {
        float red = one.r;
        float gre = one.g;
        float blu = one.b;
        red -= two.r;
        gre -= two.g;
        blu -= two.b;

        if (red < 0)
            red = 0;
        if (blu < 0)
            blu = 0;
        if (gre < 0)
            gre = 0;
        return (new Color(red, gre, blu));
    }

    public void updatePlayer(GameObject player)
    {
        if (re)
            tmp.r = player.gameObject.GetComponent<SpriteRenderer>().color.r;
        if (bl)
            tmp.b = player.gameObject.GetComponent<SpriteRenderer>().color.b;
        if (gr)
            tmp.g = player.gameObject.GetComponent<SpriteRenderer>().color.g;
        player.GetComponent<SpriteRenderer>().color = soustractionColor(player.GetComponent<SpriteRenderer>().color, tmp);
        tmp = new Color(0, 0, 0);
    }
}
