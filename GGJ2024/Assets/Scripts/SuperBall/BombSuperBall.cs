using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSuperBall : SuperBall
{
    void Start()
    {
        // Initialise values
        timeToKill = 10f;
        // speed = 1f;

        startPosition = transform.position;
        Lanuch();
    }
    
    protected override void superBallAbility()
    {
        // Count down until exploreds
        GameObject ball = GameObject.Find("Ball");
        Ball ballScript = ball.GetComponent<Ball>();
        ballScript.isBomb = true;
        Debug.Log("Bomb deployed");
    }
}
