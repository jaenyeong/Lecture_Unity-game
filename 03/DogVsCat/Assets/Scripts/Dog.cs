using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(MoveWithinTheRangeOfTheFishShop(mousePosition.x), transform.position.y, 0);
    }

    private float MoveWithinTheRangeOfTheFishShop(float mousePosX)
    {
        float leftWall = -8.5f;
        float rightWall = 8.5f;

        if (mousePosX < leftWall)
        {
            return leftWall;
        }
        else if (mousePosX > rightWall)
        {
            return rightWall;
        }
        else
        {
            return mousePosX;
        }
    }
}
