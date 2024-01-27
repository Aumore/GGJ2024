using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSuperBall : SuperBall
{
    void Start()
    {
        // Initialise values
        timeToKill = 10f;
        //speed = 5f;

        startPosition = transform.position;
        Lanuch();
    }
    
    protected override void superBallAbility()
    {
        // Reverse the paddle
        GameObject paddle = GameObject.Find("Paddle1"); // TODO: HARD CODED
        GameObject paddle2 = GameObject.Find("Paddle2");
        Paddle paddleScript = paddle.GetComponent<Paddle>();
        Paddle paddleScript2 = paddle2.GetComponent<Paddle>();
        paddleScript.isReversed = true;
        paddleScript2.isReversed = true;
    }
}

