using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolsTextScript : MonoBehaviour
{
    Inventory playerInventory;
    public GameObject playerObject;
    public TextMeshProUGUI toolsText;
    public string flashlightStatus;
    public string gunStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerObject.GetComponent<Inventory>();
        flashlightStatus = "(In bedroom)";
        gunStatus = "(In living room)";
        toolsText.text = "Find tools:\r\nFlashlight " + flashlightStatus + "\r\nGun " + (gunStatus);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInventory.flashlightObtained == true)
        {
            flashlightStatus = "(Found)";
        }
        if(playerInventory.gunObtained == true)
        {
            gunStatus = "(Found)";
        }
        toolsText.text = "Find tools:\r\nFlashlight " + flashlightStatus + "\r\nGun " + (gunStatus);
    }
}
