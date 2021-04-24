using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    //Player variables
    private Rigidbody2D player;
    public float hSpeed = 1;
    public float jumpForce = 5000;
    private bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        move();
    }

    private void getInput()
    {
        hSpeed = 0;
        jumping = false;
        // check for horizontal movement
        if (Input.GetKeyDown(KeyCode.A)) hSpeed = -1;
        else if (Input.GetKeyDown(KeyCode.D)) hSpeed = 1;

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space)) jumping = true;
    }

    private void move()
    {
        // translate if horizontal movement exists
        if (hSpeed != 0) transform.Translate(new Vector2(hSpeed, player.velocity.y));
        if (jumping) player.AddForce(new Vector2(0, jumpForce));
        
    }
}
