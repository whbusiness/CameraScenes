using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinColliderCheck : MonoBehaviour
{
    public static bool TouchingBin = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TouchingBin = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TouchingBin = false;
        }
    }
}
