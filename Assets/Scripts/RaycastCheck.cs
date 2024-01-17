using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RaycastCheck : MonoBehaviour
{
    public float maxDistance, radius;
    public Camera cam;
    public static Scene currentScene;
    public static Vector3 currentPos;
    private float timeofDestroy;
    private GameObject LastHit;
    public float timeSinceLastDestroy;
    private GameObject[] rubbish;
    private GameObject signText;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Street")
        {
            rubbish = GameObject.FindGameObjectsWithTag("Rubbish");
        }
        if(currentScene.name == "Scene3")
        {
            signText = GameObject.Find("SignText");
            signText.SetActive(false);
        }
    }
    private void Update()
    {
        /* Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
         Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red); */
        if (Physics.SphereCast(transform.position, radius, transform.forward, out RaycastHit hit, maxDistance))
        {
            if (currentScene.name == "SampleScene")
            {
                if (ColliderCheck.TouchingRock)
                {
                    if (Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        if (hit.collider.gameObject.CompareTag("Rock"))
                        {
                            Destroy(hit.collider.gameObject);
                            RockCounter.RockCount++;
                        }
                    }
                }
            }
            else if (currentScene.name == "Street")
            {
                if (ColliderCheck.TouchingRubbish)
                {
                    if (Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        if (hit.collider.gameObject.CompareTag("Rubbish"))
                        {
                            //currentPos = hit.collider.transform.position;c
                            timeofDestroy = Time.time;
                            hit.collider.gameObject.SetActive(false);
                            RubbishCount.RubbishCounter++;
                        }
                    }
                }
                if (BinColliderCheck.TouchingBin)
                {
                    if (Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        if (hit.collider.gameObject.CompareTag("Bin"))
                        {
                            StoredRubbishAmount.StoredAmount += RubbishCount.RubbishCounter;
                            RubbishCount.RubbishCounter = 0;
                        }
                    }
                }
            }
            else if (currentScene.name == "Scene3")
            {
                if (TriggerCollisionCheck.TouchingSign && !signText.activeInHierarchy)
                {
                    if (Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        print("E PRESSED");
                        if (hit.collider.gameObject.CompareTag("Sign"))
                        {
                            signText.SetActive(true);
                            timeofDestroy = Time.time;
                        }
                    }
                }
            }
            
        }
       if(currentScene.name == "Street")
        {
            timeSinceLastDestroy = Time.time - timeofDestroy;
            if(timeSinceLastDestroy > 4)
            {
                foreach(GameObject rubbishpieces in rubbish)
                {
                    rubbishpieces.SetActive(true);
                }
            }
        }
        if (currentScene.name == "Scene3")
        {
            if (signText.activeInHierarchy)
            {
                timeSinceLastDestroy = Time.time - timeofDestroy;
                if (timeSinceLastDestroy > 0.1f)
                {
                    if (Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        print("MAKE IT NO LONGER APPEAR");
                        signText.SetActive(false);
                        //timeofDestroy = 0;
                    }
                }
            }
            else
            {
                timeSinceLastDestroy = 0;
            }
            if (!TriggerCollisionCheck.TouchingSign)
            {
                signText.SetActive(false);
            }
        }
        /*if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance))
         {
             Debug.DrawRay(transform.position, transform.forward * maxDistance);
         }*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + transform.forward * maxDistance, radius);
    }
}
