using UnityEngine;

public class SetSpeak : MonoBehaviour
{
    private void Start() {
        SceneController.Instance.MarkCurrentSpeak();
    }
}
