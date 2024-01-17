using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestCamera : MonoBehaviour
{
    public static float TimeElapsed;
    public float MaxTime1, MaxTime2;
    public static float MaxTime3 = 20f;
    public float tUp, tDown;
    public Vector3 YaxisMovement;
    //public Camera playercam;
    public Transform player, LookAtTarget;
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
            gameObject.SetActive(false);
            Playercam.SetActive(true);
        }
        TimeElapsed = 0f;
    }
    void FixedUpdate()
    {
        if (!playing)
        {
            if (TimeElapsed < MaxTime3 +0.1f)
            {
                TimeElapsed += Time.deltaTime;
            }
            if (TimeElapsed > MaxTime1)
            {
                if (TimeElapsed < MaxTime2)
                {
                    //Vector3 currentposition = FirstPlaneCamera.position + FirstPlaneOffset;
                    Vector3 DesiredPosition = player.position + YaxisMovement;
                    Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, tUp * Time.deltaTime);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                    transform.position = smoothedposition;
                    /*Vector3 TargetRot = player.position - transform.position;
                    Vector3 rotToPlayer = Vector3.RotateTowards(transform.forward, TargetRot, RotTimeUp * Time.deltaTime, 0.0f);
                    transform.rotation = Quaternion.LookRotation(rotToPlayer);*/
                    var TargetRot = Quaternion.LookRotation(player.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, RotTimeUp * Time.fixedDeltaTime);
                }
            }
            if (TimeElapsed > MaxTime2 && MaxTime2 < MaxTime3)
            {
                Vector3 smoothedposition = Vector3.Lerp(transform.position, player.position, tDown * Time.deltaTime);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                transform.position = smoothedposition;
                var TargetRot = Quaternion.LookRotation(LookAtTarget.position - player.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot, RotTimeDown * Time.fixedDeltaTime);
            }
        }
    }
}
