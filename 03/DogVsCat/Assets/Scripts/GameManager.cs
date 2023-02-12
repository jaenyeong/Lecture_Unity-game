using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public GameObject dog;
    public GameObject food;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    public GameObject retryBtn;
    public GameObject levelFront;

    public Text levelText;

    private int level = 0;
    private int cat = 0;

    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating(nameof(CreateFood), 0f, 0.1f);
        InvokeRepeating(nameof(CreateCat), 0f, 1.5f);
    }

    private void CreateFood()
    {
        float foodPositionX = dog.transform.position.x;
        float foodPositionY = dog.transform.position.y + 2.0f;

        // Quaternion은 회전을 의미
        Instantiate(food, new Vector3(foodPositionX, foodPositionY, 0), Quaternion.identity);
    }

    private void CreateCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            InstantiateNormalCatIfPossible(Random.Range(0, 10) < 2);
        }
        else if (level == 2)
        {
            InstantiateNormalCatIfPossible(Random.Range(0, 10) < 5);
        }
        else if (level == 3)
        {
            InstantiateNormalCatIfPossible(Random.Range(0, 10) < 5);
            Instantiate(fatCat);
        }
        else if (level >= 4)
        {
            InstantiateNormalCatIfPossible(Random.Range(0, 10) < 5);
            Instantiate(fatCat);
            Instantiate(pirateCat);
        }
    }

    private void InstantiateNormalCatIfPossible(bool isPossible)
    {
        if (isPossible)
        {
            Instantiate(normalCat);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddCat()
    {
        cat++;
        level = cat / 5;

        levelText.text = level.ToString();

        float positionX = (cat - level * 5) / 5.0f;
        levelFront.transform.localScale = new Vector3(positionX, 1.0f, 1.0f);
    }
}
