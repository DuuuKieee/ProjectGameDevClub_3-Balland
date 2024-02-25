using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy {

	float moveSpeed = 7f;

	//Ball target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody2D> ();
        //target = GameObject.FindObjectOfType<Ball>();
        Destroy(gameObject, 5);
		moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}

    //void OnTriggerEnter2D (Collider2D col)
    //{
    //	if (col.gameObject.name.Equals ("Ball")) {
    //		Debug.Log ("Hit!");
    //		Destroy (gameObject);
    //	}
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
