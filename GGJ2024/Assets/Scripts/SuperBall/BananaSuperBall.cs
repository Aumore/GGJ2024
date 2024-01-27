using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSuperBall : SuperBall
{
    public GameObject bananaPrefab;
    void Start()
    {
        // Initialise values
        timeToKill = 10f;
        // speed = 5f;

        startPosition = transform.position;
        Lanuch();
    }

    protected override void superBallAbility()
    {
        Instantiate(bananaPrefab, transform.position, Quaternion.identity);
    }
}
