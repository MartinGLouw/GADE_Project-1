using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    public int PosX = 0, PosY = 2;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PosX, PosY, transform.position.z);
    }
}
