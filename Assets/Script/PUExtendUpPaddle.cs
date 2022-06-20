using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtendUpPaddle : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public BallController ballController;
    float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision = ball)
        {
            if (ballController.paddle == 0)
            {
                manager.leftPaddle.GetComponent<PaddleController>().ExtendPaddle(manager.leftPaddle);
                manager.RemovePowerUp(gameObject);
            }
            if (ballController.paddle == 1)
            {
                manager.activeExtendUpPadRight = true;
                manager.rightPaddle.GetComponent<PaddleController>().ExtendPaddle(manager.rightPaddle);
                manager.RemovePowerUp(gameObject);
            }
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= manager.DeleteInterval)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
