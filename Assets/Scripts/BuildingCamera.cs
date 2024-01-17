using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingCamera : MonoBehaviour
{
    public static float TimeElapsed;
    public float MaxTime1 = 2, MaxTime2 = 10, MaxTime3 = 20;
    public static float MaxTime5 = 30f;
    public float tUp, tDown;
    public Transform Door, Window, player, emptyDoor;
    public float RotTimeUp, RotTimeDown, WindowRot, WindowTime;
    public static bool playing = false;
    public GameObject Playercam;
    private void Start()
    {
        //transform.SetPositionAndRotation(player.position, player.rotation);
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
            if (TimeElapsed < MaxTime5)
            {
                TimeElapsed += Time.deltaTime;
            }
            if (TimeElapsed > MaxTime1)
            {
                if (TimeElapsed < MaxTime2)
                {
                    //Vector3 currentposition = FirstPlaneCamera.position + FirstPlaneOffset;
                    Vector3 DesiredPosition = transform.position + Door.position;
                    Vector3 smoothedposition = Vector3.Lerp(transform.position, DesiredPosition, tUp * Time.fixedDeltaTime);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                    transform.position = smoothedposition;
                    var TargetRot = Quaternion.LookRotation(Door.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot.normalized, RotTimeUp * Time.fixedDeltaTime);
                }
            }
            if (TimeElapsed > MaxTime2 && TimeElapsed < MaxTime3)
            {
                Vector3 smoothedposition = Vector3.Lerp(transform.position, emptyDoor.position + new Vector3(0,0,4), tDown * Time.fixedDeltaTime);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                transform.position = smoothedposition;
                var TargetRot = Quaternion.LookRotation(emptyDoor.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot.normalized, RotTimeDown * Time.fixedDeltaTime);
            }
            if(TimeElapsed > MaxTime3)
            {
                Vector3 smoothedposition = Vector3.Lerp(transform.position, Window.position - new Vector3(3,0,0), WindowTime * Time.fixedDeltaTime);//Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothTime);
                transform.position = smoothedposition;
                var TargetRot = Quaternion.LookRotation(Window.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetRot.normalized, WindowRot * Time.fixedDeltaTime); //Quaternion.RotateTowards(transform.rotation, TargetRot, WindowRot * Time.fixedDeltaTime); 
            }
        }
    }
}
