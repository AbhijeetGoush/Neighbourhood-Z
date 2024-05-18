using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool flashlightObtained;
    public bool gunObtained;
    public bool screwdriverObtained;
    public bool screwObtained;
    public GameObject flashlightObject;
    public GameObject gunObject;
    public GameObject screwdriverObject;
    public GameObject screwObject;
    public GameObject currentObject;
    public GameObject findToolsText;
    public GameObject findItemsText;
    public GameObject fixFuseBoxText;
    public GameObject ammoText;
    public int screwCount;

    public GameObject fuseBoxObj;
    FuseBoxScript fuseBoxScript;

    PhoneScript phoneScript;
    public GameObject phoneObj;
    // Start is called before the first frame update
    void Start()
    {
        flashlightObtained = false;
        gunObtained = false;
        screwObtained = false;
        findToolsText.SetActive(true);
        findItemsText.SetActive(false);
        ammoText.SetActive(false);

        fuseBoxScript = fuseBoxObj.GetComponent<FuseBoxScript>();
        phoneScript = phoneObj.GetComponent<PhoneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashlightObtained == true)
        {
            if (Input.GetKeyDown("1"))
            {
                currentObject = flashlightObject;
                gunObject.SetActive(false);
                screwdriverObject.SetActive(false);
                screwObject.SetActive(false);
                ammoText.SetActive(false);
            }
        }
        if (gunObtained == true)
        {
            if (Input.GetKeyDown("2"))
            {
                currentObject = gunObject;
                flashlightObject.SetActive(false);
                screwdriverObject.SetActive(false);
                screwObject.SetActive(false);
                ammoText.SetActive(true);
            }
        }
        if (screwdriverObtained == true)
        {
            if (Input.GetKeyDown("3"))
            {
                currentObject = screwdriverObject;
                gunObject.SetActive(false);
                flashlightObject.SetActive(false);
                screwObject.SetActive(false);
                ammoText.SetActive(false);
            }
        }
        if (screwObtained == true)
        {
            if(Input.GetKeyDown("4"))
            {
                currentObject = screwObject;
                gunObject.SetActive(false);
                flashlightObject.SetActive(false);
                screwdriverObject.SetActive(false);
                ammoText.SetActive(false);
            }
        }
        currentObject.SetActive(true);

        if(flashlightObtained == true && gunObtained == true && phoneScript.canUsePhone == false)
        {
            findToolsText.SetActive(false);
            findItemsText.SetActive(true);
        }

        if(screwdriverObtained == true && screwCount == 4 && phoneScript.canUsePhone == false)
        {
            findItemsText.SetActive(false);
            fixFuseBoxText.SetActive(true);
            fuseBoxScript.ableToUnscrew = true;
        }

        if(phoneScript.canUsePhone == true)
        {
            fixFuseBoxText.SetActive(false);
        }
        
    }

}
