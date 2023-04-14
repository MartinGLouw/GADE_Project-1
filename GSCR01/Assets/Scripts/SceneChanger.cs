using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void LoadLevel()
    {
        Debug.Log("loadlevel");
        SceneManager.LoadScene("Game");
    }
    public void Load2Level()
    {
        Debug.Log("Load2Level");
        SceneManager.LoadScene("Game2");
    }
    public void LoadMainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadExit()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene("Exit");
    }
    public void Exit()
    {
        Debug.Log("Closed");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
