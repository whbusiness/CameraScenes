using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockCounter : MonoBehaviour
{
    public static int RockCount;
    public TextMeshProUGUI RockUI;
    // Start is called before the first frame update
    void Start()
    {
        RockCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RockUI.text = RockCount.ToString("Rocks Collected: " + RockCount + "/7");
    }
}
