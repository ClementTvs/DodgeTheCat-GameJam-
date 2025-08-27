using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public Transform shelterSpawn;
    public void GoToCheese()
    {
        GameManager.spawnInShelter = false;
        SceneManager.LoadScene("SampleScene");
        VolumeManager.Instance.audioSource.Stop();
    }

    public void GoToShelter()
    {
        GameManager.spawnInShelter = true;
        SceneManager.LoadScene("SampleScene");
        VolumeManager.Instance.audioSource.Stop();
    }

    public void Quit()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }
}
