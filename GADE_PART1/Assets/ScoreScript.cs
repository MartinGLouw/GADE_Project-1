using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float score;
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
            
        }
    
        if (other.gameObject.CompareTag("Double"))
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
        }
    }
    
}

