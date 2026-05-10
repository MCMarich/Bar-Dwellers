using UnityEngine;
using System.Collections;

public class LovelandFrog : NPC
{
    private float _delaytimer = 22.0f;
    protected override void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        _player = playerObject.GetComponent<Player>();
        if (_player._inventoryString.Contains("Blueberry Mojito"))
        {
            _player._inventoryString.Clear();
            _dialogueController._currentNode = _dialogueStartingNodes[1];
        }
        else if (!_player._inventoryString.Contains("Blueberry Mojito") && _player._inventoryString.Count != 0)
        {
            _player._inventoryString.Clear();
            _dialogueController._currentNode = _dialogueStartingNodes[2];
        }
        else
        {
            base.Awake();
        }
    }
    protected override void Start()
    {
        Debug.Log("This is stupid");
        _reset.text = "...";
    }
    protected override void Update() 
    {
        base.Update();
        if (_scene == "Speak1")
        {
            Debug.Log("delay timer: " + _delaytimer);
            _delaytimer -= Time.deltaTime;
            if (_delaytimer <= 0.0f)
            {
                _player._currentMission = Mission.Two;
                base.Start();
            }
        }
        else
        {
            base.Start();
        }
    }
}
