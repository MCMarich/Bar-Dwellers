using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public UnityEngine.SceneManagement.Scene scene;
    [SerializeField] private Player _player;
    private string _mission;
    
    private void Start()
    {
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

    public void SendToSpeak() // changes to speakingscene
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
    }

    public void SendToYouDied()
    {
        SceneManager.LoadScene("YouDied");
    }
}
