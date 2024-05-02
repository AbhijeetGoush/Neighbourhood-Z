using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverText : MonoBehaviour
{
    public GameObject useScrewdriverText;
    FuseBoxScript fuseBoxScript;
    public GameObject fuseBox;
    // Start is called before the first frame update
    void Start()
    {
        fuseBoxScript = fuseBox.GetComponent<FuseBoxScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fuseBoxScript.completedUnscrews >= 4 && fuseBoxScript.fuseBoxScrews <= 0)
        {
            useScrewdriverText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        useScrewdriverText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        useScrewdriverText.gameObject.SetActive(false);
    }
}
