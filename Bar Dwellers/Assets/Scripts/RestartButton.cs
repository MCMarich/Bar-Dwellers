using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    public void Reset()
    {
        Player.Instance._inventoryString.Clear();
        Player.Instance._rating = 0f;
        SceneManager.LoadScene("Speak");
        
    }
}
