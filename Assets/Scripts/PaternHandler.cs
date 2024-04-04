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
    public int maxTour = 6;
    private AudioSource audioSource;
    private List<int> activePatternIndices = new List<int>();
    private List<int> playerInputIndices = new List<int>();

    void Start()
    {
        foreach (GameObject pattern in paterns)
        {
            pattern.SetActive(false);
        }
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnPatern());
    }

    IEnumerator SpawnPatern()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            yield return StartCoroutine(MarvinPatern());
        }
        else
        {
            yield return StartCoroutine(BasicPatern());
        }
    }

    IEnumerator MarvinPatern()
    {
        for (int tour = 1; tour <= maxTour; tour++)
        {
            activePatternIndices.Clear();
            bool correctInput = false;
            while (!correctInput)
            {
                yield return StartCoroutine(UpdateImages(tour));
                correctInput = playerInputIndices.Count == tour;
            }
            if (lifeSystem.lives <= 0)
            {
                Debug.Log("Game over!");
                SceneManager.LoadScene(5);
                yield break;
            }
        }
        Debug.Log("You win!");
        SceneManager.LoadScene(1);
    }

    IEnumerator BasicPatern()
    {
        for (int tour = 1; tour <= maxTour; tour++)
        {
            bool correctInput = false;
            while (!correctInput)
            {
                yield return StartCoroutine(UpdateImages(tour));
                correctInput = playerInputIndices.Count == tour;
            }
            if (lifeSystem.lives <= 0)
            {
                Debug.Log("Game over!");
                SceneManager.LoadScene(5);
                yield break;
            }
        }
        Debug.Log("You win!");
        SceneManager.LoadScene(1);
    }

    IEnumerator UpdateImages(int tour)
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
        bool correctInput = playerInputIndices.Count == tour;      
        if (lifeSystem.lives <= 0)
        {
            Debug.Log("Game over!");
            SceneManager.LoadScene(5);
            yield break;
        }
    }

    public void OnInputButton(int index)
    {
        playerInputIndices.Add(index);
        audioSource.Play();
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
        for (int i = 0; i < maxTour; i++)
        {
            Sprite newSprite = i < tour ? lightOn : lightOff;
            if (i < lightImages.Length)
            {
                lightImages[i].GetComponent<Image>().sprite = newSprite;
            }
        }
    }
}
