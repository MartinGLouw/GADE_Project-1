using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
                scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
            }
        }

        if (other.gameObject.CompareTag("Double"))
        {
            score = score + 0.5f;
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
                scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
            }
        }
    }
}