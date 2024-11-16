using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private WolfAI[] wolfCheck;
    public static bool isDead;

    void Start()
    {
        wolfCheck = FindObjectsOfType<WolfAI>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {   
        CheckIfPlayerDead();
    }

    private void CheckIfPlayerDead()
    {
        foreach (WolfAI check in wolfCheck)
        {
            if (check.GetPlayerDead())
            {
                isDead = true;
                Destroy(gameObject);
            }
        }
    }

}
