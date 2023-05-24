using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static float score; //score variable
    public TextMeshProUGUI scoreText; //score ui object
    private bool doublePointsActive = false; //flag to check if double points are active
    private float doublePointsDuration = 20f; //duration of double points in seconds

    public void Start()
    {
        scoreText.text = "Score: " + score; // displays the text on ui
    }

    void OnTriggerEnter(Collider other) //checks when entering a collider
    {
        if (other.gameObject.CompareTag("Score")) //if collider is Score it will add score
        {
            if (doublePointsActive)
            {
                score += 1f;
            }
            else
            {
                score += 0.5f;
            }
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
        }

        if (other.gameObject.CompareTag("Double")) //if collider is Double it will add another score
        {
            if (doublePointsActive)
            {
                score += 1f;
            }
            else
            {
                score += 0.5f;
            }
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
        }

        if (other.gameObject.CompareTag("DPPoints")) //if collider is DPPoints it will activate double points for a duration
        {
            StartCoroutine(DoublePoints(doublePointsDuration));
        }
    }

    IEnumerator DoublePoints(float duration)
    {
        doublePointsActive = true;
        yield return new WaitForSeconds(duration);
        doublePointsActive = false;
    }

    public void ResetScore() // when restart is clicked the score is set to zero
    {
        score = 0;
    }
}