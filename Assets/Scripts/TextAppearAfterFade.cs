using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAppearAfterFade : MonoBehaviour
{
    public GameObject RubbishAmountText, StoredRubbishAmountText, movingCam;
    public float WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        RubbishAmountText.SetActive(false);
        StoredRubbishAmountText.SetActive(false);
        if (!movingCam.activeInHierarchy)
        {
            StartCoroutine(WaitToDisplay());
        }
    }

    IEnumerator WaitToDisplay()
    {
        yield return new WaitForSeconds(WaitTime);
        RubbishAmountText.SetActive(true);
        StoredRubbishAmountText.SetActive(true);

    }
}
