using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    Inventory playerInventory;
    public GameObject playerObject;
    public GameObject GunOnPlayer;
    public GameObject PickUpGunText;

    // Start is called before the first frame update
    void Start()
    {
        GunOnPlayer.SetActive(false);
        PickUpGunText.SetActive(false);
        playerInventory = playerObject.GetComponent<Inventory>();
    }

    private void OnTriggerStay(Collider other)
    {
        PickUpGunText.gameObject.SetActive(true);

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(this.gameObject);
                Destroy(PickUpGunText);
                playerInventory.currentObject = playerInventory.gunObject;
                playerInventory.flashlightObject.SetActive(false);
                playerInventory.screwdriverObject.SetActive(false);
                playerInventory.gunObtained = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpGunText.gameObject.SetActive(false);
        }
    }
}
