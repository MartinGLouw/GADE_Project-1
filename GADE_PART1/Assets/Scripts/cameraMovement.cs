using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    public int PosX = 0, PosY = 10;//limit for camera
    
    void Update()//locks the camera at a set hight and position and follows player
    {
        transform.position = new Vector3(PosX, PosY, transform.position.z);
    }
}
