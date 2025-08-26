using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public Transform shelterSpawn;
    public void GoToCheese()
    {
        GameManager.spawnInShelter = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToShelter()
    {
        GameManager.spawnInShelter = true;
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }
}
