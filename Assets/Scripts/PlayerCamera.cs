using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    public Transform Cameraangle;
    public Transform player;
    void Update()
    {
        Cameraangle.transform.position = player.position;        
    }
}
