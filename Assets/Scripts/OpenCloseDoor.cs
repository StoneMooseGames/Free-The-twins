using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    private Animator openCloseDoor;
    public bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "OpenClose";
       
        openCloseDoor = gameObject.GetComponent<Animator>();
        InteractWithDoor(isOpen);

    }


    public void InteractWithDoor(bool isDoorOpen)
    {
        Debug.Log(isDoorOpen);
        openCloseDoor.SetBool("isOpen", isDoorOpen);
    
    }

}
