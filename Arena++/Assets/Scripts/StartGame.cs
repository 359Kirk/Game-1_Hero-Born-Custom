using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject settingsUI;

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void StartGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameSettings()
    {
        settingsUI.SetActive(true);
    }

    public void Close()
    {
        settingsUI.SetActive(false);
    }

}