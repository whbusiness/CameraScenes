using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class SceneTransition : MonoBehaviour
{
    public Animator FadeTransition;
    private Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (scene.name == "SampleScene" && ForestCamera.TimeElapsed > ForestCamera.MaxTime3)
        {
            StartCoroutine(nameof(PlayFade));
        }
        if (scene.name == "Street" && BuildingCamera.TimeElapsed > BuildingCamera.MaxTime5)
        {
            StartCoroutine(nameof(PlayFade));
        }
        if (scene.name == "Scene3" && PlanetCamera.Timer > PlanetCamera.MaxTime30)
        {
            StartCoroutine(nameof(PlayFade));
        }
    }

    public void OnStart()
    {
        StartCoroutine(nameof(PlayFade));
    }
    public void OnQuit()
    {
        Application.Quit();
    }

    IEnumerator PlayFade()
    {
        print("Move ON");
        FadeTransition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
