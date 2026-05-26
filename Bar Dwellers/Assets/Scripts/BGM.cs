using JetBrains.Annotations;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    public AudioSource audioSource;
    public AudioClip BGM2;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeMusic(AudioClip newClip)
    {
        // 1. If we are already playing this song, do nothing
        if (audioSource.clip == newClip) return;

        // 2. Stop, swap, and play
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
