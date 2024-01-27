using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaddleControl
{
    Player1,
    Player2,
    AI
}


public class Paddle : MonoBehaviour
{
    public PaddleControl controlState;
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public Ball ballScript;
    public bool isReversed;
    protected float movement;
    protected float moveSpeedMultiplier = 1f;

    [Header("AI")]
    public float aiDeadzone = 1f;
    public float aiMoveSpeedMultiplierMin = 0.5f, aiMoveSpeedMultiplierMax = 1.5f;
    protected int direction = 0;
        void Start()
    {
        startPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        direction = 1;
        if (isReversed) {
            Debug.Log("Reversed");
            direction = -1; 
        }

        switch (controlState)
        {
            case PaddleControl.Player1:
                HandlePlayerInput("Vertical");
                break;
            case PaddleControl.Player2:
                HandlePlayerInput("Vertical2");
                break;
            case PaddleControl.AI:
                MoveAI();
                break;
        }

        ActivateAbility();
    }

   private void HandlePlayerInput(string axis)
    {
        float movement = Input.GetAxisRaw(axis);
        Move(movement);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    protected void MoveAI()
    {
        Vector2 ballPos = ballScript.GetCurrentPosition();

        if (Mathf.Abs(ballPos.y - transform.position.y) > aiDeadzone)
        {
            direction = ballPos.y > transform.position.y ? 1 : -1;
        }

        if (Random.value < 0.01f)
        {
            moveSpeedMultiplier = Random.Range(aiMoveSpeedMultiplierMin, aiMoveSpeedMultiplierMax);
        }

        Move(direction);
    }

    protected void Move(float movement)
    {
        Vector2 velo = rb.velocity;
        velo.y = speed * moveSpeedMultiplier * movement;
        rb.velocity = velo;
    }

    protected void ActivateAbility()
    {
        // activate ability when space is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Debug.Log("Ability activated");
            CharacterAbility();
        }
    }

    // A virtual method for the special ability
    protected virtual void CharacterAbility()
    {
        // Default implementation or empty
    }
}
