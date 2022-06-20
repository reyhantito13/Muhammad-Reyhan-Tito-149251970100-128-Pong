using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Created by Muhammad Reyhan Tito - 149251970100 - 128");
    }
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void ExitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
