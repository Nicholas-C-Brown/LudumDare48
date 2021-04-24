using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameController controller;

    private Rigidbody2D myRigidbody;
    private bool moving;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        moving = true;
        controller.GameOverAction += () => moving = false;
    }

    void Update()
    {
        if(moving) myRigidbody.velocity = new Vector2(-4, myRigidbody.velocity.y);
    }
}
