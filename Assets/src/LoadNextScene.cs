using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string MenuScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(MenuScene);
    }
}
