using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
using TMPro.Examples;
using TMPro;

public enum NPCSpeech
{
    Idle, Talking
}

public class NPC : MonoBehaviour
{
    public NPCSpeech _npcReaction;
    [SerializeField] protected Player _player;
    [SerializeField] protected SceneController _sceneController;
    [SerializeField] public PlayableDirector _cutscene;
    [SerializeField] protected TMP_Text _reset;
    [SerializeField] protected DialogueController _dialogueController;
    public bool _appear = false;
    private string _scene;

    [SerializeField] public string _name;
    [SerializeField] public GameObject _dialoguebox;
        // all the areas the convo can start in 
    public DialogueNode[] _dialogueStartingNodes; 

    protected virtual void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        _dialogueController._currentNode = _dialogueStartingNodes[0];
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
            _dialogueController.AdvanceDialogue();
        }
        _scene= SceneManager.GetActiveScene().name;
        if (_scene != "Speak")
        {
            gameObject.SetActive(false);
        }
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
