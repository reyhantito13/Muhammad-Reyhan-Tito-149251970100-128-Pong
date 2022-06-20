using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    private float timer;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList;

    public GameObject ball;
    public float ballMagnitude;
    float BallSpeedUpDuration;
    public bool activeBallSpeedUp;

    public GameObject leftPaddle, rightPaddle;

    float durationExtendUpPadLeft;
    float durationExtendUpPadRight;
    float durationSpeedUpPadLeft;
    float durationSpeedUpPadRight;

    public bool activeExtendUpPadLeft = false;
    public bool activeExtendUpPadRight = false;
    public bool activeSpeedUpPadLeft = false;
    public bool activeSpeedUpPadRight = false;

    [SerializeField] public float DeleteInterval;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
        // Ball Speed Up Buff Duration
        if (activeBallSpeedUp == true)
        {
            if (BallSpeedUpDuration >= 10)
            {
                ball.GetComponent<BallController>().DeactivatePUSpeedUp(ballMagnitude);
                activeBallSpeedUp = false;
                BallSpeedUpDuration -= 10;
            }
            BallSpeedUpDuration += Time.deltaTime;
        }

        // Right Paddle Extend Buff Duration
        if (activeExtendUpPadRight == true)
        {
            if (durationExtendUpPadRight >= 5)
            {
                rightPaddle.GetComponent<PaddleController>().DeactivateExtendPaddle(rightPaddle);
                activeExtendUpPadRight = false;   
                durationExtendUpPadRight -= 5;
            }
            durationExtendUpPadRight += Time.deltaTime;
        }
        
        // Left Paddle Extend Buff Duration
        if (activeExtendUpPadLeft == true)
        {
            if (durationExtendUpPadLeft >= 5)
            {
                leftPaddle.GetComponent<PaddleController>().DeactivateExtendPaddle(leftPaddle);
                activeExtendUpPadLeft = false;
                durationExtendUpPadLeft -= 5;
            }
            durationExtendUpPadLeft += Time.deltaTime;
        }
        
        // Right Paddle Speed Up Buff Duration
        if (activeSpeedUpPadRight == true)
        {
            if (durationSpeedUpPadRight >= 5)
            {
                rightPaddle.GetComponent<PaddleController>().DeactivateSpeedUpPaddle();
                activeSpeedUpPadRight = false;
                durationSpeedUpPadRight -= 5;
            }
            durationSpeedUpPadRight += Time.deltaTime;
        }
        // Left Paddle Speed Up Buff Duration
        if (activeSpeedUpPadLeft == true)
        {
            if (durationSpeedUpPadLeft >= 5)
            {
                leftPaddle.GetComponent<PaddleController>().DeactivateSpeedUpPaddle();
                activeSpeedUpPadLeft = false;
                durationSpeedUpPadLeft -= 5;
            }
            durationSpeedUpPadLeft += Time.deltaTime;
        }
    }
    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            RemovePowerUp(powerUpList[0]);
            return;
        }

        if (position.x < powerUpAreaMin.x || 
            position.x > powerUpAreaMax.x || 
            position.y < powerUpAreaMin.y || 
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], 
            new Vector3(position.x, position.y, 
            powerUpTemplateList[randomIndex].transform.position.z), 
            Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
