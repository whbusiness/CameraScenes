using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColliderCheck : MonoBehaviour
{
    public Transform player;
    public static bool TouchingRock = false, TouchingRubbish = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (RaycastCheck.currentScene.name == "SampleScene")
            {
                TouchingRock = true;
            }
            else if (RaycastCheck.currentScene.name == "Street")
            {
                TouchingRubbish = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (RaycastCheck.currentScene.name == "SampleScene")
            {
                TouchingRock = false;
            }
            else if (RaycastCheck.currentScene.name == "Street")
            {
                TouchingRubbish = false;
            }
        }
    }
}
