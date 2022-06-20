using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Debug.Log("Kecepatan Paddle : " + speed);
    }

    private void Update()
    {
        // get input 
        Vector3 movement = GetInput();

        // move object 
        MoveObject(movement);
    }
    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }

    public void SpeedUpPaddle()
    {
        speed *= 2;
    }
    public void DeactivateSpeedUpPaddle()
    {
        speed /= 2;
    }
    public void ExtendPaddle(GameObject paddle)
    {
        paddle.transform.localScale += new Vector3(0, paddle.transform.localScale.y, 2);
    }
    public void DeactivateExtendPaddle(GameObject paddle)
    {
        paddle.transform.localScale -= new Vector3(0, paddle.transform.localScale.y/2, 2);
    }
}