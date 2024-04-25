using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewOneScript : MonoBehaviour
{
    Inventory playerInventory;
    public GameObject playerObject;
    public GameObject screwOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = playerObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        PickUpText.gameObject.SetActive(true);

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(this.gameObject);
                playerInventory.currentObject = playerInventory.screwObject;
                playerInventory.gunObject.SetActive(false);
                playerInventory.screwdriverObject.SetActive(false);
                playerInventory.flashlightObject.SetActive(false);
                playerInventory.screwObtained = true;
                playerInventory.screwCount += 1;

                PickUpText.SetActive(false);
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
