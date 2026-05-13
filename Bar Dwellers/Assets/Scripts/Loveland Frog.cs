using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LovelandFrog : NPC
{
    private float _delaytimer = 20.0f;
    protected override void Awake()
    {
        _scene = SceneManager.GetActiveScene().name;
        if (_scene == "Speak2") 
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            _player = playerObject.GetComponent<Player>();
            if (_player._inventoryString.Contains("Bluberry Mojito"))
            {
                _player._inventoryString.Clear();
                _dialogueController._currentNode = _dialogueStartingNodes[1];
            }
            else if (!_player._inventoryString.Contains("Bluberry Mojito") && _player._inventoryString.Count != 0)
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
    protected override void Start()
    {
        _reset.text = "...";
        _scene = SceneManager.GetActiveScene().name;
        if (_scene == "Speak2")
        {
            base.Start();
        }
    }
    protected override void Update() 
    {
        base.Update();
        if (_scene == "Speak1")
        {
            _delaytimer -= Time.deltaTime;
            if (_delaytimer > 0.0f)
            {
                _timerGoing = true;
            }
            if (_delaytimer <= 0.0f && _timerGoing == true)
            {
                base.Awake();
                _player._currentMission = Mission.Two;
                _dialogueController._currentNPC = this;
                base.Start();
                _timerGoing = false;
            }
        }
    }
}
