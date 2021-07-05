using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{
    public GameObject interActText;
    public GameObject healthText;
    public GameObject controllerPrefab;
    public GameObject missionTextArea;


    private void Start()
    {
        
        PauseGame();
    }

    private void Update()
    {
    }

    public void ContinueGame()
    {
        
        Time.timeScale = 1;
        missionTextArea.SetActive(false);

    }

    public void PauseGame()
    {
        
        Time.timeScale = 0;
    }
}

