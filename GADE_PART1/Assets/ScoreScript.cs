using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static float score;//score variable
    public TextMeshProUGUI scoreText;//score ui object

    public void Start()
    {
        scoreText.text = "Score: " + score;// displays the text on ui
    }

    void OnTriggerEnter(Collider other)//checks when entering a collider
    {
        if (other.gameObject.CompareTag("Score"))//if collider is Score it will add score
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
                
            }
        }

        if (other.gameObject.CompareTag("Double"))//if collider is Double it will add another score
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
                
            }
        }
    }

    public void ResetScore()// when restart is clicked the score is set to zero
    {
        score = 0;
    }
}