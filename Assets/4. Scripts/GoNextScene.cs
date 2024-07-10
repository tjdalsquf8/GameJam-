using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextScene : MonoBehaviour
{
    public void SceneChangeStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void SceneChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SceneChangeEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
