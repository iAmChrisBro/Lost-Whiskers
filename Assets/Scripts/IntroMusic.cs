using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip TitleMusic;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "IntroCutscene" || sceneName == "Cutscene2")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = TitleMusic;
        audioSource.Play();
    }
}
