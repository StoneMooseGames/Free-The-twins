﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static event System.Action<int> OnEnemyDied = delegate { };
    public static event System.Action<int> OnItemFound = delegate { }; //New Item Found Event
    public static event System.Action<Quest> OnQuestProgressChanged = delegate { };
    public static event System.Action<Quest> OnQuestCompleted = delegate { };


    public static void EnemyDied(int enemyID)
    {
        OnEnemyDied(enemyID);
    }

    public static void ItemFound(int itemID) //New Item Found Handler
    {
        OnItemFound(itemID);
    }

    public static void QuestProgressChanged(Quest quest)
    {
        OnQuestProgressChanged(quest);
    }

    public static void QuestCompleted(Quest quest)
    {
        OnQuestCompleted(quest);
    }
}
