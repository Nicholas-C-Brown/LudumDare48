using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    //Player components
    private Rigidbody2D player;
    private Animator animator;
    private BoxCollider2D collider;

    //Movement
    private float moveDir = 1;
    [SerializeField]
    private float moveSpeed = 1.5f;
    [SerializeField]
    private float minX = -6, maxX = -4;

    [SerializeField]
    private float jumpForce = 550;

    private enum State
    {
        ON_GROUND,
        JUMPING,
        IN_AIR
    }

    private State state;
    
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

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

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space) && OnGround()) state = State.JUMPING;
    }

    private void Move()
    {
        if (IsJumping()) player.AddForce(Vector2.up * jumpForce);

        player.velocity = new Vector2(moveDir, player.velocity.y);
        player.position = new Vector2(Mathf.Clamp(player.position.x, minX, maxX), player.position.y);
    }

    private void Animate()
    {
        if (IsJumping()) animator.SetBool("Jumping", true);
        if (OnGround()) animator.SetBool("Jumping", false);
    }

    private bool OnGround()
    {
        return state == State.ON_GROUND;
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
