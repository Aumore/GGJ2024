using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunman : Paddle
{
    public int bulletNumber;
    public GameObject bulletPrefab;

    protected override void CharacterAbility()
    {
        // Shoot the ball
        ShootBall();
        Debug.Log("Cowboy ability called");
    }

    protected void ShootBall()
    {
        // Calculate the position in front of the player
        Vector3 positionInFront = transform.position + (transform.right * 2 * -1);

        // Instantiate the ball
        if (bulletNumber >=0 ) {
            Instantiate(bulletPrefab, positionInFront, Quaternion.identity);
            bulletNumber--;
        }
    }
}
