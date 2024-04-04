using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public AudioSource audioSource;
    public float timeLeft = 150f;
    private bool created = false;

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            string minutes = Mathf.FloorToInt(timeLeft / 60).ToString("00");
            string seconds = Mathf.FloorToInt(timeLeft % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;

            if (timeLeft <= 14.5f && !created)
            {
                audioSource.Play();
                created = true;
            }
        }
        else
        {
            timerText.text = "00:00";
            audioSource.Stop();
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(5);
    }
}
