using UnityEngine;
using UnityEngine.SceneManagement;

public class H2P : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
