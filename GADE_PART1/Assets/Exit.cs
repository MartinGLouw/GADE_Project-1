using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    
    public void QuitGame()//quits the game
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}