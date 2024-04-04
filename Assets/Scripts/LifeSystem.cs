using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    public int lives = 3;
    public Text lifeText;

    void UpdateLifeText()
    {
        lifeText.text = "" + lives;
    }

    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLifeText();
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }

    void Start()
    {
        UpdateLifeText();
    }
}
