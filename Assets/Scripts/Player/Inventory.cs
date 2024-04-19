using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool flashlightObtained;
    public bool gunObtained;
    public bool screwdriverObtained;
    public GameObject flashlightObject;
    public GameObject gunObject;
    public GameObject screwdriverObject;
    public GameObject currentObject;
    // Start is called before the first frame update
    void Start()
    {
        flashlightObtained = false;
        gunObtained = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flashlightObtained == true)
        {
            if (Input.GetKeyDown("1"))
            {
                currentObject = flashlightObject;
                gunObject.SetActive(false);
                screwdriverObject.SetActive(false);
            }
        }
        if(gunObtained == true)
        {
            if(Input.GetKeyDown("2"))
            {
                currentObject = gunObject;
                flashlightObject.SetActive(false);
                screwdriverObject.SetActive(false);
            }
        }
        if(screwdriverObtained == true)
        {
            if(Input.GetKeyDown("3"))
            {
                currentObject = screwdriverObject;
                gunObject.SetActive(false);
                flashlightObject.SetActive(false);

            }
        }
        currentObject.SetActive(true);
    }

}
