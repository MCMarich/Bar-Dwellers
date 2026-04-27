using System.Buffers.Text;
using UnityEngine;

public class FresnoNightCrawler : NPC
{
    protected override void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        _player = playerObject.GetComponent<Player>();

        if (_player._inventoryString.Contains("El Diablo"))
        {
            _currentNode = _dialogueStartingNodes[1];
        }
        else if (_player._inventoryString.Contains("El Diablo") && _player._inventoryString.Count != 0)
        {
            _currentNode = _dialogueStartingNodes[2];
        }
        else
        {
            base.Awake();
        }
    }
}
