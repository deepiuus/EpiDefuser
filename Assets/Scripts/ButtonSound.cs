using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private AudioSource audioSource;
    private static bool created = false;

    void Awake()
    {
        created = true;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void OnButtonClick()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
