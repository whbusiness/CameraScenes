using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollisionCheck : MonoBehaviour
{
    public static bool TouchingSign = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TouchingSign = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TouchingSign = false;
        }
    }
}
