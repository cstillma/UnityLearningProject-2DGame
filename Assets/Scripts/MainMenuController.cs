using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    
    // Load the scene named "MainMenu"
    public void PlayGame() {
        // Debug.Log("Button is pressed");

        // Get the name of the currently selected UI element (button) and parse it to an integer
        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selectedCharacter; // Set the selected character index in the GameManager

        SceneManager.LoadScene("Gameplay"); // Load the "Gameplay" scene

        // string clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        // Debug.Log("Index: " + clickedObj);
        // EventSystem.current.currentSelectedGameObject.name;
    }

}
