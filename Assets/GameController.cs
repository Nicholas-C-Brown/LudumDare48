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

}
