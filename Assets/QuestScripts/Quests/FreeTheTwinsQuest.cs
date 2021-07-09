using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTheTwinsQuest : Quest
{

    private bool hasFollowUp = true;
    private string followUpQuestName = "OpenJailDoors";
    GameObject[] sheriffsMen;

    void Awake()
    {
        questName = "Kill The Sheriff";
        description = "Kill The Sheriff";
        itemRewards = new List<string>() { "200£", "Binoculars" };
        goal = new KillGoal(1, 0, this);
        sheriffsMen = GameObject.Find("Environment").GetComponent<Environment>().sheriffsMen;
        
    }

    public override void Complete()
    {
        AdditionalParameters();
        if (hasFollowUp)
        {
            GameObject questController = GameObject.Find("QuestController");
            questController.GetComponent<QuestController>().AssignQuest(followUpQuestName);
            
        }
        base.Complete();
       
    }


    void AdditionalParameters()
    {
        Debug.Log("Setting additional parameters");
        SetAllCowboysAlerted();
       
    }

     public void SetAllCowboysAlerted()
        {
            foreach (GameObject sheriffsMan in sheriffsMen)
            {
                sheriffsMan.GetComponent<NpcController>().SetAlertedState(true);
            }
        }
}
