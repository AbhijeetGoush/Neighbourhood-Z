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

    private float surviveTimer;
    public GameObject timerObj;
    public TextMeshProUGUI timerText;
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
