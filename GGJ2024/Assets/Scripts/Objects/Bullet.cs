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
        Destroy(gameObject);
        GameObject Gunman = GameObject.Find("Gunman");
        Gunman gunmanScript = Gunman.GetComponent<Gunman>();
        gunmanScript.bulletNumber++;
    }
}
