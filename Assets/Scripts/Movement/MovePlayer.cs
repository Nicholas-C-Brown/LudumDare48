using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    //Player variables
    private Rigidbody2D player;
    public float hSpeed = 1;
    public float jumpForce = 490;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            hSpeed = -500;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            hSpeed = 500;
        }

        // check for jump
        if (Input.GetKeyDown(KeyCode.Space)) jumping = true;
    }

    private void move()
    {
        if (jumping) player.AddForce(new Vector2(hSpeed, jumpForce));
        else player.AddForce(new Vector2(hSpeed, 0));
        
    }
}
