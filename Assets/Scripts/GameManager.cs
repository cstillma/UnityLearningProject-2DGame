using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance of GameManager

    // Array to hold different character GameObjects
    [SerializeField]
    private GameObject[] characters;

    private int _charIndex; // Private variable to store the selected character index
    public int CharIndex // Public property to get and set the character index
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Implementing the Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager instances
        }
    }

    // OnEnable is called when the object becomes enabled and active
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading; // Subscribe to the sceneLoaded event
    }

    // OnDisable is called when the behaviour becomes disabled or inactive
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; // Unsubscribe from the sceneLoaded event
    }
    // Method to handle actions when a new scene is loaded
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        // Check if the loaded scene is named "Gameplay"
        if (scene.name == "Gameplay") {
            Instantiate(characters[CharIndex]); // Instantiate the selected character in the scene
        }

    }

}
