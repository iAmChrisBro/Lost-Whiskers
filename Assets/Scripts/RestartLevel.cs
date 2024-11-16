using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestartLevel : MonoBehaviour
{
    private WolfAI[] wolfCheck;

    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject hudUI;
    [SerializeField]
    private GameObject[] gameOverStars;
    [SerializeField]
    private ScoreManager scoreCount;
    [SerializeField]
    private TMP_Text scoreText;



    void Start()
    {
        wolfCheck = FindObjectsOfType<WolfAI>();
        gameOverUI.SetActive(false);
        hudUI.SetActive(true);
    }

    void Update()
    {
      CheckIfPlayerDead();
    }

    public void SetScoreMenu()
    {
        float count = scoreCount.scoreCount;

        if (0 <= count && count < 4)
        {
            gameOverStars[0].SetActive(true);
        }
        else if (4 <= count && count < 7)
        {
            gameOverStars[1].SetActive(true);
        }
        else if (7 <= count && count < 12)
        {
            gameOverStars[2].SetActive(true);
        }
        else if (count == 12)
        {
            gameOverStars[3].SetActive(true);
        }
        scoreText.text = count.ToString() + "/ 12";
    }

    private void CheckIfPlayerDead()
    {
        foreach (WolfAI check in wolfCheck)
        {
            if (check.GetPlayerDead())
            {
                SetScoreMenu();
                gameOverUI.SetActive(true);
                hudUI.SetActive(false);
            }
        }
    }
}
