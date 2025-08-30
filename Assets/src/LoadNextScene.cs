using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string MenuScene;
    public GameObject cheeses;

    public void LoadScene()
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void EnableCheeses()
    {
        cheeses.SetActive(true);
    }
}
