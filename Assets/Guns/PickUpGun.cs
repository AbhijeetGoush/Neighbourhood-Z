using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    public GameObject GunOnPlayer;
    public GameObject PickUpGunText;

    // Start is called before the first frame update
    void Start()
    {
        GunOnPlayer.SetActive(false);
        PickUpGunText.SetActive(false);
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
                GunOnPlayer.gameObject.SetActive(true);
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
