using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    [SerializeField] private Player _player;
    private string _mission;
    private string _savedScene;
    public static SceneController Instance;
    
    private void Start()
    {
        Instance = this;
        _player = Player.Instance;
    }
    private void Update()
    {
        _mission = _player._currentMission.ToString();
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
        SceneManager.LoadScene("MixingMojito");
    }

    public void SendToMixingScarlet()
    {
        SceneManager.LoadScene("MixingScarlet");
    }
    public void SendToMixingGarbage()
    {
        SceneManager.LoadScene("MixingGarbageCan");
    }
    public void SendToMixingVodka()
    {
        SceneManager.LoadScene("MixingVodka");
    }

    public void SendToYouDied()
    {
        SceneManager.LoadScene("YouDied");
    }
    public void SendToSpeak()
    {
        if (_mission == "One")
        {
            SceneManager.LoadScene("Speak1");
        }
        else if (_mission == "Two")
        {
            SceneManager.LoadScene("Speak2");
        }
        else if (_mission == "Three")
        {
            SceneManager.LoadScene("Speak3");
        }
        else if (_mission == "Four")
        {
            SceneManager.LoadScene("Speak4");
        }
        else if (_mission == "Five")
        {
            SceneManager.LoadScene("Speak5");
        }
    }

    public void SendToMainMenu()
    {
        _savedScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("MainMenu");
    }

    public void SendToSavedscene()
    {
        SceneManager.LoadScene(_savedScene);
    }
}
