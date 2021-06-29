using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    private Animator openCloseDoor;
    private bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        openCloseDoor = GetComponent<Animator>();
        gameObject.tag = "OpenClose";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractWithDoor()
    {
        if(isOpen)
        {
            openCloseDoor.SetTrigger("closeDoor");
            isOpen = false;
        }
        else
        {
            openCloseDoor.SetTrigger("openDoor");
            isOpen = true;
        }
 
    }

}
