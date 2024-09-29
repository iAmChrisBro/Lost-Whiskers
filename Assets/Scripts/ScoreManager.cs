using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public float scoreCount;
    public float totalScore;
 
    public void UpdateScore()
    {
        scoreCount++;
        scoreText.text = scoreCount.ToString() + " / " + totalScore.ToString();
    }
}
