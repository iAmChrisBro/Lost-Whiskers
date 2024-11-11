using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

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
}
