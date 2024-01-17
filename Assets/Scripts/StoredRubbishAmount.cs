using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoredRubbishAmount : MonoBehaviour
{
    public static int StoredAmount;
    public TextMeshProUGUI StoredUI;
    // Start is called before the first frame update
    void Start()
    {
        StoredAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StoredUI.text = StoredAmount.ToString("Stored Rubbish: " + StoredAmount);
    }
}
