using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemsTextScript : MonoBehaviour
{
    public GameObject playerObject;
    Inventory playerInventory;
    public TextMeshProUGUI itemsText;
    private string screwdriverStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerObject.GetComponent<Inventory>();
        screwdriverStatus = "0";
        itemsText.text = "Find items:\r\nScrewdriver" + screwdriverStatus + "/1\r\nScrews " + playerInventory.screwCount + "/4";
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInventory.screwdriverObtained == true)
        {
            screwdriverStatus = "1";
        }
        itemsText.text = "Find items:\r\nScrewdriver " + screwdriverStatus + "/1\r\nScrews " + playerInventory.screwCount + "/4";
    }
}
