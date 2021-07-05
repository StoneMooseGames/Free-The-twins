using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;
    public string description;
    public Goal goal;
    public bool completed;
    public List<string> itemRewards;

    public virtual void Complete()
    {
        Debug.Log("Quest completed");
        EventController.QuestCompleted(this);
        GrantReward();
    }

    public void GrantReward()
    {
        Debug.Log("Turning in quest... granting reward.");
        foreach (string item in itemRewards)
        {
            Debug.Log("rewarded with: " + item);
        }
        Destroy(this);
    }
        
}
