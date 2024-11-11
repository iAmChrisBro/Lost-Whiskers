using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private WolfAI wolfCheck;

    void Start()
    {
       wolfCheck = FindObjectOfType<WolfAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wolfCheck.GetPlayerDead())
        {
            Destroy(gameObject);
        }
    }

}
