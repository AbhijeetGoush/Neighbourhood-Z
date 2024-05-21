using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class WinManager : MonoBehaviour
{
    public GameObject phoneObj;
    PhoneScript phoneScript;

    PlayerLook playerLook;

    public GameObject uiCanvas;
    public GameObject tasksCanvas;
    public GameObject playerObj;
    public GameObject playerCamera;
    public GameObject winCamera;
    public GameObject winCanvas;
    public GameObject zombieSpawners;
    public GameObject audioManager;
    // Start is called before the first frame update
    void Start()
    {
        phoneScript = phoneObj.GetComponent<PhoneScript>();
        playerLook = playerCamera.GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if(phoneScript.surviveTimer <= 0)
        {
            playerLook.m_cursorIsLocked = false;
            playerLook.LockCursor();
            playerObj.SetActive(false);
            uiCanvas.SetActive(false);
            tasksCanvas.SetActive(false);
            zombieSpawners.SetActive(false);
            audioManager.SetActive(false);
            winCamera.SetActive(true);
        }
    }

    public void WinCanvas()
    {
        winCanvas.SetActive(true);
    }
}
