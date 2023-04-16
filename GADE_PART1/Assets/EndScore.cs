using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndScore : MonoBehaviour
{
    public TextMeshProUGUI scoreOut;
   

    // Update is called once per frame
    void Update()
    {
        float currentScore = ScoreScript.score;
        //scoreOut.GetComponent<TextMeshProUGUI>().text = currentScore.ToString();
        scoreOut.text = "Score: " + currentScore;
    }
}
