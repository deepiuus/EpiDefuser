using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaternHandler : MonoBehaviour
{
    public LifeSystem lifeSystem;
    public GameObject[] paterns;
    public GameObject[] inputs;
    public GameObject[] lightImages;
    public Sprite lightOn;
    public Sprite lightOff;
    private List<int> activePatternIndices = new List<int>();
    private List<int> playerInputIndices = new List<int>();

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
            bool correctInput = false;
            while (!correctInput)
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
                yield return StartCoroutine(WaitForPlayerInput(tour));
                correctInput = playerInputIndices.Count == tour;
                
                if (lifeSystem.lives <= 0)
                {
                    Debug.Log("Game over!");
                    SceneManager.LoadScene(0);
                    yield break;
                }
            }

            if (lifeSystem.lives <= 0)
            {
                Debug.Log("Game over!");
                SceneManager.LoadScene(0);
                yield break;
            }
        }
        Debug.Log("You win!");
        SceneManager.LoadScene(1);
    }

    public void OnInputButton(int index)
    {
        playerInputIndices.Add(index);
    }

    IEnumerator WaitForPlayerInput(int tour)
    {
        playerInputIndices.Clear();
        while (playerInputIndices.Count < tour)
        {
            yield return null;
        }

        for (int i = 0; i < tour; i++)
        {
            if (i >= activePatternIndices.Count || i >= playerInputIndices.Count)
            {
                continue;
            }
            
            if (activePatternIndices[i] != playerInputIndices[i])
            {
                lifeSystem.DecreaseLife();

                if (lifeSystem.lives <= 0)
                {
                    yield break;
                }
                playerInputIndices.Clear();
                yield return new WaitForSeconds(0);
            }
        }
        yield return new WaitForSeconds(0);
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
