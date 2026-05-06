using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

//using static UnityEditor.Progress;
using UnityEngine.Timeline;


public class DialogueController : MonoBehaviour
{
    [SerializeField] private UIController _dialogue;
    [SerializeField] private NPC _currentNPC;
    private DialogueNode _dialogueStartNode;
    public DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _waitingForPlayerResponse;
    public bool _appear = false;
    private float _ratingChange;

    private void OnEnable()
    {
        _currentNPC = GameObject.FindGameObjectWithTag("NPC").GetComponent<NPC>(); 
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
        _ratingChange = _currentNode._npcRating;
        Debug.Log("Rating change: " + _ratingChange);
        if (_ratingChange != 0.0f)
        {
            Player.Instance._rating = (Player.Instance._rating + _ratingChange) / 2;
            Player.Instance._rating = Mathf.Round(Player.Instance._rating * 10f) / 10f; // round to 1 decimal place
            if (Player.Instance._rating > 5.0f)
            {
                Player.Instance._rating = 5.0f;
            }
            else if (Player.Instance._rating < 0.0f)
            {
                Player.Instance._rating = 0.0f;
            }

            Player.Instance._ratingText.text = "Rating: " + Player.Instance._rating.ToString() + "/5";
        }
        if (_currentNode._isFinalNode == true)
        {
            _currentNPC._cutscene.Play();
        }
        Debug.Log("ended dialogue");
        _currentNPC._npcReaction = NPCSpeech.Idle;
        _currentNPC._dialoguebox.SetActive(false);
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
    }

}
