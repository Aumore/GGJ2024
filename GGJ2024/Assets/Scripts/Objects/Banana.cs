using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private float timeToKill;
    public AudioClip bananaSound;
    private AudioSource bananaAudio;

    bool time_check()
    {
        return timeToKill > 0;
    }

   void Start()
    {
        // Initialise values
        timeToKill = 5f;
        //speed = 5f;
        bananaAudio = GetComponent<AudioSource>();
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
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Banana hit");
            GameObject Ball = GameObject.Find("Ball");
            Ball ballScript = Ball.GetComponent<Ball>();
            ballScript.Lanuch();
            AudioSource.PlayClipAtPoint(bananaSound, transform.position);
            // bananaAudio.Play();
            Destroy(gameObject);
        }
    }
}
