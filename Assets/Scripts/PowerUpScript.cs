using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);	 

        if (transform.position.y < -6f) {
            Destroy(gameObject);
        }
	}
}
