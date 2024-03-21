using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private int currentSceneIndex;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        DontDestroyOnLoad(gameObject);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex != currentSceneIndex)
        {
            currentSceneIndex = activeSceneIndex;
            if (activeSceneIndex >= 2)
            {
                audioSource.Pause();
            }
        }
    }
}
