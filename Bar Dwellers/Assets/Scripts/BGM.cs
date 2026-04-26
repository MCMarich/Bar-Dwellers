using UnityEngine;

public class BGM : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
