using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Transform player; // Reference to the player's transform
    private Vector3 tempPos; // Temporary variable to store the camera's position

    // Minimum and maximum x values for the camera's position
    [SerializeField]
    private float minX, maxX;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Find the player object by tag and get its transform component
        // Debug.Log("The selected index: " + GameManager.instance.CharIndex);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player) // If the player transform is not found, exit the function
            return;
        
        tempPos = transform.position; // Get the current position of camera
        tempPos.x = player.position.x; // Set the x position of the camera to the x position of the player

        // Clamp the x position of the camera to be within the minX and maxX bounds
        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos; // Update the camera's position

    }
}
