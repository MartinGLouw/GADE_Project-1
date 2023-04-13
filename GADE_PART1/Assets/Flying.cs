using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public GameObject Pickup;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Pickup = GameObject.FindGameObjectWithTag("Flying");
            Destroy(Pickup);
        }
    }
}
