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
    public GameObject youDied;
    public GameObject paused;



    private void Awake()
    {
        youDied.SetActive(false);
        paused.SetActive(false);
        PauseGame();
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.Q))
        {
            GameObject.Find("Player").gameObject.GetComponent<PlayerCharacterController>().isPaused = true;
            Debug.Log("Escape Pressed");
            paused.SetActive(true);
            PauseGame();
           
        }
    }
    

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        controllerPrefab.GetComponent<ECM.Components.MouseLook>().verticalSensitivity = 0;
        controllerPrefab.GetComponent<ECM.Components.MouseLook>().lateralSensitivity = 0;
        controllerPrefab.GetComponent<ECM.Components.MouseLook>().lockCursor = false;
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        Debug.Log("continue pressed");
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        controllerPrefab.GetComponent<ECM.Components.MouseLook>().verticalSensitivity = 2;
        controllerPrefab.GetComponent<ECM.Components.MouseLook>().lateralSensitivity = 2;
        controllerPrefab.GetComponent<ECM.Components.MouseLook>().lockCursor = true;
        missionTextArea.SetActive(false);
        paused.SetActive(false);

    }


}

