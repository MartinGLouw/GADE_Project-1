using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndScore : MonoBehaviour
{
    public TextMeshProUGUI scoreOut;
   

    
    void Update()//this prints the score in a new scene
    {
        float currentScore = ScoreScript.score;
        //scoreOut.GetComponent<TextMeshProUGUI>().text = currentScore.ToString();
        scoreOut.text = "Score: " + currentScore;
    }
}
