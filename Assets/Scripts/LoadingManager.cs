using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadingManager : MonoBehaviour
{
    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject scoreMenu;
    [SerializeField] private GameObject btn;
    [SerializeField] private GameObject btn2;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;

    public void LoadLevelBtn(string levelToLoad)
    {
        EventSystem.current.SetSelectedGameObject(btn);
        mainMenu.SetActive(false);
        gameOverUI.SetActive(false);
        scoreMenu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    public void LoadLevelBtn2(string levelToLoad)
    {
        EventSystem.current.SetSelectedGameObject(btn2);
        mainMenu.SetActive(false);
        gameOverUI.SetActive(false);
        scoreMenu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while(!loadOperation.isDone)
        {
            mainMenu.SetActive(false);
            gameOverUI.SetActive(false);
            scoreMenu.SetActive(false);
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }

}
