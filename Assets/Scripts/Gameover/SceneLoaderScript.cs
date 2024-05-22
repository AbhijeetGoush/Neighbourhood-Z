using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject settingsCanvas;
    public GameObject storyCanvas;

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
        storyCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void StoryMenu()
    {
        menuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        storyCanvas.SetActive(true);

    }

    public void Back()
    {
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        storyCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
