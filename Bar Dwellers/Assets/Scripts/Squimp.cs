using UnityEngine;
using System.Collections;

public class Squimp : NPC
{
    private float _delaytimer = 5.0f;
    protected override void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        _player = playerObject.GetComponent<Player>();
        if (_player._inventoryString.Contains("Vodka"))
        {
            _player._inventoryString.Clear();
            _dialogueController._currentNode = _dialogueStartingNodes[1];
        }
        else if (!_player._inventoryString.Contains("Vodka") && _player._inventoryString.Count != 0)
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
        if (_scene == "Speak4")
        {
            Debug.Log("delay timer: " + _delaytimer);
            _delaytimer -= Time.deltaTime;
            if (_delaytimer <= 0.0f)
            {
                _player._currentMission = Mission.Four;
                _dialogueController._currentNPC = this;
                base.Start();
            }
        }
        else
        {
            base.Start();
        }
    }
}
