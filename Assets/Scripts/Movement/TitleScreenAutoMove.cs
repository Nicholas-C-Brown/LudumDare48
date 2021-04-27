using UnityEngine;

public class TitleScreenAutoMove : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField]
    private GameController controller;

    [Header("Components")]
    [SerializeField]
    private Rigidbody2D player;

    [SerializeField]
    private BoxCollider2D standCollider, slideCollider;

    private BoxCollider2D enabledCollider;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private LayerMask mask;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 1.5f;

    [SerializeField]
    private float minX = -6, maxX = -4;

    [SerializeField]
    private float boundsX = -10, boundsY = -5;

    private float moveDir = 1;

    [SerializeField]
    private float jumpForce = 550;

    private enum State
    {
        ON_GROUND,
        JUMPING,
        IN_AIR,
        SLIDING,
        DYING
    }

    [SerializeField]
    private State state;

    private void Start()
    {
        enabledCollider = standCollider;
    }

    private void Update()
    {
        //Update to IN AIR state the frame after jumping
        if (IsState(State.JUMPING)) state = State.IN_AIR;

        //If player is out of bounds then trigger death
        if (IsOOB()) Die();

        //Perform ground check and update state accordingly
        if (GroundCheck() && IsState(State.IN_AIR))
            state = State.ON_GROUND;
        else if (!GroundCheck() && (IsState(State.ON_GROUND) || IsState(State.SLIDING)))
            state = State.IN_AIR;

        //Update player collider
        if (IsState(State.SLIDING))
        {
            slideCollider.enabled = true;
            standCollider.enabled = false;
            enabledCollider = slideCollider;
        }
        else if (!IsState(State.DYING))
        {
            slideCollider.enabled = false;
            standCollider.enabled = true;
            enabledCollider = standCollider;
        }

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
    }

    private void GetInput()
    {
        moveDir = 0;
        // check for horizontal movement
        if (Input.GetKey(KeyCode.A) && player.position.x > minX)
        {
            moveDir = -1 * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D) && player.position.x < maxX)
        {
            moveDir = 1 * moveSpeed;
        }

        // check if we're sliding
        if (Input.GetKey(KeyCode.LeftShift) && IsState(State.ON_GROUND))
        {
            state = State.SLIDING;
        }
        //TODO add roof check
        else if (!Input.GetKey(KeyCode.LeftShift) && IsState(State.SLIDING) && !RoofCheck())
        {
            state = State.ON_GROUND;
        }

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space) &&
            (IsState(State.ON_GROUND) || IsState(State.SLIDING)))
        {
            state = State.JUMPING;
        }
    }

    private void Move()
    {
        if (IsState(State.JUMPING)) player.AddForce(Vector2.up * jumpForce);

        // Add horizontal movement to player
        player.velocity = new Vector2(moveDir, player.velocity.y);
    }

    private void Animate()
    {
        if (IsState(State.JUMPING))
        {
            animator.SetBool("Sliding", false);
            animator.SetBool("Falling", false);

            animator.SetTrigger("Jump");
        }

        else if (IsState(State.IN_AIR))
        {
            animator.SetBool("Falling", true);
            animator.SetBool("Sliding", false);
        }

        else if (IsState(State.SLIDING))
        {
            animator.SetBool("Falling", false);
            animator.SetBool("Sliding", true);
        }

        else if (IsState(State.ON_GROUND))
        {
            animator.SetBool("Falling", false);
            animator.SetBool("Sliding", false);
        }
    }

    public void Die()
    {
        //If player is already dying don't die again
        if (IsState(State.DYING)) return;

        state = State.DYING;

        //Stop map/enemy movement
        controller.GameOver();

        //Destroy Colliders
        standCollider.enabled = false;
        slideCollider.enabled = false;

        //Play die animation
        animator.SetTrigger("Die");
    }

    private bool GroundCheck()
    {
        float extraHeight = 0.5f;
        RaycastHit2D hit = Physics2D.BoxCast(enabledCollider.bounds.center, enabledCollider.bounds.size, 0f, Vector2.down, extraHeight, mask);

        if (hit.collider == null) return false;
        //Only return true if we collide with ground
        else return hit.collider.CompareTag(Globals.GROUND_TAG);
    }

    private bool RoofCheck()
    {
        float extraHeight = 0.5f;
        RaycastHit2D hit = Physics2D.BoxCast(enabledCollider.bounds.center + (Vector3.up * extraHeight), enabledCollider.bounds.size, 0f, Vector2.up, 0, mask);

        if (hit.collider == null) return false;
        //Only return true if we collide with ground
        else return hit.collider.CompareTag(Globals.GROUND_TAG);
    }

    public bool IsOOB()
    {
        return player.position.y < boundsY || player.position.x < boundsX;
    }

    private bool IsState(State state)
    {
        return this.state == state;
    }
}