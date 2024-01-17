using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForMainCam : MonoBehaviour
{
    public GameObject PlayerCam, SignText;
    void Start()
    {
        if (!PlayerCam.activeInHierarchy)
        {
            SignText.SetActive(false);
        }
    }
}
