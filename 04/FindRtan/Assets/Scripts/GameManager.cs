using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public Text timeTxt;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endTxt;

    // 오디오 소스가 사용하는 오디오 데이터 등
    public AudioClip matchSound;
    // 씬에서 오디오 클립 재생
    public AudioSource audioSource;

    private float time;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        int[] shuffledRtanCards = ShuffleRtanCards();

        for (int i = 0; i < 16; i++)
        {
            GenerateRtanCard(i, GenerateRtanCardName(shuffledRtanCards[i]));
        }
    }

    private int[] ShuffleRtanCards()
    {
        return new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 }
           .OrderBy(element => Random.Range(-1.0f, 1.0f))
           .ToArray();
    }

    private string GenerateRtanCardName(int rtanNumber)
    {
        return "rtan" + rtanNumber.ToString();
    }

    private GameObject GenerateRtanCard(int index, string rtanName)
    {
        GameObject newRtanCard = Instantiate(card);
        Transform newRtanTransform = newRtanCard.transform;

        float positionX = (index / 4) * 1.4f - 2.1f;
        float positionY = (index % 4) * 1.4f - 3.0f;
        newRtanTransform.position = new Vector3(positionX, positionY, 0);
        newRtanTransform.Find("Front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        newRtanTransform.parent = GameObject.Find("Cards").transform;

        return newRtanCard;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time >= 60.0f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void IsMatched()
    {
        string firstCardImageName = FindCardImageName(firstCard);
        string secondCardImageName = FindCardImageName(secondCard);

        Card firstCardComponent = firstCard.GetComponent<Card>();
        Card secondCardComponent = secondCard.GetComponent<Card>();

        if (firstCardImageName == secondCardImageName)
        {
            audioSource.PlayOneShot(matchSound);

            firstCardComponent.DestroyCard();
            secondCardComponent.DestroyCard();

            int cardsLeft = GameObject.Find("Cards").transform.childCount;
            if (cardsLeft == 2)
            {
                Invoke(nameof(GameEnd), 2f);
            }
        }
        else
        {
            firstCardComponent.CloseCard();
            secondCardComponent.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    private string FindCardImageName(GameObject givenCard)
    {
        return givenCard.transform
            .Find("Front")
            .GetComponent<SpriteRenderer>()
            .sprite
            .name;
    }

    private void GameEnd()
    {
        Time.timeScale = 0f;
        endTxt.SetActive(true);
    }

    public void ReGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
