using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public int points;
    public int hitsToBreak;

    public void BreakBrick(){
        hitsToBreak--;
        GetComponent<SpriteRenderer>().color = new Color (233.0f / 255.0f, 151.0f / 255.0f, 227.0f / 255.0f, 255.0f / 255.0f);
    } 
}
