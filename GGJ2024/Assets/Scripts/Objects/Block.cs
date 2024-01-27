using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        GameObject Blockman = GameObject.Find("Paddle1");
        Blockman blockmanScript = Blockman.GetComponent<Blockman>();
        Debug.Log("Collision detected with " + collision2D.gameObject.name);
        if (collision2D.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Block collided with Ball");
            blockmanScript.blockNumber--;
            Destroy(gameObject);
        } else if (collision2D.gameObject.CompareTag("SuperBall"))
        {
            Debug.Log("Block collided with SuperBall");
            blockmanScript.blockNumber--;
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
