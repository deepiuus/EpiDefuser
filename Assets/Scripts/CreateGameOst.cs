using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameOst : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        DontDestroyOnLoad(gameObject);
    }
}
