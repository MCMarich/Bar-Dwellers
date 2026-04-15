using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NPCSpeech
{
    Idle, Talking
}

public class NPC : MonoBehaviour
{
    public NPCSpeech _npcReaction;
    public bool _playerHasKeyItem;

    // dialogue controller variables
    [SerializeField] private UIController _dialogue;
    [SerializeField] private NPC _currentNPC;
    private DialogueNode _dialogueStartNode;
    private DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _waitingForPlayerResponse;
    public bool _appear = false;

    // dialogue member variables
    [SerializeField] public string _name;
    [SerializeField] private string _keyItem; // assigned individually to NPC
    [SerializeField] private GameObject _dialoguebox;
    public DialogueNode[] _dialogueStartingNodes; // list of starting dialogue depending on _hasKeyItem 

    private void Awake()
    {
        if (_name == "FresnoNightCrawler" 
            && Player.Instance._inventoryString.Contains("El Diablo"))
        {
            _currentNode = _dialogueStartingNodes[1];
        }
        else
        {
            _currentNode = _dialogueStartingNodes[0];
        }
    }

    private void Start()
    {
        if (_npcReaction == NPCSpeech.Idle) // if idle and get interact input
        {
            _npcReaction = NPCSpeech.Talking;
            _dialoguebox.SetActive(true);
        }
    }

    void Update()
    {
        if (_npcReaction == NPCSpeech.Talking // if talking and get continue input
            && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            AdvanceDialogue();
        }
    }

    public void AdvanceDialogue()
    {
        Debug.Log("advanced dialogue");
        if (_currentLine < _currentNode._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            // show player dialogue options, if there are any
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else
        {
            // if there are no NPC or player lines left, close dialogue UI
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

    private void EndDialogue()
    {
        Debug.Log("ended dialogue");
        _npcReaction = NPCSpeech.Idle;
        _dialoguebox.SetActive(false);
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
    }

    public void Correct()
    {
        _dialogue._inventorybox.SetActive(false);
        _npcReaction = NPCSpeech.Talking;
        _currentNode = _dialogueStartingNodes[2];
        _dialoguebox.SetActive(true);
    }

    public void Wrong()
    {
        _dialogue._inventorybox.SetActive(false);
        _npcReaction = NPCSpeech.Talking;
        _currentNode = _dialogueStartingNodes[3];
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
