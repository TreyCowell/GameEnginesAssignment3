// Game Eng Lab 2 Movement Script, Implemented into Assignment 3
// Treyton Cowell - 100745472
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movespeed;
    private float jumpspeed;
    private float dirX, dirZ;
    bool isGrounded; //Init bool check

    // Start is called before the first frame update
    void Start()
    {
        movespeed = 7f;
        jumpspeed = 6f;
        rb = GetComponent<Rigidbody>();
    }

    //Unitys OnTrigger function
    void OnCollisionEnter(Collision col)
    {
        isGrounded = true; //checking if colliding
    }

    void OnCollisionExit(Collision col)
    {
        isGrounded = false; //checking if colliding
    }

    // Update is called once per frame
    void Update()
    {
        // Unitys GetKeyDown
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) //if not colliding then allow jump
        {
            rb.AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
        }

        dirX = Input.GetAxis("Horizontal") * movespeed;
        dirZ = Input.GetAxis("Vertical") * movespeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}