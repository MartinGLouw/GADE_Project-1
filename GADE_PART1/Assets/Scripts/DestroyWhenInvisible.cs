using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    private bool isVisible = false;

    void Update()
    {
        // Destroy the game object if it's not visible to the camera
        if (!isVisible)
        {
            Destroy(gameObject);
        }

        // Reset visibility flag
        isVisible = false;
    }

    void OnWillRenderObject()
    {
        // Check if the game object is visible to the camera
        if (Camera.current.CompareTag("MainCamera"))
        {
            isVisible = true;
        }
    }
}