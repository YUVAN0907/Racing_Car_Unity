using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject playerUI;
    public static bool GameIsStopped = false;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsStopped = false;
        
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsStopped = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene_day");
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Garage");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game.....");
        Application.Quit();
    }
}
