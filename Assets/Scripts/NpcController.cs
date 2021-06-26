using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public float walkingSpeed = 1.0f;
    private Animator npcAnimator;
    public bool npcIsAlive = true;
    public GameObject[] checkPoints = new GameObject[3];
    private NavMeshAgent agent;
    private float walkRadius = 20.0f;
    public bool doWayPoints;

    // Start is called before the first frame update
    void Start()
    {
        checkPoints[0] = GameObject.Find("Checkpoint1");
        agent = GetComponent<NavMeshAgent>();
        npcAnimator = this.gameObject.GetComponentInChildren<Animator>();
        doWayPoints = true;
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (npcIsAlive)
        {
            if (doWayPoints)
            {
                float dist = GetComponent<NavMeshAgent>().remainingDistance;
                if (dist != Mathf.Infinity && GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && GetComponent<NavMeshAgent>().remainingDistance == 0)//Arrived.
                {
                    Wander();
                }
            }
        }
       
    }

    void Wander()
    {
        agent.speed = walkingSpeed;
        npcAnimator.SetBool("isWalking", true);
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        Vector3 finalPosition = hit.position;
        GetComponent<NavMeshAgent>().destination = finalPosition;
    }
}

