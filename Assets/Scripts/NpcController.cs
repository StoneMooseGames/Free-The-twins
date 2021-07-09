using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public float walkingSpeed = 1.0f;
    private Animator npcAnimator;
    public bool npcIsAlive = true;
    public bool isPatrolling = false;
    public Transform[] moveSpots;
    private NavMeshAgent agent;
    private float walkRadius = 20.0f;
    private float waitTime;
    public float startWaitTime = 2.0f;
    private int randomSpot;
    public bool isIdle;
    public bool isShooting;
    public bool isAlerted;
    private int npcHealth;
    public int npcHealthMax;
    private Rigidbody bulletClone;
    public Rigidbody bullet;
    private float shootTimer;
    private GameObject player;
    public int enemyID;
    private GameObject[] sheriffsMen;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("playerController");
        bullet = GameObject.Find("Environment").GetComponent<Environment>().useablePrefabs[0].gameObject.GetComponent<Rigidbody>();
        sheriffsMen = GameObject.Find("Environment").GetComponent<Environment>().sheriffsMen;
        npcHealthMax = 200;
        agent = GetComponent<NavMeshAgent>();
        npcAnimator = this.gameObject.GetComponentInChildren<Animator>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        npcAnimator.speed = walkingSpeed - 0.5f;
        npcHealth = npcHealthMax;
        shootTimer = npcAnimator.GetCurrentAnimatorClipInfo(0).Length / npcAnimator.speed;

    }

    // Update is called once per frame
    void Update()
    {

        if (!npcIsAlive) KillNpc();
        if (npcIsAlive)
        {
            if (isAlerted)
            {
                Chase();
            }
            
            if(!isIdle)
            {
                if (isShooting)
                {
                    transform.LookAt(GameObject.FindGameObjectWithTag("playerController").transform.position);
                    //Debug.Log("looking at player: " + GameObject.FindGameObjectWithTag("playerController").transform.position);
                    shooting();
                }
                if (!isPatrolling && !isShooting && !isAlerted)
                {
                    float dist = GetComponent<NavMeshAgent>().remainingDistance;
                    if (dist != Mathf.Infinity && GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && GetComponent<NavMeshAgent>().remainingDistance == 0)//Arrived.
                    {
                        Wander();
                    }
                }
                if (isPatrolling)
                {
                    Patrol();

                }
                
            }
            
        }
       
    }

    void Wander()
    {
        agent.speed = walkingSpeed;
        npcAnimator.speed = walkingSpeed - 0.5f;
        npcAnimator.SetBool("isWalking", true);
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        Vector3 finalPosition = hit.position;
        GetComponent<NavMeshAgent>().destination = finalPosition;
    }

    void Patrol()
    {
        agent.speed = walkingSpeed;
        npcAnimator.SetBool("isWalking", true);
        GetComponent<NavMeshAgent>().destination = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, walkingSpeed);
        
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) <1.2f)
        {
            
            if (waitTime <=0)
                {
                int tempSpot = randomSpot;
                randomSpot = Random.Range(0, moveSpots.Length);
                if(tempSpot == randomSpot) npcAnimator.SetBool("isWalking", false);
                waitTime = startWaitTime;

                }
            else
            {
                npcAnimator.SetBool("isWalking", false);
                waitTime -= Time.deltaTime;
                transform.rotation = moveSpots[randomSpot].rotation;
            }
        }
  
    }

    void Chase()
    {
        npcAnimator.SetBool("isWalking", false);
        npcAnimator.SetBool("isRunning", true);
        isPatrolling = false;
        agent.speed = walkingSpeed * 3;
        
        float shootingRange = 5f;
        FindTarget();
        SetAlertedState(true);
        if (Vector3.Distance(transform.position, player.transform.position) < shootingRange)
            {
            transform.LookAt(GameObject.FindGameObjectWithTag("playerController").transform.position);
            shooting();
            }
    }
    void shooting()
    {
        
        npcAnimator.speed = 3;
        GetComponent<NavMeshAgent>().destination = transform.position;
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            bulletClone = Instantiate(bullet, gameObject.transform.position + transform.forward + transform.up * 1.2f, gameObject.transform.rotation);
            shootTimer = npcAnimator.GetCurrentAnimatorClipInfo(0).Length / npcAnimator.speed;
        }
        npcAnimator.SetBool("isWalking", false);
        npcAnimator.SetBool("isRunning", false);
        
        npcAnimator.SetBool("isShooting",true);

        if (waitTime <= 0)
        {
            npcAnimator.SetBool("isShooting", false);
            isShooting = false;
            isAlerted = false;
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
            
        }
        
    }

    public void TakeDamage(int damage)
    {
        npcHealth -= damage;
        if (npcHealth <= 0)
        {
            npcIsAlive = false;
            KillNpc();
           
        }
    }

    void KillNpc()
    {
        
        EventController.EnemyDied(enemyID);
        npcAnimator.speed = 3;
        //Debug.Log("hit" + gameObject.name);
        GetComponentInChildren<Animator>().SetBool("isShooting", false);
        GetComponentInChildren<Animator>().SetBool("isWalking", false);
        GetComponentInChildren<Animator>().SetBool("isDead", true);
        GetComponent<NpcController>().npcIsAlive = false;
        GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 10.0f);
    }

    public void SetAlertedState(bool state)
    {
        isAlerted = state;
        
    }

    public void FindTarget()
    {
        float targetRange = 50f;
        if(Vector3.Distance(transform.position,player.transform.position) < targetRange)
        {
            GetComponent<NavMeshAgent>().destination = Vector3.MoveTowards(transform.position,player.transform.position,walkingSpeed * 2);
            
        }
    }

   
}

