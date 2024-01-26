using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    private Vector2 currentPosition;

    void Start()
    {
        startPosition = transform.position;
        Lanuch();
    }

    void Update()
    {
        currentPosition = transform.position;
    }

    private void Lanuch()
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

    public Vector3 GetCurrentPosition()
    {
        return currentPosition;
    }
}
