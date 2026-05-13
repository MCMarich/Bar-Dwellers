using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class DialogueNode : ScriptableObject
{
    public string npcName;
    public float _npcRating;
    public bool _isFinalNode;
    public bool _isDead;
    public bool _win;
    //for when we have more entities to choose from
    public string[] _lines;
    public string[] _playerReplyOptions;
    public DialogueNode[] _npcReplies;
}
