using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeToTrain : Quest
{
    
    void Awake()
    {
        questName = "Escape to train";
        description = "Escape to the train";
        itemRewards = new List<string>() { "Ticket To escape"};
        goal = new CollectionGoal(1, 2, this);


    }

    public override void Complete()
    {
        base.Complete();

    }
}
