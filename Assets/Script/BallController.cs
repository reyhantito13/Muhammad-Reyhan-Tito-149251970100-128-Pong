using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    public float maxVelocity;
    public float minVelocity;

    private Rigidbody2D rig;

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
        Debug.Log("Ball Speed : " + rig.velocity);
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

    }
}
