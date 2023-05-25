using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibile : MonoBehaviour
{
    void Start()
    {
        gameObject.tag = "Player";
    }
    private IEnumerator ChangeTagBack(GameObject player)
    {
        yield return new WaitForSeconds(20);
        player.tag = "Player";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Inv"))
        {
            gameObject.tag = "Strong";
            StartCoroutine(ChangeTagBack(gameObject));
        }
    }
}