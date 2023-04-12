using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private GameObject Pickup;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy (GameObject.FindWithTag("Flying"));
            Pickup = GameObject.FindGameObjectWithTag("Flying");
            Destroy(Pickup);
        }
    }
}
