using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{

    [SerializeField]
    GameController controller;

    [SerializeField]
    Animator animator;

    private void Start()
    {
        controller.StopMovement += () => animator.SetTrigger("Enter");
    }

    public void OnClick()
    {
        animator.SetTrigger("Exit");
        CodeMonkey.Utils.FunctionTimer.Create(() => controller.Restart(), 1f); 
    }

}
