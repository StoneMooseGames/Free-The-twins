using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float walkingSpeed = 1.0f;
    private Animator npcAnimator;
    public bool npcIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
        npcAnimator = this.gameObject.GetComponentInChildren<Animator>();
        npcAnimator.SetBool("isWalking", true);
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (npcIsAlive)
        {
            MoveNpc();
        }
       
    }

    private void MoveNpc()
    {
        transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
     
    }

}
