using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{

    public List<Quest> assignedQuests = new List<Quest>();

    [SerializeField]
    private QuestUiItem questUiItem;
    [SerializeField]
    private Transform questUIParent;

    private QuestDataBase questDatabase;

    private void Start()
    {
        questDatabase = GetComponent<QuestDataBase>();
    }

    public Quest AssignQuest(string questName)
    {
        if(assignedQuests.Find(quest => quest.questName == questName))
        {
            Debug.LogWarning("Quest already assigned");
            return null;
        }
        
        Quest questToAdd = (Quest)gameObject.AddComponent(System.Type.GetType(questName));
        assignedQuests.Add(questToAdd);
        Debug.Log(questToAdd);
        questDatabase.AddQuest(questToAdd);

        QuestUiItem questUI = Instantiate(questUiItem, questUIParent);
        questUI.Setup(questToAdd);
        return questToAdd;
    }
}
