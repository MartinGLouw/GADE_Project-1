using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Invincibile : MonoBehaviour
{
    public RawImage image; // Assign the RawImage in the Inspector
    public TextMeshProUGUI timerText; // Assign the TextMeshProUGUI in the Inspector

    void Start()
    {
        gameObject.tag = "Player";
    }
    private IEnumerator ChangeTagBack(GameObject player)
    {
        float timeRemaining = 10f;
        while (timeRemaining > 0)
        {
            timerText.text = "Time Remaining: " + timeRemaining.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            timeRemaining -= 0.1f;
        }

        player.tag = "Player";
        image.enabled = false; // Hide the RawImage
        timerText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inv"))
        {
            gameObject.tag = "Strong";
            image.enabled = true; // Show the RawImage
            StartCoroutine(ChangeTagBack(gameObject));
        }
    }
}