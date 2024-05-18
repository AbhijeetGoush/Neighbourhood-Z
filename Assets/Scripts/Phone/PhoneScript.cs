using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public bool canUsePhone;
    public GameObject phoneTaskObj;
    public GameObject fuseBoxText;
    public TextMeshProUGUI phoneTaskText;

    // Start is called before the first frame update
    void Start()
    {
        canUsePhone = false;
        phoneTaskObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(canUsePhone == true)
        {
            phoneTaskObj.SetActive(true);
            fuseBoxText.SetActive(false);
        }
    }
}
