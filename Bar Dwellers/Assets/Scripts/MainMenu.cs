using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        GameObject[] ddolObjects = GetDontDestroyOnLoadObjects();

        if (ddolObjects.Length > 0)
        {
            foreach (GameObject obj in ddolObjects)
            {
                Destroy(obj);
            }
        }
        SceneManager.LoadScene("Speak");
    }

    public void How2Play()
    {
        SceneManager.LoadScene("How2Play");
    }

    public void Continue()
    {
        SceneController.Instance.SendToSavedscene();
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
