using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
    public int screwCount;

    public GameObject fuseBoxObj;
    FuseBoxScript fuseBoxScript;
    // Start is called before the first frame update
    void Start()
    {
        flashlightObtained = false;
        gunObtained = false;
        screwObtained = false;
        findToolsText.SetActive(true);
        findItemsText.SetActive(false);

        fuseBoxScript = fuseBoxObj.GetComponent<FuseBoxScript>();
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
            }
        }
        currentObject.SetActive(true);

        if(flashlightObtained == true && gunObtained == true)
        {
            findToolsText.SetActive(false);
            findItemsText.SetActive(true);
        }

        if(screwdriverObtained == true && screwCount == 4)
        {
            findItemsText.SetActive(false);
            fixFuseBoxText.SetActive(true);
            fuseBoxScript.ableToUnscrew = true;
        }
    }

}
