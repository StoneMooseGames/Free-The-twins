using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private string questName;
    private QuestController questController;
    private Quest quest;


    // Start is called before the first frame update
    void Start()
    {
        questController = FindObjectOfType<QuestController>();
    }

    
    public void GiveQuest()
    {
        quest = questController.AssignQuest(questName);
        Debug.Log("QuestGiver is giving quest: " + questName);
       
    }
}
