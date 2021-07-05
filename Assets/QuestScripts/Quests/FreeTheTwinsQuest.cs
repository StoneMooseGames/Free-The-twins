using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTheTwinsQuest : Quest
{
    void Awake()
    {
        questName = "Kill The Sheriff";
        description = "Kill The Sheriff";
        itemRewards = new List<string>() { "200£", "Binoculars" };
        goal = new KillGoal(1, 0, this);

        
    }

    public override void Complete()
    {
        base.Complete();
       
    }
}
