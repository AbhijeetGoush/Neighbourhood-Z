using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject settingsCanvas;
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsMenu()
    {
        menuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void Back()
    {
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }
}
