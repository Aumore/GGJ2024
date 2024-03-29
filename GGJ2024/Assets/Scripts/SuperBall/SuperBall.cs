using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SuperBall : MonoBehaviour
{
    public float speed;
    public float timeToKill;
    public Vector3 startPosition;
    public Rigidbody2D rb;
    public CircleCollider2D circleCollider2D;

    bool time_check()
    {
        return timeToKill > 0;
    }

    public void Lanuch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Lanuch();
    }

    // Should be triggered instead on enter when the superball collides with the ball
    void OnTriggerEnter2D(Collider2D collision2D)
    {
        Debug.Log("Collision detected with " + collision2D.gameObject.name);
        if (collision2D.gameObject.CompareTag("Ball"))
        {
            Debug.Log("SuperBall collided with Ball");
            superBallAbility();
            Destroy(gameObject);
        }
    }

    protected virtual void superBallAbility()
    {
        // Default implementation
    }

    void Update()
    {
        timeToKill -= Time.deltaTime;
        if (!time_check())
        {
            Destroy(gameObject);
        }
    }

}
