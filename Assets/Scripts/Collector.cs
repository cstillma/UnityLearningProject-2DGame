using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Tags to identify enemy and player objects
    private string ENEMY_TAG = "Enemy";
    private string PLAYER_TAG = "Player";
    // This method is called when another collider enters the trigger collider attached to the object where this script is attached
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Enemy" or "Player"
        if (collision.CompareTag(ENEMY_TAG) || collision.CompareTag(PLAYER_TAG)) {
            Destroy(collision.gameObject); // Destroy the collided game object
        }
    }

}
