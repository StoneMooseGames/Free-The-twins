using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletBehaviour : MonoBehaviour
{
    private float bulletSpeed;
    public GameObject hitFX;
    public GameObject gunShotFX;
    public int bulletDamage;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
            HitNpc(other);
        }
        if(other.gameObject.tag == "playerController")
        {
            HitPlayer(other);
        }
      Destroy(this.gameObject);
     
    }

    private void HitNpc(Collider other)
    {
        other.gameObject.GetComponent<NpcController>().TakeDamage(bulletDamage);
        other.gameObject.GetComponent<NpcController>().isAlerted = true;
        GameObject instantiatedObj = (GameObject)Instantiate(hitFX, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(instantiatedObj, 1.0f);
    }

    private void HitPlayer(Collider other)
    {
        GameObject instantiatedObj = (GameObject)Instantiate(hitFX, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(instantiatedObj, 1.0f);
        player.GetComponent<PlayerCharacterController>().PlayerTakesDamage(bulletDamage);
    }
}
