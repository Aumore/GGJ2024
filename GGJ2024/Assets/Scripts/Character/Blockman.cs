using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockman : Paddle
{
    public int blockNumber;
    public GameObject blockPrefab;

    protected override void CharacterAbility()
    {
        Debug.Log("Blockman ability called");
        placeBlock();
    }

    protected void placeBlock()
    {
         // Calculate the position in front of the player
        Vector3 positionInFront = transform.position + transform.right * 2;

        // Instantiate the block
        Instantiate(blockPrefab, positionInFront, Quaternion.identity);
    }
}
