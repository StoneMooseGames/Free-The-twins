using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject interActText;
    public GameObject healthText;
    public GameObject controllerPrefab;
    public GameObject missionTextArea;
    public GameObject youDied;
    public GameObject paused;
    public void Awake()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("StartUI");
    }

    
}
