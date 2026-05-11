using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    
    public string currentSpeakScene;

    private string savedScene;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkCurrentSpeak()
    {
        currentSpeakScene = SceneManager.GetActiveScene().name;
        Debug.Log("Marked " + currentSpeakScene + " as the current speak scene");
    }

    public void ReturnSpeak()
    {
        if (!string.IsNullOrEmpty(currentSpeakScene))
        {
            SceneManager.LoadScene(currentSpeakScene);
        }
        else
        {
            Debug.LogError("No return scene saved!");
        }
    }
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

    public void SendToYouDied()
    {
        SceneManager.LoadScene("YouDied");
    }

    public void SendToMainMenu()
    {
        savedScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("MainMenu");
    }
    public void SendToSavedscene()
    {
        SceneManager.LoadScene(savedScene);
    }
}
