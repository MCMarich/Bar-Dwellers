using UnityEngine;

public class musicswitch : MonoBehaviour
{
    public AudioClip newmusic;
    void Awake()
    {
        BGM.instance.ChangeMusic(newmusic);
    }
}
