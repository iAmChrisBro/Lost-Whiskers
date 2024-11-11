using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    private WolfAI wolfCheck;

    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject hudUI;
    [SerializeField]
    private GameObject[] gameOverStars;
    [SerializeField]
    private ScoreManager scoreCount;

    void Start()
    {
        wolfCheck = FindObjectOfType<WolfAI>();
        gameOverUI.SetActive(false);
        hudUI.SetActive(true);
    }

    void Update()
    {
        if (wolfCheck.GetPlayerDead())
        {
            float count = scoreCount.scoreCount;
            if (0 <= count && count < 4)
            {
                gameOverStars[0].SetActive(true);
            }
            else if (4 <= count && count < 8)
            {
                gameOverStars[1].SetActive(true);
            }
            else if (8 <= count && count < 12)
            {
                gameOverStars[2].SetActive(true);
            }
            else if (count == 12)
            {
                gameOverStars[3].SetActive(true);
            }
            gameOverUI.SetActive(true);
            hudUI.SetActive(false);

        }
    }
}
