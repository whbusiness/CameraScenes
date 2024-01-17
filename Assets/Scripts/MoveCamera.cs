using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    public static float TimeElapsed;
    public float MaxTime1 = 2, MaxTime2 = 10;
    public static float MaxTime3 = 23f;
    public float tUp, tDown;
    public Vector3 XaxisMovement;
    public Transform sun, player;
    public float RotTimeUp, RotTimeDown;
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
            Playercam.SetActive(true);
        }
        TimeElapsed = 0f;
    }
    void FixedUpdate()
    {
        if (!playing)
        {
            if (TimeElapsed < 23)
            {
                TimeElapsed += Time.deltaTime;
            }
            if (TimeElapsed > MaxTime1)
            {
                if (TimeElapsed < MaxTime2)
                {
                    //Vector3 currentposition = FirstPlaneCamera.position + FirstPlaneOffset;
                    Vector3 DesiredPosition = sun.position + XaxisMovement;
                    Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, tUp * Time.fixedDeltaTime);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                    transform.position = smoothedposition;
                    var TargetRot = Quaternion.LookRotation(sun.position - player.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, RotTimeUp * Time.fixedDeltaTime);
                }
            }
            if (TimeElapsed > MaxTime2 && MaxTime2 < MaxTime3)
            {
                Vector3 smoothedposition = Vector3.Lerp(transform.position, player.position, tDown * Time.fixedDeltaTime);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                transform.position = smoothedposition;
                var TargetRot = Quaternion.LookRotation(transform.position - sun.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, RotTimeDown * Time.fixedDeltaTime);
            }
        }
    }
}
