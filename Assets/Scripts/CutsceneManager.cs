using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;

    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject CutsceneCanvas;

    [SerializeField] private int SecsToLoad;
    [SerializeField] private string levelToLoad;


    void Start()
    {
        StartCoroutine(WaitToLoad(SecsToLoad,levelToLoad));
    }

    private void StartLoadLevel(string levelToLoad)
    {
        CutsceneCanvas.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }

    IEnumerator WaitToLoad(int secs,string levelToLoad)
    {
        yield return new WaitForSeconds(secs);
        StartLoadLevel(levelToLoad);
    }
}
