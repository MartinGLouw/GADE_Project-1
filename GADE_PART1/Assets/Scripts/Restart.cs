using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void ReloadScene()//to restart scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}