using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;
    public BallScript bs;

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

    private void OnTriggerEnter2D(Collider2D other)
     {
        if (other.CompareTag("extraLife"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("fasterSpeed"))
        {
            bs.speed = bs.speed + 50;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("lowerSpeed"))
        {
            bs.speed = bs.speed - 50;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("widePaddle"))
        {
            GetComponent<Transform>().localScale = new Vector2(20, 2f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("thinPaddle"))
        {
            GetComponent<Transform>().localScale = new Vector2(10, 2f);
            Destroy(other.gameObject);
        }
    }
}
