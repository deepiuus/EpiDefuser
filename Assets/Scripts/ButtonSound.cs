using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private AudioSource audioSource;
    private static bool created = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        created = true;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnButtonClick()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
