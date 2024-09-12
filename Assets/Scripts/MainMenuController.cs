using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    
    public void PlayGame() {
        // Debug.Log("Button is pressed");

        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selectedCharacter;

        SceneManager.LoadScene("Gameplay");

        // string clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        // Debug.Log("Index: " + clickedObj);
        // EventSystem.current.currentSelectedGameObject.name;
    }

}
