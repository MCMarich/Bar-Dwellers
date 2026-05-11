using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    public void Reset()
    {
        GameObject[] ddolObjects = GetDontDestroyOnLoadObjects();
        if (ddolObjects.Length > 0)
        {
            foreach (GameObject obj in ddolObjects)
            {
                Destroy(obj);
            }
        }
        SceneManager.LoadScene("MainMenu");
        
    }
    private GameObject[] GetDontDestroyOnLoadObjects()
    {
        GameObject temp = new GameObject();
        DontDestroyOnLoad(temp);
        Scene ddolScene = temp.scene;
        Destroy(temp);
        
        return ddolScene.GetRootGameObjects();
    }
}
