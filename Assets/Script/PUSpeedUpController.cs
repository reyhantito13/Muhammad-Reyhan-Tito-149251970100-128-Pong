using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude;

    private float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            manager.activeBallSpeedUp = true;
            manager.ballMagnitude = magnitude;
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > manager.DeleteInterval)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
