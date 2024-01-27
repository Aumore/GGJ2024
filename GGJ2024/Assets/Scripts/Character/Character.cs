using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Character : Paddle
{
    public float health;
    public BoxCollider2D boxCollider2D;

    protected virtual void CharacterAbility()
    {

    }

    public bool isSpacePressed()
    {
       return Input.GetKeyDown(KeyCode.Space);
    }
}
