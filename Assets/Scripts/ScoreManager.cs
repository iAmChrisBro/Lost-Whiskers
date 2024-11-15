using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int scoreCount;
    public int totalScore;
    [SerializeField]
    private GameObject[] scoreMenuStars;
    [SerializeField]
    private GameObject scoreMenuUI;

    void Awake()
    {
        scoreMenuUI.SetActive(false);
    }

    void Start()
    {
    }

    void Update()
    {
        if(PlatformMovement.playersOnPlat == 1)
        {
            SetScoreMenu();
        }

        if (Input.GetKeyDown("space"))
            UpdateScore();
    }
 
    public void UpdateScore()
    {
        scoreCount++;
        scoreText.text = scoreCount.ToString() + " / " + totalScore.ToString();
    }

    public void SetScoreMenu()
    {
       scoreMenuUI.SetActive(true);

        if (0 <= scoreCount && scoreCount < 4)
        {
            scoreMenuStars[0].SetActive(true);
        }
        else if (4 <= scoreCount && scoreCount < 7)
        {
            scoreMenuStars[1].SetActive(true);
        }
        else if (7 <= scoreCount && scoreCount < 12)
        {
            scoreMenuStars[2].SetActive(true);
        }
        else if (scoreCount == 12)
        {
            scoreMenuStars[3].SetActive(true);
        }

    }
}
