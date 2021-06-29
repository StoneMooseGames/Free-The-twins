using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterController : MonoBehaviour
{
   
    
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    private Rigidbody bulletClone;
    private GameObject weapon1;
    private GameObject weapon2;
    public GameObject player;
    private GameObject gameUi;
    private Text healthUiText;
    private float shootingTimer;

    public int playerHealthMax = 200;
    private int playerHealth;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    AudioSource soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.loop = false;
        shootingTimer = 1.0f;
        playerHealth = playerHealthMax;
        gameUi = GameObject.Find("UI");
        healthUiText = gameUi.GetComponent<GameUiManager>().healthText.GetComponent<Text>();
        weapon1 = GameObject.FindGameObjectWithTag("Weapon1");
        weapon2 = GameObject.FindGameObjectWithTag("Weapon2");
        healthUiText.text = playerHealth.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        FireWeapon();
        CheckHit();
        
    }

    

    private void FireWeapon()
    {
        if(Input.GetMouseButtonDown(0))
        {
            soundPlayer.clip = shootSound;
            if(!soundPlayer.isPlaying)
            {
                soundPlayer.Play();
                bulletClone = Instantiate(bullet, weapon2.transform.position, weapon2.transform.rotation);
            }
                
            
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            soundPlayer.clip = shootSound;
            if (!soundPlayer.isPlaying)
            {
                soundPlayer.Play();
                bulletClone = Instantiate(bullet, weapon1.transform.position, weapon1.transform.rotation);
            }
        }
    }

    void CheckHit()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(player.transform.position + new Vector3(0,1,0), ray.direction * 2, Color.red);
        if (Physics.Raycast(player.transform.position + new Vector3(0, 1, 0), player.transform.TransformDirection(Vector3.forward), out hit,2))
        {
            if (hit.collider.tag == "OpenClose")
            {
                gameUi.GetComponent<GameUiManager>().interActText.gameObject.GetComponent<Text>().text = "(E)" + hit.collider.tag;
                gameUi.GetComponent<GameUiManager>().interActText.gameObject.GetComponent<Text>().enabled = true;
                if (Input.GetKeyDown("e"))
                {
                    hit.collider.gameObject.GetComponent<OpenCloseDoor>().InteractWithDoor();
                }
            }
            else gameUi.GetComponent<GameUiManager>().interActText.gameObject.GetComponent<Text>().enabled = false;
        }
    }

    public void PlayerTakesDamage(int damage)
    {
        playerHealth -= damage;
        healthUiText.text = playerHealth.ToString();
        if(playerHealth <=0)
        {
            Debug.Log("Player is dead");
        }
    }
}
