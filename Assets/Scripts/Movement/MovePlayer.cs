using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [Header("Controller")]
    [SerializeField]
    private GameController controller;

    [Header("Components")]
    [SerializeField]
    private Rigidbody2D player;
    [SerializeField]
    private BoxCollider2D collider2d;
    [SerializeField]
    private Animator animator;
    

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 1.5f;
    [SerializeField]
    private float minX = -6, maxX = -4;
    private float moveDir = 1;

    [SerializeField]
    private float jumpForce = 550;

    private enum State
    {
        ON_GROUND,
        JUMPING,
        IN_AIR,
        SLIDING
    }

    private State state;

    void Update()
    {
        //Update to IN_AIR state the frame after the player jumps
        if (IsJumping()) state = State.IN_AIR;

        GetInput();
        Move();
        Animate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy Check
        if (collision.gameObject.CompareTag(Globals.ENEMY_TAG))
        {
            Die();
        }

        //Ground Check
        if (InAir() && collision.gameObject.CompareTag(Globals.GROUND_TAG))
        {
            state = State.ON_GROUND;
        }
    }

    private void GetInput()
    {
        moveDir = 0;
        // check for horizontal movement
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = -1 * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDir = 1 * moveSpeed;
        }

        // check if we're sliding
        if (Input.GetKey(KeyCode.LeftShift) && OnGround())
        {
            state = State.SLIDING;
        } 
        else if(!Input.GetKey(KeyCode.LeftShift) && IsSliding())
        {
            state = State.ON_GROUND;
        }

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space) && (OnGround() || IsSliding())) state = State.JUMPING;
    }

    private void Move()
    {
        if (IsJumping()) player.AddForce(Vector2.up * jumpForce);

        // Add horizontal movement to player
        player.velocity = new Vector2(moveDir, player.velocity.y);
        player.position = new Vector2(Mathf.Clamp(player.position.x, minX, maxX), player.position.y);
    }

    private void Animate()
    {
        if (IsJumping())
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Sliding", false);
        }
        if (IsSliding())
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Sliding", true);
        }
        if (OnGround())
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Sliding", false);
        }
    }

    private void Die()
    {
        //Stop map/enemy movement (Pause Event?)
        controller.GameOver();

        //Disable Collider
        collider2d.enabled = false;

        //Play die animation
        animator.SetTrigger("Die");
    }

    private bool OnGround()
    {
        return state == State.ON_GROUND;
    }

    private bool IsSliding()
    {
        return state == State.SLIDING;
    }

    private bool IsJumping()
    {
        return state == State.JUMPING;
    }

    private bool InAir()
    {
        return state == State.IN_AIR;
    }
}
