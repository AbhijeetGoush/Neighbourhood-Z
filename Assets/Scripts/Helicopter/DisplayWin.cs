using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

public class DisplayWin : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject playerCamera;

    PlayerLook playerLook;

    // Start is called before the first frame update
    void Start()
    {
        playerLook = playerCamera.GetComponent<PlayerLook>();
    }

    public void WinCanvas()
    {
        winCanvas.SetActive(true);
        playerLook.m_cursorIsLocked = false;
    }
}
