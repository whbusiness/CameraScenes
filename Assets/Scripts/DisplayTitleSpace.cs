using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTitleSpace : MonoBehaviour
{
    public GameObject TextObj;
    // Start is called before the first frame update
    void Start()
    {
        TextObj.SetActive(true);
        StartCoroutine(nameof(DisplayText));
    }

    IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(3f);
        TextObj.SetActive(false);
    }
}
