using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static float score; //score variable
    public TextMeshProUGUI scoreText; //score ui object
    private bool doublePointsActive = false; //flag to check if double points are active
    private float doublePointsDuration = 15f; //duration of double points in seconds
    public RawImage image; // Assign the RawImage in the Inspector
    public TextMeshProUGUI timerText; // Assign the TextMeshProUGUI in the Inspector
    private Coroutine doublePointsCoroutine; // Reference to the current DoublePoints coroutine
    private bool touched;
    public void Start()
    {
        scoreText.text = "Score: " + score; // displays the text on ui
    }

    void OnTriggerEnter(Collider other) //checks when entering a collider
    {
        
        if (other.gameObject.CompareTag("Score")&&!touched) //if collider is Score it will add score
        {
            if (doublePointsActive)
            {
                score += 2f;
            }
            else
            {
                score += 1f;
            }
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
            touched = true;
        }

        if (other.gameObject.CompareTag("Double")&&!touched) //if collider is Double it will add another score
        {
            if (doublePointsActive)
            {
                score += 2f;
            }
            else
            {
                score += 1f;
            }
            Debug.Log("Score: " + score);
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
            touched = true;
        }

        if (other.gameObject.CompareTag("DPPoints")) //if collider is DPPoints it will activate double points for a duration
        {
            if (doublePointsCoroutine != null)
            {
                StopCoroutine(doublePointsCoroutine);
                doublePointsCoroutine = null;
            }
            doublePointsCoroutine = StartCoroutine(DoublePoints(doublePointsDuration));
        }
    }

    IEnumerator DoublePoints(float duration)
    {
        doublePointsActive = true;
        image.enabled = true; // Show the RawImage

        float timeRemaining = duration;
        while (timeRemaining > 0)
        {
            timerText.text = "Time Remaining: " + timeRemaining.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            timeRemaining -= 0.1f;
        }

        doublePointsActive = false;
        image.enabled = false; // Hide the RawImage
        timerText.text = "";
    }

    public void ResetScore() // when restart is clicked the score is set to zero
    {
        score = 0;
    }
    public void OnTriggerExit(Collider other)
    {
        touched = false;
    }

}
