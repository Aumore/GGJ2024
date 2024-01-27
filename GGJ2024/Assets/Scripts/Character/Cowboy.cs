using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : Character
{
    protected override void CharacterAbility()
    {
        // Shoot the ball
        GameObject ball = GameObject.Find("Ball");
        Ball ballScript = ball.GetComponent<Ball>();
        Debug.Log("Cowboy ability called");       
    }
}
