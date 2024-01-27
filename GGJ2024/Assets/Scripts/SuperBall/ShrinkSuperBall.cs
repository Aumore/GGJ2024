using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkSuperBall : SuperBall
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
        // Reverse the paddle
        Debug.Log("ShrinkSuperBall ability");
        GameObject paddle = GameObject.Find("Paddle1"); // TODO: HARD CODED
        GameObject paddle2 = GameObject.Find("Paddle2");
        Paddle paddleScript = paddle.GetComponent<Paddle>();
        Paddle paddleScript2 = paddle2.GetComponent<Paddle>();
        paddleScript.isShrinked = true;
        paddleScript2.isShrinked = true;
    }
}
