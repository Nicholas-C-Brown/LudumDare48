using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Action StopMovement;

    public void GameOver()
    {
        StopMovement?.Invoke();
    }

    public void Restart()
    {
        //reload game scene
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Restart");
    }

}
