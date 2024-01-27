using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSuperBall : SuperBall
{
    public GameObject bananaPrefab;
    public float delayInSeconds = 2.0f;

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
        Vector3 positionInFront = transform.position + Vector3.up * 2;
        Instantiate(bananaPrefab, positionInFront, Quaternion.identity);
    }
}
