using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public bool isReversed;
    private float movement;
    
    void Start() {
        startPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isPlayer1) {
            movement = Input.GetAxisRaw("Vertical");
        }
        else {
            movement = Input.GetAxisRaw("Vertical2");
        }

        if (isReversed) {
            Debug.Log("Reversed");
            movement *= -1;
        } 
        
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    public void Reset() {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
