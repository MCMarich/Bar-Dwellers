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
    [SerializeField] private UIController _dialogue;
    [SerializeField] private NPC _currentNPC;
    private DialogueNode _dialogueStartNode;
    private DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _waitingForPlayerResponse;
    public bool _appear = false;

    [SerializeField] public string _name;
    [SerializeField] private GameObject _dialoguebox;
        // all the areas the convo can start in 
    public DialogueNode[] _dialogueStartingNodes; 

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
        if (_npcReaction == NPCSpeech.Idle) // if the NPC is in Idle then you can speak to them/ dialouge box shows up
        {
            _npcReaction = NPCSpeech.Talking;
            _dialoguebox.SetActive(true);
        }
    }

    void Update()
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

    private void EndDialogue()
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
        _currentNode = _dialogueStartingNodes[2];
        _dialoguebox.SetActive(true);
    }
    
    // If the drink you choose for the patron is wrong

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
