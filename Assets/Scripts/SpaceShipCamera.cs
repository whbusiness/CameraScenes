using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCamera : MonoBehaviour
{
    public Transform Cameraangle;
    public Transform player;
    public float Xoffset;
    public float Yoffset;
    public float Zoffset;
    void Update()
    {
        Cameraangle.transform.position = player.position + new Vector3(Xoffset, Yoffset, Zoffset);
    }
}
