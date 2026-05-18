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
    [SerializeField] protected TMP_Text _nametag;
    public bool _appear = false;
    protected string _scene;

    [SerializeField] public string _name;
    [SerializeField] public GameObject _dialoguebox;
        // all the areas the convo can start in 
    public DialogueNode[] _dialogueStartingNodes; 
    protected bool _timerGoing = false;

    protected virtual void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        GameObject playerObject = GameObject.FindWithTag("Player");
        _player = playerObject.GetComponent<Player>();
        _dialogueController._currentNode = _dialogueStartingNodes[0];
    }

    protected virtual void Start()
    {
        if (_npcReaction == NPCSpeech.Idle) // if the NPC is in Idle then you can speak to them/ dialouge box shows up
        {
            _nametag.text = _name;
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
        if (_scene != "Speak" && _scene != "Speak1" && _scene != "Speak2" && _scene != "Speak3" && _scene != "Speak4" && _scene != "Speak5")
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
