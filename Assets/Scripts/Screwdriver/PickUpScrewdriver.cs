using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScrewdriver : MonoBehaviour
{
    Inventory playerInventory;
    public GameObject playerObject;
    public GameObject screwdriverOnPlayer;
    public GameObject PickUpScrewdriverText;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerObject.GetComponent<Inventory>();    
    }

    private void OnTriggerStay(Collider other)
    {
        PickUpScrewdriverText.gameObject.SetActive(true);

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(this.gameObject);
                Destroy(PickUpScrewdriverText);
                playerInventory.currentObject = playerInventory.screwdriverObject;
                playerInventory.gunObject.SetActive(false);
                playerInventory.flashlightObject.SetActive(false);
                playerInventory.screwdriverObtained = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpScrewdriverText.gameObject.SetActive(false);
        }
    }

}
