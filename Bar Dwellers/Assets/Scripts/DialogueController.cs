using UnityEngine;
using UnityEngine.InputSystem.XR;
//using static UnityEditor.Progress;


public class DialogueController : MonoBehaviour
{
    [SerializeField] private UIController _dialogue;
    [SerializeField] private NPC _currentNPC;
    private DialogueNode _dialogueStartNode;
    private DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _waitingForPlayerResponse;
    public bool _appear = false;


    public void Talk(NPC npc)
    {
        _currentNPC = npc;

        if (_currentNPC.GetName() == "FresnoNightCrawler" //end condition
            && Player.Instance._inventoryString.Contains("El Diablo"))
        {
            _dialogueStartNode = _currentNPC._dialogueStartingNodes[1];
        }
        else
        {
            _dialogueStartNode = _currentNPC._dialogueStartingNodes[0];
        }


        _currentNode = _dialogueStartNode;
        _currentNPC._npcReaction = NPCSpeech.Talking;
        _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);

    }

    public void AdvanceDialogue()
    {
        Debug.Log("advanced dialogue");
        if (_currentLine < _currentNode._lines.Length)
        {
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        Debug.Log("ended dialogue");

        _currentNPC._npcReaction = NPCSpeech.Idle;
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;

        _dialogue.HideDialogue();
    }
    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }
}
