using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    public GameObject FlashlightOnPlayer;
    public GameObject PickUpText;

    // Start is called before the first frame update
    void Start()
    {
        FlashlightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
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
                FlashlightOnPlayer.gameObject.SetActive(true);
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
