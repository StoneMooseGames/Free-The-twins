using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public int enemyID;

    public KillGoal(int amountNeeded, int EnemyID, Quest quest)
    {
        countCurrent = 0;
        countNeeded = amountNeeded;
        completed = false;
        this.quest = quest;
        this.enemyID = EnemyID;
        EventController.OnEnemyDied += EnemyKilled;
    }

    void EnemyKilled(int enemyID)
    {
        if(this.enemyID == enemyID)
        {
            Increment(1);
        }
    }
}
