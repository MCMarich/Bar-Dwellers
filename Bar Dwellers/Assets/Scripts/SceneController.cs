using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public UnityEngine.SceneManagement.Scene scene;
    public void SendToStirring() // chagnes to stirringscene
    {
        SceneManager.LoadScene("StirringScene");
    }

    public void SendToMixingEl() // changes to mixingscene
    {
        SceneManager.LoadScene("MixingElDiablo");
    }

    public void SendToMixingMoscow()
    {
        SceneManager.LoadScene("MixingMoscow");
    }

    public void SendToMixingMojito()
    {
        SceneManager.LoadScene("MixingMoscow");
    }

    public void SendToMixingScarlet()
    {
        SceneManager.LoadScene("MixingScarlet");
    }

    public void SendToSpeak() // changes to speakingscene
    {
        SceneManager.LoadScene(scene.name);
    }

    public void SendToYouDied()
    {
        SceneManager.LoadScene("YouDied");
    }
    void Awake()
    {
        Debug.Log("Saved Scene Name: " + scene.name);
    }
}
