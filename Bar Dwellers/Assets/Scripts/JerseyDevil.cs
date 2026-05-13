using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JerseyDevil : NPC
{
    private float _delaytimer = 5.0f;
    protected override void Awake()
    {
        _scene = SceneManager.GetActiveScene().name;
        if (_scene == "Speak3")
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            _player = playerObject.GetComponent<Player>();
            if (_player._inventoryString.Contains("Moscow Mule"))
            {
                _player._inventoryString.Clear();
                _dialogueController._currentNode = _dialogueStartingNodes[1];
            }
            else if (!_player._inventoryString.Contains("Moscow Mule") && _player._inventoryString.Count != 0)
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
        if (_scene == "Speak3")
        {
            base.Start();
        }
    }
    protected override void Update() 
    {
        base.Update();
        if (_scene == "Speak2")
        {
            _delaytimer -= Time.deltaTime;
            if (_delaytimer > 0.0f)
            {
                _timerGoing = true;
            }
            if (_delaytimer <= 0.0f && _timerGoing == true)
            {
                base.Awake();
                _player._currentMission = Mission.Three;
                _dialogueController._currentNPC = this;
                base.Start();
                _timerGoing = false;
            }
        }
    }
}
