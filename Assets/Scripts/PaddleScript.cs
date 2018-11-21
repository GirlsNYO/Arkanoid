using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gm.gameOver)
        {
            return;
        }
        
        float horizontal = Input.GetAxis ("Horizontal");
        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);

        if(transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }

        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
    }
}
