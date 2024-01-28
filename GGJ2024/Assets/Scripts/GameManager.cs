using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    private int player1Score;
    private int player2Score;
    public GameObject PlayerWinPanel;
    public GameObject AIWinPanel;

    private void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
        Instance = this;
    }

    void Start() {
        PlayerWinPanel.SetActive(false);
        AIWinPanel.SetActive(false);
    }

    void Update() {
        if (player1Score == 5) {
            Time.timeScale = 0;
            PlayerWinPanel.SetActive(true);
        }
        else if (player2Score == 5) {
            Time.timeScale = 0;
            AIWinPanel.SetActive(true);
        }

        if (!PlayerWinPanel.activeSelf && !AIWinPanel.activeSelf) {
            Time.timeScale = 1;
        }
    }

    public void Player1Scored() {
        player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        ResetPostion();
    }

    public void Player2Scored() {
        player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
        ResetPostion();
    }

    public void ResetPostion() {
        ball.SetActive(true);
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }
}
