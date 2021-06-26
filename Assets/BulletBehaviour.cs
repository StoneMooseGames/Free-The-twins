using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameObject instantiatedObj = (GameObject)Instantiate(hitFX, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(instantiatedObj, 1.0f);

        Destroy(this.gameObject);

       
    }

}
