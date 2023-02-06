using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private int type;
    private float size;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        type = Random.Range(1, 5);

        switch (type)
        {
            case 1:
                size = 1.2f;
                score = 3;
                GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
                break;

            case 2:
                size = 1.0f;
                score = 2;
                GetComponent<SpriteRenderer>().color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 255 / 255f);
                break;

            case 3:
                size = 0.8f;
                score = 1;
                GetComponent<SpriteRenderer>().color = new Color(150 / 255f, 150 / 255f, 255 / 255f, 255 / 255f);
                break;

            default:
                size = 0.8f;
                score = -5;
                GetComponent<SpriteRenderer>().color = new Color(255.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 255.0f / 255.0f);
                break;
        }

        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                Destroy(gameObject);
                break;
            case "Rtan":
                GameManager.I.AddScore(score);
                Destroy(gameObject);
                break;
        }
    }
}
