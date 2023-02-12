using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int catType;

    private float full = 5.0f;
    private float energy = 0f;
    private bool isNotFull = true;

    // Start is called before the first frame update
    void Start()
    {
        float positionX = Random.Range(-8.5f, 8.5f);
        float positionY = 30f;
        transform.position = new Vector3(positionX, positionY, 0);

        if (catType == 1)
        {
            full = 10f;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            transform.position += new Vector3(0, GenerateFalliongSpeedByCatType(), 0);

            if (transform.position.y < -16f)
            {
                GameManager.I.GameOver();
            }
        }
        else
        {
            float positionX = transform.position.x > 0 ? 0.0f : -0.05f;
            transform.position += new Vector3(positionX, 0f, 0f);

            Destroy(gameObject, 2.5f);
        }
    }

    private float GenerateFalliongSpeedByCatType()
    {
        return catType switch
        {
            0 => -0.02f,
            1 => -0.04f,
            2 => -0.01f,
            _ => -0.01f,
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1f;
                Destroy(collision.gameObject);

                Transform frontBar = gameObject.transform.Find("Hungry/HP/Front");
                frontBar.transform.localScale = new Vector3(energy / full, 1f, 1f);
            }
            else if (isNotFull)
            {
                GameManager.I.AddCat();

                Transform hungry = gameObject.transform.Find("Hungry");
                Transform full = gameObject.transform.Find("Full");

                hungry.gameObject.SetActive(false);
                full.gameObject.SetActive(true);

                isNotFull = false;
            }
        }
    }
}
