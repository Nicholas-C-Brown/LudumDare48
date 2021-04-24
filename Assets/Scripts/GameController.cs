using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Action GameOverAction;

    private void Start()
    {
        //Reset global move speed
        Globals.MOVE_SPEED = new Vector2(-5f, 0f);
    }

    public void GameOver()
    {
        GameOverAction?.Invoke();
        Globals.MOVE_SPEED = Vector2.zero;
    }

    public void Restart()
    {
        //reload game scene
        SceneManager.LoadScene("MainScene");
    }

    public void QuitToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void QuitToDesktop()
    {
        Debug.Log("Quit to Desktop");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

}
