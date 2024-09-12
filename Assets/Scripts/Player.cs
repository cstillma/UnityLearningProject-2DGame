using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Serialized fields to set movement and jump forces in the inspector
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    // public float maxVelocity = 22f;
    private float movementX; // Private variable to store horizontal movement input
    // Serialized field to reference the Rigidbody2D component
    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim; // Private variable to store the Animator component
    private string WALK_ANIMATION = "Walk"; // String to store the name of the walk animation
    private SpriteRenderer sr; // Private variable to store the SpriteRenderer component
    private bool isGrounded; // Boolean to check if the player is grounded
    // Tags to identify ground and enemy objects
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the same GameObject
        anim = GetComponent<Animator>(); // Get the Animator component attached to the same GameObject
        sr = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to the same GameObject
        // myBody.AddForce(new Vector2(2, 2));
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard(); 
        AnimatePlayer();
        PlayerJump();
    }

    // private void FixedUpdate()
    // {
    //     PlayerJump();
    // }

    // Method to move the player using keyboard input
    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal"); // Get the horizontal movement input
        // Debug.Log("move X value is: " + movementX);
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce; // Move the player horizontally

    }

    // Method to animate the player
    void AnimatePlayer() {
        // we are going to the right side
        if (movementX > 0) 
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        // we are going to the left side 
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else // idle
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    // Method to handle player jump
    void PlayerJump() {
        // Check if the jump button is pressed and the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded) {
            // Debug.Log("Jump Pressed");
            isGrounded = false; // Set isGrounded to false as the player is jumping
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Add an upward force to the player's Rigidbody2D to make the player jump
        }
    }

    // Method called when the player collides with another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an object tagged as "Ground"
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true; // Set isGrounded to true as the player is on the ground
            // Debug.Log("We landed on ground");
        }

        // Check if the player collided with an object tagged as "Enemy"
        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject); // Destroy the player game object
        }
    }

    // Method called when the player enters a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player entered a trigger collider tagged as "Enemy"
        if (collision.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject); // Destroy the player game object
        }
    }
}
