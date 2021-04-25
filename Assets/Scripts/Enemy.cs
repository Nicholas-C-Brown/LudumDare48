using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameController controller;

    private Rigidbody2D myRigidbody;
    private bool moving;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        myRigidbody = GetComponent<Rigidbody2D>();
        moving = true;
        controller.GameOverAction += () => moving = false;
    }

    void Update()
    {
        if (moving) myRigidbody.velocity = new Vector2(Globals.MOVE_SPEED.x, myRigidbody.velocity.y);
        else myRigidbody.velocity = Vector2.zero;
    }
}
