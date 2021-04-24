using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    //Player components
    private Rigidbody2D player;
    private Animator animator;

    //Movement
    private float moveDir = 1;
    [SerializeField]
    private float moveSpeed = 2;

    [SerializeField]
    private float jumpForce = 400;
    private bool jumping;
    
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        moveDir = 0;
        jumping = false;
        // check for horizontal movement
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = -1 * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDir = 1 * moveSpeed;
        }

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space)) jumping = true;
    }

    private void Move()
    {
        if (jumping) player.AddForce(Vector2.up * jumpForce);

        player.velocity = new Vector2(moveDir, player.velocity.y);
        
    }
}
