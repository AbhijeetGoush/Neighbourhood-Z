using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    MoveObjectController moveObjectScript;
    Inventory playerInventory;

    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        moveObjectScript = GetComponent<MoveObjectController>();
        moveObjectScript.enabled = false;

        playerInventory = playerObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInventory.flashlightObtained == false && playerInventory.gunObtained == false)
        {
            moveObjectScript.enabled = false;
        }
        if(playerInventory.flashlightObtained == true && playerInventory.gunObtained == true)
        {
            moveObjectScript.enabled = true;
        }
    }
}
