using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public Transform original;
    public Transform target;
    public float speed;
    public Transform LookHere;
    void Update()
    {
        if (!Movement.Pause)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);//Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);//Vector3.MoveTowards(transform.position, target.transform.position, speed);
            if (transform.position == target.transform.position)
            {
                gameObject.transform.position = original.transform.position;
            }
            transform.LookAt(LookHere);
        }
    }
}
