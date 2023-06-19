using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
    private int sceneNumber;
    
    public void ChangeScreen()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void SelectScreen(int scene)
    {
        sceneNumber = scene;
    }
}
