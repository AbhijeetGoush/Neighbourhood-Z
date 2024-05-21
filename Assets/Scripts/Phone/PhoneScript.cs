using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public bool canUsePhone;
    public bool inRange;
    public int phoneUse;
    public GameObject phoneTaskObj;
    public GameObject fuseBoxText;
    public GameObject surviveObj;
    public TextMeshProUGUI phoneTaskText;
    
    public AudioSource helpIsOnTheWaySound;
    public GameObject helpIsOnTheWayObj;
    public AudioClip helpIsOnTheWayClip;

    public float surviveTimer;
    public GameObject timerObj;
    public TextMeshProUGUI timerText;

    ZombieSpawner zombieSpawner1Scr;
    ZombieSpawner zombieSpawner2Scr;
    ZombieSpawner zombieSpawner3Scr;
    public GameObject zombieSpawner1;
    public GameObject zombieSpawner2;
    public GameObject zombieSpawner3;
    // Start is called before the first frame update
    void Start()
    {
        surviveTimer = 120;
        phoneUse = 0;
        canUsePhone = false;
        inRange = false;
        phoneTaskObj.SetActive(false);
        surviveObj.SetActive(false);
        timerObj.SetActive(false);
        helpIsOnTheWaySound = helpIsOnTheWayObj.GetComponent<AudioSource>();

        zombieSpawner1Scr = zombieSpawner1.GetComponent<ZombieSpawner>();
        zombieSpawner2Scr = zombieSpawner2.GetComponent<ZombieSpawner>();
        zombieSpawner3Scr = zombieSpawner3.GetComponent<ZombieSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canUsePhone == true)
        {
            phoneTaskObj.SetActive(true);
            fuseBoxText.SetActive(false);
        }
        if(canUsePhone == true && inRange == true && phoneUse == 0)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                helpIsOnTheWaySound.PlayOneShot(helpIsOnTheWayClip);
                phoneUse = 1;
            }
        }
        if(phoneUse == 1)
        {
            phoneTaskObj.SetActive(false);
            surviveObj.SetActive(true);

            timerObj.SetActive(true);
            surviveTimer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(surviveTimer / 60);
            int seconds = Mathf.FloorToInt(surviveTimer % 60);
            timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);


        }

        if(surviveTimer < 0)
        {
            surviveTimer = 0;
            timerText.text = "00:00";
        }

        if(phoneUse > 0 && surviveTimer > 60)
        {
            zombieSpawner1Scr.spawnTimer = 15;
            zombieSpawner2Scr.spawnTimer = 15;
            zombieSpawner3Scr.spawnTimer = 15;
        }
        if(surviveTimer <= 60f)
        {
            zombieSpawner1Scr.spawnTimer = 10;
            zombieSpawner2Scr.spawnTimer = 10;
            zombieSpawner3Scr.spawnTimer = 10;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
