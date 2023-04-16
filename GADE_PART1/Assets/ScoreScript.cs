using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static float score;
    public TextMeshProUGUI scoreText;

    public void Start()
    {
        scoreText.text = "Score: " + score;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
                
            }
        }

        if (other.gameObject.CompareTag("Double"))
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
                
            }
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}