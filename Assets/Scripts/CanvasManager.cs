using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject scoreMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
        gameOverUI.SetActive(false);
        scoreMenu.SetActive(false);
    }
}
