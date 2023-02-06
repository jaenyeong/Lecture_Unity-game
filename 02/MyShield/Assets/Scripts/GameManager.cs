using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text thisScoreTxt;
    public Text maxScoreTxt;
    public Animator anim;

    private readonly string Hundredths = "N2";
    private float alive = 0f;
    private bool isRunning = true;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0.0f, 0.5f);
    }

    void MakeSquare()
    {
        Instantiate(square);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString(Hundredths);
        }
    }

    public void GameOver()
    {
        isRunning = false;
        endPanel.SetActive(true);
        thisScoreTxt.text = alive.ToString(Hundredths);

        // Time.timeScale = 0f; 이렇게 선언한 후에 단순히 isDie 플래그를 true로 변경하면
        // 시간이 바로 멈춰 변경할 시간이 없기 때문에 Invoke("timeStop", 0.5f); 명령으로
        // 0.5초 후에 정지 시켜준 후 isDie를 true로 변경
        anim.SetBool("isDie", true);
        Invoke("timeStop", 0.5f);

        string bestScore = "bestScore";

        if (PlayerPrefs.HasKey(bestScore) == false)
        {
            PlayerPrefs.SetFloat(bestScore, alive);
        }

        float maxScore = GetMaxScore(PlayerPrefs.GetFloat(bestScore));
        PlayerPrefs.SetFloat(bestScore, maxScore);
        maxScoreTxt.text = maxScore.ToString(Hundredths);
    }

    private float GetMaxScore(float currentScore)
    {
        return alive >= currentScore ? alive : currentScore;
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
