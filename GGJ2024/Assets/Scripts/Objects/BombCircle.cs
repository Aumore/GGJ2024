using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCircle : MonoBehaviour
{
    public Ball ballScript;
    private float timeToKill;
    public AudioClip boomSound;
    private AudioSource boomAudio;
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
            AudioSource.PlayClipAtPoint(boomSound,transform.position);
            Destroy(gameObject);
            GameManager.Instance.ResetPostion();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
                    AudioSource.PlayClipAtPoint(boomSound,transform.position);
        if (other.gameObject.CompareTag("Paddle1"))
        {
            GameManager.Instance.Player2Scored();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Paddle2"))
        {
            GameManager.Instance.Player1Scored();
            Destroy(gameObject);
        }
    }
}
