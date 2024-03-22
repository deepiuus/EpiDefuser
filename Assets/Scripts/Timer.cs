using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeLeft = 61f;

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            string minutes = Mathf.FloorToInt(timeLeft / 60).ToString("00");
            string seconds = Mathf.FloorToInt(timeLeft % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }
        else
        {
            timerText.text = "00:00";
        }
    }
}
