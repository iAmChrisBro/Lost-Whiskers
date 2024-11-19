using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject menuBtn;
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
        EventSystem.current.SetSelectedGameObject(menuBtn);
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadCutscene(string cutsceneName)
    {
        SceneManager.LoadScene(cutsceneName);
    }
}
