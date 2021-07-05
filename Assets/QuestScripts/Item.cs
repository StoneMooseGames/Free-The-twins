using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public bool hasTrigger;

    // Use this for initialization
    void Start()
    {
        //itemID = 0;
    }

    public void Get()
    {
        EventController.ItemFound(itemID);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(hasTrigger)
        {
            Get();
        }
    }
}
