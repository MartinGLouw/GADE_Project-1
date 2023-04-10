using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int score;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score++;
            Debug.Log("Score: " + score);
        }
        if (other.gameObject.CompareTag("Double"))
        {
            score++;
            Debug.Log("Score: " + score);
        }
    }
    
}

