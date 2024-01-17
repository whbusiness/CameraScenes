using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public float smoothTime;
    public Transform Doors;
    public bool Move;
    private Vector3 Target;
    private Vector3 OriginalPos;
    private void Start()
    {
        OriginalPos = Doors.transform.position;
        Target = Doors.transform.position + new Vector3(0f, 2f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Camera"))
        {
            print("Collided with" + other.gameObject.name);
            Move = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Camera"))
        {
            Move = false;
        }
    }

    void FixedUpdate()
    {
        if (Move)
        {
            Doors.transform.position = Vector3.Lerp(Doors.transform.position, Target, smoothTime);
        }
        else
        {
            Doors.transform.position = Vector3.Lerp(Doors.transform.position, OriginalPos, smoothTime);
        }
    }
}