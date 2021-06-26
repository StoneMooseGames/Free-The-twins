using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletBehaviour : MonoBehaviour
{
    private float bulletSpeed;
    public GameObject hitFX;
    public GameObject gunShotFX;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = GameObject.Find("Player").GetComponent<PlayerCharacterController>().bulletSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        Destroy(this.gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "KillableNpc")
        {
            KillNpc(other);
        }
      Destroy(this.gameObject);
     
    }

    private void KillNpc(Collider other)
    {
        Debug.Log("hit" + other.name);
        other.GetComponentInChildren<Animator>().SetBool("isWalking", false);
        other.GetComponentInChildren<Animator>().SetBool("isDead", true);
        other.GetComponent<NpcController>().npcIsAlive = false;
        GameObject instantiatedObj = (GameObject)Instantiate(hitFX, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(instantiatedObj, 1.0f);
        other.GetComponent<Rigidbody>().isKinematic = true;
        other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Destroy(other.gameObject, 10.0f);
    }
}
