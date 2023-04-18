using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)//Loads a set scene on button press
    {
        SceneManager.LoadScene(sceneName);
    }
}