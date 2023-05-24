using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject[] pickups;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player" ) || other.gameObject.CompareTag("Strong" ) || other.gameObject.CompareTag("DPPoints"))
        {
            Destroy(gameObject);
        }
    }
}
