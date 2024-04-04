using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
        Invoke("GameOver", 5f);
    }

    void GameOver()
    {
        audioSource.Stop();
        SceneManager.LoadScene(0);
    }
}
