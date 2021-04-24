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

    [SerializeField]
    private bool slide;
    
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
        slide = false;
        // check for horizontal movement
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = -1 * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDir = 1 * moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            slide = true;
        }

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space)) jumping = true;
    }

    private void Move()
    {
        if (jumping)
        {
            animator.SetBool("Jumping", true);
            player.AddForce(Vector2.up * jumpForce);
        } else
        {
            animator.SetBool("Jumping", false);
        }
        player.velocity = new Vector2(moveDir, player.velocity.y);

        if (slide)
        {
            animator.SetBool("Sliding", true);
            Debug.Log("Yo we sliding");
        } else
        {
            animator.SetBool("Sliding", false);
        }
        
    }

}
