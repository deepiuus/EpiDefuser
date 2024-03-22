using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaternHandler : MonoBehaviour
{
    public GameObject[] paterns;
    public GameObject[] lightImages;
    public Sprite lightOn;
    public Sprite lightOff;
    private List<int> activePatternIndices = new List<int>();

    void Start()
    {
        foreach (GameObject pattern in paterns)
        {
            pattern.SetActive(false);
        }
        StartCoroutine(SpawnPatern());
    }

    IEnumerator SpawnPatern()
    {
        for (int tour = 1; tour <= 6; tour++)
        {
            UpdateLightImages(tour);
            for (int i = 0; i < tour; i++)
            {
                if (i >= activePatternIndices.Count)
                {
                    activePatternIndices.Add(Random.Range(0, paterns.Length));
                }
                GameObject pattern = paterns[activePatternIndices[i]];
                pattern.SetActive(true);
                StartCoroutine(DisablePattern(pattern));
                yield return new WaitForSeconds(1f);
            }
        }
    }

    IEnumerator DisablePattern(GameObject pattern)
    {
        yield return new WaitForSeconds(0.8f);
        pattern.SetActive(false);
    }

    void UpdateLightImages(int tour)
    {
        for (int i = 0; i < lightImages.Length; i++)
        {
            Sprite newSprite = i < tour ? lightOn : lightOff;
            lightImages[i].GetComponent<Image>().sprite = newSprite;
        }
    }
}
