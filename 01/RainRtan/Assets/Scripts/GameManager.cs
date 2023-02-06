using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject rain;
    public GameObject panel;
    public Text scoreText;
    public Text timeText;

    private const float DefaultTimeLimit = 30;
    private int totalScore = 0;
    private float currentTime = DefaultTimeLimit;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
        InvokeRepeating("MakeRain", 0, 0.5f);
    }

    void MakeRain()
    {
        Instantiate(rain);
    }

    void InitGame()
    {
        Time.timeScale = 1.0f;
        totalScore = 0;
        currentTime = DefaultTimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            currentTime = 0.0f;
        }
        timeText.text = currentTime.ToString("N2");
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
