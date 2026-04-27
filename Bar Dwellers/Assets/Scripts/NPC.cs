using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public enum NPCSpeech
{
    Idle, Talking
}

public class NPC : MonoBehaviour
{
    public NPCSpeech _npcReaction;
    [SerializeField] protected UIController _dialogue;
    [SerializeField] protected NPC _currentNPC;
    [SerializeField] protected Player _player;
    protected DialogueNode _dialogueStartNode;
    protected DialogueNode _currentNode;
    protected int _currentLine = 0;
    protected bool _waitingForPlayerResponse;
    public bool _appear = false;

    [SerializeField] public string _name;
    [SerializeField] protected GameObject _dialoguebox;
        // all the areas the convo can start in 
    public DialogueNode[] _dialogueStartingNodes; 

    protected virtual void Awake()
    {
        _currentNode = _dialogueStartingNodes[0];
    }

    protected virtual void Start()
    {
        if (_npcReaction == NPCSpeech.Idle) // if the NPC is in Idle then you can speak to them/ dialouge box shows up
        {
            _npcReaction = NPCSpeech.Talking;
            _dialoguebox.SetActive(true);
        }
    }

    protected virtual void Update()
    {
        if (_npcReaction == NPCSpeech.Talking // lets NPC talk only when the player lets the speech advance with button presses
            && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            AdvanceDialogue();
        }
    }

    public void AdvanceDialogue()
    {
        if (_currentLine < _currentNode._lines.Length)
        {
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            // show player dialogue choices
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else
        {
            // ends talking state if there is nothing left to talk about 
            EndDialogue();
        }
    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }

    protected void EndDialogue()
    {
        Debug.Log("ended dialogue");
        _npcReaction = NPCSpeech.Idle;
        _dialoguebox.SetActive(false);
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
    }

    // If the drink you choose for the patron is correct
    public void Correct()
    {
        _dialogue._inventorybox.SetActive(false);
        _npcReaction = NPCSpeech.Talking;
        _currentNode = _dialogueStartingNodes[1];
        _dialoguebox.SetActive(true);
    }
    
    // If the drink you choose for the patron is wrong

    public void Wrong()
    {
        _dialogue._inventorybox.SetActive(false);
        _npcReaction = NPCSpeech.Talking;
        _currentNode = _dialogueStartingNodes[2];
        _dialoguebox.SetActive(true);
    }

    public NPC getNPC()
    {
        return this;
    }

    public string GetName()
    {
        return _name;
    }
}
