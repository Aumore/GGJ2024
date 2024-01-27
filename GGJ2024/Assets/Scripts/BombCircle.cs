using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCircle : MonoBehaviour
{
    public Ball ballScript;
    public float timeToKill;
    bool time_check()
    {
        return timeToKill > 0;
    }

    void Start()
    {
        // Initialise values
        timeToKill = 1f;
        //speed = 5f;
        //transform.position = ballScript.GetCurrentPosition();
    }
    
    void Update()
    {
        timeToKill -= Time.deltaTime;
        if (!time_check())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Paddle1"))
        {
            GameManager.Instance.Player2Scored();
        }
        else if (other.gameObject.CompareTag("Paddle2"))
        {
            GameManager.Instance.Player1Scored();
        }
    }
}
