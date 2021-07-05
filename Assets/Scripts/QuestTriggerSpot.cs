using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestTriggerSpot : MonoBehaviour
{
    public string triggerName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "playerController")
        {
            Debug.Log("Player entered the trigger " + triggerName);

            UnityEngine.SceneManagement.SceneManager.LoadScene("StartUI");
        }
    }
}
