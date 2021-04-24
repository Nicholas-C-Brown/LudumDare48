using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Action GameOverAction;

    public void GameOver()
    {
        GameOverAction?.Invoke();
    }

    public void Restart()
    {
        //reload game scene
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayGame()
    {
       // SceneManager.UnloadSceneAsync("TitleScene");
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        Debug.Log("Quit to Title");
    }

    public void QuitToDesktop()
    {
        Debug.Log("Quit to Desktop");
        Application.Quit();
    }

}
