using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

   void OnTriggerEnter2D(Collider2D collision2D)
   {
        Debug.Log("Bullet Triggered with " + collision2D.gameObject.name);
        if (collision2D.gameObject.CompareTag("Paddle2"))
        {
            GameObject Paddle2 = GameObject.Find("Paddle2");
            Paddle paddleScript = Paddle2.GetComponent<Paddle>();
            paddleScript.isHit = true;
        }
        Destroy(gameObject);
        GameObject Gunman = GameObject.Find("Paddle1");
        Gunman gunmanScript = Gunman.GetComponent<Gunman>();
        gunmanScript.bulletNumber++;
    }
}
