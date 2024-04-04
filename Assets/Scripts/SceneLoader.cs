using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene0()
    {
        StartCoroutine(LoadAsync(1));
    }

    public void LoadScene1()
    {
        StartCoroutine(LoadAsync(2));
    }

    public void LoadScene2()
    {
        StartCoroutine(LoadAsync(3));
    }

    public void LoadScene3()
    {
        StartCoroutine(LoadAsync(4));
    }

    public void LoadScene4()
    {
        StartCoroutine(LoadAsync(6));
    }

    public void LoadScene5()
    {
        StartCoroutine(LoadAsync(7));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
