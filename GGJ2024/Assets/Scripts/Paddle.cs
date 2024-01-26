using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public bool isPlayer2;
    public bool isAI;
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public Ball ballScript;
    public bool isReversed;
    private float movement;
    private float moveSpeedMultiplier = 1f;

    [Header("AI")]
    public float aiDeadzone = 1f;
    public float aiMoveSpeedMultiplierMin = 0.5f, aiMoveSpeedMultiplierMax = 1.5f;
    private int direction = 0;

    void Start()
    {
        startPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {        
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
            if (isReversed) {
                Debug.Log("Reversed");
                movement = -1; 
            }
            Move(movement);
        }
        else if (isPlayer2)
        {
            movement = Input.GetAxisRaw("Vertical2");
                       if (isReversed) {
                Debug.Log("Reversed");
                movement = -1; 
            }
            Move(movement);
        }
        else if (isAI)
        {
            MoveAI();
        }


        // rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    private void MoveAI()
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

    private void Move(float movement)
    {
        Vector2 velo = rb.velocity;
        velo.y = speed * moveSpeedMultiplier * movement;
        rb.velocity = velo;
    }
}
