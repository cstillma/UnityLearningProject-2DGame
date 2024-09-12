using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    // Method to restart the game by reloading the current scene
    public void RestartGame() {
        // SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current active scene
    }

    // Method to navigate to the main menu
    public void HomeButton() {
        SceneManager.LoadScene("MainMenu"); // Load the scene named "MainMenu"
    }
}
