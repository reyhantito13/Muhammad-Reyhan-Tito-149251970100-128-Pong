using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    public float maxVelocity;
    public float minVelocity;
    public int paddle;
    private Rigidbody2D rig;

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = speed;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        if (rig.velocity.magnitude > maxVelocity)
        {
            rig.velocity = rig.velocity.normalized * maxVelocity;
        }
        rig.velocity *= magnitude;
    }
    public void DeactivatePUSpeedUp(float magnitude)
    {
        rig.velocity /= magnitude;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Left Paddle")
        {
            paddle = 0;
        }
        if (collision.gameObject.name == "Right Paddle")
        {
            paddle = 1;
        }
    }
}
