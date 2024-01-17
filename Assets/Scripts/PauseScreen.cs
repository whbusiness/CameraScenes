using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void OnChangeScene()
    {
        SceneManager.LoadScene("EndScene");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Movement.Pause = false;
    }
    public void OnResume()
    {
        Movement.EscapeIsPressed = false;
        Movement.Pause = false;
    }
}
