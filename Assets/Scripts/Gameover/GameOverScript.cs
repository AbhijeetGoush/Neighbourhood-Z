using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerLook playerLook;
    public GameObject uiCanvas;
    public GameObject tasksCanvas;
    public GameObject playerObj;
    public GameObject playerCamera;
    public GameObject gameoverCamera;
    public GameObject gameoverCanvas;
    public GameObject zombieSpawners;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerObj.GetComponent<PlayerHealth>();
        playerLook =playerCamera.GetComponent<PlayerLook>();
        gameoverCamera.SetActive(false);
        gameoverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.currentHealth <= 0)
        {
            playerLook.m_cursorIsLocked = false;
            playerLook.LockCursor();
            playerObj.SetActive(false);
            uiCanvas.SetActive(false);
            tasksCanvas.SetActive(false);
            zombieSpawners.SetActive(false);
            gameoverCamera.SetActive(true);
            gameoverCanvas.SetActive(true);
        }
    }
}
