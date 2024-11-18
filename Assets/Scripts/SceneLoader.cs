using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadCutscene(string cutsceneName)
    {
        SceneManager.LoadScene(cutsceneName);
    }
}
