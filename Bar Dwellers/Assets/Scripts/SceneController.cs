using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SendToStirring() // Mixing -> Stirring
    {
        SceneManager.LoadScene("StirringScene");
    }
    public void SendToMixing() // Speak -> Mixing
    {
        SceneManager.LoadScene("MixingScene");
    }
}
