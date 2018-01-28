using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = -4f / -9.81f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "floor")
            Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
