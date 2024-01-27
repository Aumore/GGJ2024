using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
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
    protected float movement;
    protected float moveSpeedMultiplier = 1f;

    [Header("AI")]
    public float aiDeadzone = 1f;
    public float aiMoveSpeedMultiplierMin = 0.5f, aiMoveSpeedMultiplierMax = 1.5f;
    protected int direction = 0;

    [Header("Special Effect")]
    public bool isReversed;
    public float timeToStop;
    public float hitTime;
    public bool isShrinked;
    public int shrinkTime;
    public int hitCheck;
    public bool isHit;
    
    void Start()
    {
        startPosition = transform.position;
        shrinkTime = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
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

        if (isReversed) {
            ReverseCountDown();
        }

        if (isShrinked) {
            ShrinkCountDown();
        }

        if (isHit) {
            HitCountDown();
        }
    }

   private void HandlePlayerInput(string axis)
    {
        float movement = Input.GetAxisRaw(axis);
        if (isReversed) {
            Move(-1 * movement);
        } else {
            Move(movement);
        }
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

    protected void getHit()
    {
        if (isHit){
            speed /= 2;
        } else if (!isHit) {
            speed *= 2;
        }
    }

    protected void HitCountDown()
    {
        if (hitCheck == 0) {
            getHit();
            hitCheck = 1;
        }

        hitTime -= Time.deltaTime;
        if (hitTime < 0) {
            isHit = false;
            hitTime = 10; //hard code time for ReverseCountDown
            getHit();
            hitCheck = 0;
        }
    }


    protected void ReverseCountDown()
    {
        timeToStop -= Time.deltaTime;
        if (timeToStop < 0) {
            isReversed = false;
            timeToStop = 10; //hard code time for ReverseCountDown
        }
    }

    protected void ShrinkCountDown()
    {
        if (shrinkTime == 0) {
            ChangeSize();
            shrinkTime = 1;
        }

        timeToStop -= Time.deltaTime;
        if (timeToStop < 0) {
            isShrinked = false;
            timeToStop = 10; //hard code time for ReverseCountDown
            ChangeSize();
            shrinkTime = 0;
        }
    }

    public void ChangeSize()
    {
        if (isShrinked){
            transform.localScale /= 2;
        } else if (!isShrinked) {
            transform.localScale *= 2;
        }
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
