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
    public TextMeshProUGUI phoneTaskText;
    
    public AudioSource helpIsOnTheWaySound;
    public GameObject helpIsOnTheWayObj;
    public AudioClip helpIsOnTheWayClip;

    // Start is called before the first frame update
    void Start()
    {
        phoneUse = 0;
        canUsePhone = false;
        inRange = false;
        phoneTaskObj.SetActive(false);
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
        if(canUsePhone == true && inRange == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                helpIsOnTheWaySound.PlayOneShot(helpIsOnTheWayClip);
                phoneUse = 1;
            }
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
