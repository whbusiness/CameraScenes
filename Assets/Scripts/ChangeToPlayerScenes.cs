using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToPlayerScenes : MonoBehaviour
{
    public void OnForestClick()
    {
        ForestCamera.playing = true;
        SceneManager.LoadScene("SampleScene");
    }
    public void OnStreetClick()
    {
        BuildingCamera.playing = true;
        SceneManager.LoadScene("Street");
    }
    public void OnSpaceClick()
    {
        FollowPlanes.playing = true;
        PlanetCamera.playing = true;
        SceneManager.LoadScene("Scene3");
    }
    public void OnMenu()
    {
        ForestCamera.playing = false;
        BuildingCamera.playing = false;
        FollowPlanes.playing = false;
        PlanetCamera.playing = false;
        SceneManager.LoadScene("StartScreen");
    }
}
