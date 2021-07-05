using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenJailDoors : Quest
{
    //change this if this quest has a follow up to 'true' and add the name of the quest
    private bool hasFollowUp = true;
    private string followUpQuestName = "EscapeToTrain";

    void Awake()
    {
        questName = "Open jail doors";
        description = "Open jail doors";
        itemRewards = new List<string>() { "100£"};
        goal = new CollectionGoal(2, 1, this);


    }

    public override void Complete()
    {
        if(hasFollowUp)
        {
           GameObject questController = GameObject.Find("QuestController");
           questController.GetComponent<QuestController>().AssignQuest(followUpQuestName);

        }
        base.Complete();

    }
}
