using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    private float direction = 0.05f;
    private float toward = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toward *= -1;
            direction *= -1;
        }

        // 실행되는 하드웨어에 따라 프레임 속도가 다를 수 있어
        // 게임내 흘러가는 시간에 따라 호출되게 하기 위해서 FixedUpdate() 메서드로 이동
    }

    void FixedUpdate()
    {
        if (IsOutOfRange())
        {
            toward *= -1;
            direction *= -1;
        }

        transform.localScale = new Vector3(toward, 1, 1);
        transform.position += new Vector3(direction, 0, 0);
    }

    private bool IsOutOfRange()
    {
        float currentX = transform.position.x;
        float rightWall = 2.8f;
        float leftWall = -2.8f;

        return currentX > rightWall || currentX < leftWall;
    }
}
