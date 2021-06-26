using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
   
    
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    private Rigidbody bulletClone;
    private GameObject weapon1;
    private GameObject weapon2;

    // Start is called before the first frame update
    void Start()
    {
        weapon1 = GameObject.FindGameObjectWithTag("Weapon1");
        weapon2 = GameObject.FindGameObjectWithTag("Weapon2");
    }

    // Update is called once per frame
    void Update()
    {
        FireWeapon();
    }

    

    private void FireWeapon()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bulletClone = Instantiate(bullet,weapon2.transform.position, weapon2.transform.rotation);
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            bulletClone = Instantiate(bullet, weapon1.transform.position, weapon1.transform.rotation);

        }
    }
}
