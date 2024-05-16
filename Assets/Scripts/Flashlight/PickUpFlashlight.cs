using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    Inventory playerInventory;
    public GameObject playerObject;
    public GameObject FlashlightOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        FlashlightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
        playerInventory = playerObject.GetComponent<Inventory>();
    }

    private void OnTriggerStay(Collider other)
    {
        PickUpText.gameObject.SetActive(true);

        if (other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Destroy(this.gameObject);
                Destroy(PickUpText);
                playerInventory.currentObject = playerInventory.flashlightObject;
                playerInventory.gunObject.SetActive(false);
                playerInventory.screwdriverObject.SetActive(false);
                playerInventory.screwObject.SetActive(false);
                playerInventory.ammoText.SetActive(false);
                playerInventory.flashlightObtained = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.gameObject.SetActive(false);
        }
    }


}
