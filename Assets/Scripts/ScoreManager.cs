using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText,finalScore;
    public int scoreCount;
    public int totalScore;
    [SerializeField]
    private GameObject[] scoreMenuStars;
    [SerializeField]
    private GameObject scoreMenuUI;
    private AudioSource collectSound;
    public static bool levelDone;
    [SerializeField]
    private GameObject restartBtn;

    void Awake()
    {
        scoreMenuUI.SetActive(false);
        collectSound = GetComponent<AudioSource>();
        levelDone = false;
    }

    void Update()
    {
        if(KioskManager.playersOnPlat == 3)
        {
            levelDone = true;
            SetScoreMenu();
        }

        /*if (Input.GetKeyDown("space"))
        {
            UpdateScore();
        }*/
    }
 
    public void UpdateScore()
    {
        collectSound.Play();
        scoreCount++;
        scoreText.text = scoreCount.ToString() + "/" + totalScore.ToString();
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
        finalScore.text = scoreCount.ToString() + "/12";

        EventSystem.current.SetSelectedGameObject(restartBtn);
    }
}
