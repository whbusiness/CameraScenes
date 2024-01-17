using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraCheck : MonoBehaviour
{
   // public GameObject othercam;
   // private GameObject othercam2;
    private Scene scene;
    private GameObject textObj, Rocktext, RubbishText, StoredRubbishText;
    public GameObject movingcam;
    public float WaitAtStart, HideText;

    void Awake()
    {
        textObj = GameObject.Find("TitleText");
        Rocktext = GameObject.Find("RockCount");
        RubbishText = GameObject.Find("RubbishAmountText");
        StoredRubbishText = GameObject.Find("StoredRubbish");

    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        textObj.SetActive(false);
       /* if (MoveCamera.playing)
        {
            othercam.SetActive(false);
        }
        else
        {
            othercam.SetActive(true);
        }
        if (scene.name == "Scene3" && PlanetCamera.playing)
        {
            othercam2 = GameObject.Find("PlanetCamera");
            othercam.SetActive(false);
            othercam2.SetActive(false);
        }*/
        if(scene.name == "SampleScene" && movingcam.activeInHierarchy)
        {
            StartCoroutine(nameof(WaitToDisplay));
            StartCoroutine(nameof(HideGameObject));
        }


    }
    private void Update()
    {
        if (scene.name == "SampleScene")
        {
            if (ForestCamera.playing)
            {
                textObj.SetActive(false);
                // othercam = GameObject.Find("MovingCam");
                // print("Make othercam false");
                // othercam.SetActive(false);
            }
            if (movingcam.activeInHierarchy)
            {
                Rocktext.SetActive(false);
            }
            else
            {
                textObj.SetActive(false);
                Rocktext.SetActive(true);
            }
            /*else if (!ForestCamera.playing)
            {
                //textObj.SetActive(true);
                othercam.SetActive(true);
            }*/
        }
    }
    IEnumerator WaitToDisplay()
    {
        yield return new WaitForSeconds(WaitAtStart);
        textObj.SetActive(true);
    }
    IEnumerator HideGameObject()
    {
        yield return new WaitForSeconds(HideText);
        textObj.SetActive(false);
    }
}
