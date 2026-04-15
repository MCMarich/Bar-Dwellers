using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class DialogueNode : ScriptableObject
{
    public string npcName;
    //for when we have more entities to choose from
    public string[] _lines;
    public string[] _playerReplyOptions;
    public DialogueNode[] _npcReplies;
}
