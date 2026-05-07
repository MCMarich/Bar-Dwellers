using System.Buffers.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FresnoNightCrawler : NPC
{
    public SceneController scenecontroller;
    protected override void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        _player = playerObject.GetComponent<Player>();

        if (_player._currentMission != Mission.One)
        {
            Destroy(gameObject);
        }

        if (_player._inventoryString.Contains("El Diablo"))
        {
            _player._inventoryString.Clear();
            _dialogueController._currentNode = _dialogueStartingNodes[1];
        }
        else if (!_player._inventoryString.Contains("El Diablo") && _player._inventoryString.Count != 0)
        {
            _player._inventoryString.Clear();
            _dialogueController._currentNode = _dialogueStartingNodes[2];
        }
        else
        {
            base.Awake();
        }
    }
}
