using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlanes : MonoBehaviour
{
    public Transform FirstPlaneCamera;
    public Transform SecondPlaneCamera;
    public Transform ThirdPlaneCamera;
    public Vector3 FirstPlaneOffset;
    public Vector3 SecondPlaneOffset;
    public Vector3 ThirdPlaneOffset;
    public new Transform camera;
    public static float TimeElapsed;
    public float MaxTime1;
    public float MaxTime2;
    public float MaxTime3;
    public float t;
    public float xAngle1;
    public float yAngle1;
    public float zAngle1;
    public float xAngle2;
    public float yAngle2;
    public float zAngle2;
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public static bool playing = false;
    public GameObject Playercam;
    private void Start()
    {
        if (!playing)
        {
            GameObject varGameObject = GameObject.FindWithTag("Player");
            varGameObject.GetComponent<Movement>().enabled = false;
            Playercam.SetActive(false);
        }
        else if (playing)
        {
            GameObject varGameObject = GameObject.FindWithTag("Player");
            varGameObject.GetComponent<Movement>().enabled = true;
            gameObject.SetActive(false);
            Playercam.SetActive(true);
        }
        TimeElapsed = 0f;
    }
    void LateUpdate()
    {
        if (!playing)
        {
            if (TimeElapsed < 31)
            {
                TimeElapsed += Time.deltaTime;
            }
            if (TimeElapsed > 3f && TimeElapsed < MaxTime1)
            {
                Vector3 DesiredPosition = FirstPlaneCamera.position + FirstPlaneOffset;
                Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, t);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                camera.transform.position = smoothedposition;
                //camera.transform.position = FirstPlaneCamera.position + FirstPlaneOffset;
            }
            if (TimeElapsed > MaxTime1)
            {
                if (TimeElapsed < MaxTime2)
                {
                    //Vector3 currentposition = FirstPlaneCamera.position + FirstPlaneOffset;
                    Vector3 DesiredPosition = SecondPlaneCamera.position + SecondPlaneOffset;
                    Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, t);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                    camera.transform.position = smoothedposition;
                    camera.transform.eulerAngles = new Vector3(xAngle1, yAngle1, zAngle1);


                }
            }
            if (TimeElapsed > MaxTime2)
            {
                if (TimeElapsed < MaxTime3)
                {
                    Vector3 DesiredPosition = ThirdPlaneCamera.position + ThirdPlaneOffset;
                    Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, t);
                    camera.transform.position = smoothedposition;
                    camera.transform.eulerAngles = new Vector3(xAngle2, yAngle2, zAngle2);
                }
            }
            if (TimeElapsed < MaxTime3)
            {
                camera1.enabled = false;
                camera2.enabled = true;
                camera3.enabled = false;
                GameObject Planetscamera = GameObject.Find("PlanetCamera");
                Planetscamera.GetComponent<PlanetCamera>().enabled = false;
            }
            if (TimeElapsed > 27)
            {
                camera1.enabled = false;
                camera2.enabled = false;
                camera3.enabled = true;
                GameObject Planetscamera = GameObject.Find("PlanetCamera");
                Planetscamera.GetComponent<PlanetCamera>().enabled = true;

            }
        }
    }
}
