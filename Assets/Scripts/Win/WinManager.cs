using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class WinManager : MonoBehaviour
{
    public GameObject phoneObj;
    PhoneScript phoneScript;

    PlayerLook playerLook;
    public GameObject helicopter;
    Animator helicopterAnim;

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
        helicopter.SetActive(false);
        phoneScript = phoneObj.GetComponent<PhoneScript>();
        playerLook = playerCamera.GetComponent<PlayerLook>();
        helicopterAnim = helicopter.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(phoneScript.surviveTimer <= 0)
        {
            playerLook.LockCursor();
            helicopter.SetActive(true);
            helicopterAnim.SetBool("Win", true);
            winCamera.SetActive(true);

            playerObj.SetActive(false);
            uiCanvas.SetActive(false);
            tasksCanvas.SetActive(false);
            zombieSpawners.SetActive(false);
            audioManager.SetActive(false);
            RenderSettings.fog = false;
        }
    }

    public void WinCanvas()
    {
        winCanvas.SetActive(true);
        playerLook.m_cursorIsLocked = false;
    }
}
