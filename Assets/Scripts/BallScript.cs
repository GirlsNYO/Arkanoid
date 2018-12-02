using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public float ballForce;
    public Transform powerup;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(ballForce, ballForce));
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.gameOver)
        {
            return;
           
        }

        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            Debug.Log("Blabla");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();
            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            } else {
                int randChance = Random.Range(1, 101);
                if (randChance < 50)
                {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore(brickScript.points);
                gm.UpdateNumberOfBricks();
                Destroy(other.gameObject);
            }
        }
    }
}
