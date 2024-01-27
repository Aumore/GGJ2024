using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        Debug.Log("Collision detected with " + collision2D.gameObject.name);
        if (collision2D.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Block collided with Ball");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
