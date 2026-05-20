using UnityEngine;

public class Linda : NPC
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

        if (_player._inventoryString.Contains("Water"))
        {
            _player._inventoryString.Clear();
            _dialogueController._currentNode = _dialogueStartingNodes[1];
        }
        else
        {
            base.Awake();
        }
    }
}
