using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    private Vector2 currentPosition;
    public bool isBomb;
    public float timeToBoom;
    private SpriteRenderer spriteRenderer;
    public GameObject BombCirclePrefeb;
    public Sprite BallSprite;
    public Sprite BombSprite;
    public AudioClip bounceSound;
    private AudioSource ballAudio;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballAudio = GetComponent<AudioSource>();
        Lanuch();
    }

    void Update()
    {
        currentPosition = transform.position;

        if (isBomb)
        {
            BombCountDown();
        }
    }

    protected void BombCountDown()
    {
        timeToBoom -= Time.deltaTime;
        ChangeColor();
        if (timeToBoom < 0)
        {
            isBomb = false;
            timeToBoom = 10; // hard code time for ReverseCountDown
            ChangeColor();
            Explosion();
        }
    }

    public void Explosion()
    {
        Instantiate(BombCirclePrefeb, currentPosition, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void ChangeColor()
    {
        if (spriteRenderer != null && isBomb)
        {
            // Change color to red
            spriteRenderer.sprite = BombSprite;
        }
        else if (spriteRenderer != null && !isBomb)
        {
            // Change color to white
            spriteRenderer.sprite = BallSprite;
        }
    }

    public void Lanuch()
    {
        Debug.Log("Lanuching ball");
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("BottomLine"))
        {
            // AudioSource.PlayClipAtPoint(bounceSound,transform.position);
            ballAudio.Play();
        }
    }
}
