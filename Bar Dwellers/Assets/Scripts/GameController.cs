using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _npc;
    [SerializeField] private Player _player;
    private string _scene;

    private void OnEnable()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _npc = GameObject.Find("Loveland Frog");
    }
    void Update()
    {
        _scene = SceneManager.GetActiveScene().name;
        if (_player._currentMission == Mission.Two && _npc.activeSelf != true && _scene == "Speak2")
        {
            _npc.SetActive(true);
        }
    }
}
