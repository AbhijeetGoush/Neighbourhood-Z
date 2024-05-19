using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FuseBoxScript : MonoBehaviour
{
    float timeLeft = 3.0f;
    bool holding;
    public int completedUnscrews;
    int completedScrews;
    string fuseBoxStatus;
    public TextMeshProUGUI fixFuseBoxTaskText;
    bool ableToScrew;
    public bool ableToUnscrew;
    bool ableToTurnOnFuseBox;
    Inventory playerInventory;
    PhoneScript phoneScr;
    public GameObject phoneObject;
    public GameObject playerObject;
    public GameObject useScrewdriverText;
    public GameObject houseLights;
    public int fuseBoxScrews = 4;

    // Start is called before the first frame update
    void Start()
    {
        houseLights.SetActive(false);
        holding = false;
        ableToScrew = false;
        ableToUnscrew = false;
        ableToTurnOnFuseBox = false;
        completedUnscrews = 0;
        fuseBoxStatus = "OFF";

        playerInventory = playerObject.GetComponent<Inventory>();
        fixFuseBoxTaskText.text = "Fix fuse box:\r\nUnscrew old screws " + completedUnscrews + "/4\r\nScrew on new screws " + completedScrews + "/4\r\nTurn on generator (" + fuseBoxStatus + ")";
        useScrewdriverText.gameObject.SetActive(false);
        phoneScr = phoneObject.GetComponent<PhoneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holding == true)
        {
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0f)
        {
            completedUnscrews += 1;
            timeLeft = 3f;
        }
        if(completedUnscrews >= 5)
        {
            completedUnscrews = 4;
        }
        if(completedUnscrews >= 4)
        {
            ableToScrew = true;
            ableToUnscrew = false;
        }
        if(fuseBoxScrews <= 0)
        {
            ableToTurnOnFuseBox = true;
            playerInventory.screwObtained = false;
        }

        fixFuseBoxTaskText.text = "Fix fuse box:\r\nUnscrew old screws " + completedUnscrews + "/4\r\nScrew on new screws " + completedScrews + "/4\r\nTurn on generator (" + fuseBoxStatus + ")";
    }
    private void OnMouseDown()
    {
        if (ableToUnscrew == true && playerInventory.currentObject == playerInventory.screwdriverObject)
        {
            holding = true;
        }
        
        if(ableToScrew == true && fuseBoxScrews > 0 && playerInventory.currentObject == playerInventory.screwdriverObject)
        {
            completedScrews += 1;
            fuseBoxScrews -= 1;
        }
        if(ableToTurnOnFuseBox == true)
        {
            fuseBoxStatus = "ON";
            houseLights.SetActive(true);
            phoneScr.canUsePhone = true;
        }
    }
    private void OnMouseUp()
    {
        if(ableToUnscrew == true)
        {
            holding = false;
        }
    }
}