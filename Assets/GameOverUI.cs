using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameController controller;

    [SerializeField]
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        controller.GameOverAction += () => animator.SetTrigger("Enter"); 
    }

}
