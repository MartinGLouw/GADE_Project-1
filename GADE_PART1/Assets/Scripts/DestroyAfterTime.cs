using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 2f;
    private bool isVisible = false;
    private float timeInvisible = 0f;

    void Update()
    {
        // Check if the game object is visible to the camera
        if (isVisible)
        {
            // Reset the time invisible counter
            timeInvisible = 0f;
        }
        else
        {
            // Increment the time invisible counter
            timeInvisible += Time.deltaTime;

            // Destroy the game object if it has been invisible for the specified amount of time
            if (timeInvisible >= timeToDestroy)
            {
                Destroy(gameObject);
            }
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