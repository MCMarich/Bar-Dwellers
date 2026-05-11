using UnityEngine;

public class SceneProxy : MonoBehaviour
{    
    public void GoToStirring() => SceneController.Instance.SendToStirring();
    
    public void GoToMixingEl() => SceneController.Instance.SendToMixingEl();
    
    public void GoToMixingMoscow() => SceneController.Instance.SendToMixingMoscow();
    
    public void GoToMixingMojito() => SceneController.Instance.SendToMixingMojito();
    
    public void GoToMixingScarlet() => SceneController.Instance.SendToMixingScarlet();
    
    public void GoToYouDied() => SceneController.Instance.SendToYouDied();

    public void GoToMainMenu() => SceneController.Instance.SendToMainMenu();

    public void GoToSpeak() => SceneController.Instance.SendToSpeak();

//    public void MarkAndReturn() 
//    {
//        SceneController.Instance.MarkCurrentSpeak();
//    }

//    public void BackToSpeak()
//    {
//        SceneController.Instance.ReturnSpeak();
//    }
}