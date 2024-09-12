using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    // Public variable to set the speed of the monster, hidden in the inspector
    [HideInInspector]
    public float speed;
    private Rigidbody2D myBody; // Private variable to store the Rigidbody2D component

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the same GameObject
        // speed = 7;
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y); // Set the velocity of the Rigidbody2D to move the monster horizontally
    }

}
