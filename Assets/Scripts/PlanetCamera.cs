using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCamera : MonoBehaviour
{
    public Transform EarthCamera;
    public Transform SaturnRingCamera;
    public Transform MoonCamera;
    public Vector3 EarthOffset;
    public Vector3 SaturnOffset;
    public Vector3 MoonOffset;
    public new Transform camera;
    public static float Timer;
    public float MaxTime10;
    public float MaxTime20;
    public static float MaxTime30 = 24f;
    public float t;
    public float xAngle1;
    public float yAngle1;
    public float zAngle1;
    public float xAngle2;
    public float yAngle2;
    public float zAngle2;
    public float Xrotation;
    public float Yrotation;
    public float Zrotation;
    public GameObject player;
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
        Timer = 0f;
    }
    void LateUpdate()
    {
        if (!playing)
        {
            if (Timer < 31)
            {
                Timer += Time.deltaTime;
            }
            if (Timer < MaxTime10)
            {
                //Vector3 currentposition = EarthCamera.position + EarthOffset;
                Vector3 DesiredPosition = EarthCamera.position + EarthOffset;
                Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, t);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                camera.transform.position = smoothedposition;
                camera.transform.eulerAngles = new Vector3(xAngle1, yAngle1, zAngle1);
            }
            if (Timer > MaxTime10)
            {
                if (Timer < MaxTime20)
                {
                    // Vector3 currentposition = EarthCamera.position + EarthOffset;
                    Vector3 DesiredPosition = MoonCamera.position + MoonOffset;
                    Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, t);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                    camera.transform.position = smoothedposition;
                    camera.transform.eulerAngles = new Vector3(xAngle1, yAngle1, zAngle1);


                }
            }
            if (Timer > MaxTime20)
            {
                if (Timer < MaxTime30)
                {
                    Vector3 DesiredPosition = SaturnRingCamera.position + SaturnOffset;
                    Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, t);
                    camera.transform.position = smoothedposition;
                    camera.transform.eulerAngles = new Vector3(xAngle2, yAngle2, zAngle2);
                }
            }
            /*if(Timer > MaxTime30)
            {
                scenemanag
            }*/
        }

       /* if(TimeElapsed > MaxTime3)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
        }*/
    }
}
