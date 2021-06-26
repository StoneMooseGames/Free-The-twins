using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float walkingSpeed = 1.0f;
    private Animator npcAnimator;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        
        npcAnimator = this.gameObject.GetComponentInChildren<Animator>();
        npcAnimator.SetBool("isWalking", true);
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckSurroundings();
        MoveNpc(isAlive);
    }

    private void CheckSurroundings()
    {

    }

    private void MoveNpc(bool isAlive)
    {
        while(isAlive)
        {
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
        }
       
    }

}
