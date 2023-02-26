using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    bool isBot = false;

    [SerializeField]
    float velocity = 0.0f;

    [SerializeField]
    GameObject ball = null;

    void Start()
    {
        if (isBot)
            velocity = 2.0f;
        else
            velocity = 5.0f;
    }

    void Update()
    {
        if (GameManager.Instance.getStartFlag())
        {
            if (isBot)
                ControlBot();
            else
                MovePaddle();
        }
    }

    void ControlBot()
    {
        Vector3 ballPos = ball.transform.position;
        if (ballPos.y - transform.position.y > 0)
            transform.Translate(0, velocity * Time.deltaTime, 0);
        else
            transform.Translate(0, -velocity * Time.deltaTime, 0);
    }

    void MovePaddle()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(0, velocity * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0, -velocity * Time.deltaTime, 0);
    }
}
