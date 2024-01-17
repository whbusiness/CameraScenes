using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RubbishCount : MonoBehaviour
{
    public static int RubbishCounter;
    public TextMeshProUGUI RubbishUI;
    // Start is called before the first frame update
    void Start()
    {
        RubbishCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RubbishUI.text = RubbishCounter.ToString("Current Rubbish: " + RubbishCounter);
    }
}
