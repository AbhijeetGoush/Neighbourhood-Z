using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightLight;
    private bool flashlightOn = false;

    AudioSource flashlightSound;
    public GameObject flashlightSoundObj;
    public AudioClip flashlightClip;

    // Start is called before the first frame update
    void Start()
    {
        FlashlightLight.gameObject.SetActive(false);
        flashlightSound = flashlightSoundObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightSound.PlayOneShot(flashlightClip);
            if (flashlightOn == false)
            {
                FlashlightLight.gameObject.SetActive(true);
                flashlightOn = true;
            }
            else
            {
                FlashlightLight.gameObject.SetActive(false);
                flashlightOn = false;
            }
        }
    }
}
