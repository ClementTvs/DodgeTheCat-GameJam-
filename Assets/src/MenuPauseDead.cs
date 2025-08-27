using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    public GameObject pauseUICheese;
    public GameObject pauseUIShelter;
    public GameObject deadUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f)
        {
            if (Teleportation.isInShelter == false)
                pauseUICheese.SetActive(false);
            else
                pauseUIShelter.SetActive(false);
            Time.timeScale = 1f;
            MusicManager.Instance.getBackVolumeMusic();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Teleportation.isInShelter == false)
            {
                pauseUICheese.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (Teleportation.isInShelter == true)
            {
                pauseUIShelter.SetActive(true);
                Time.timeScale = 0f;
            }
            MusicManager.Instance.lowerVolumeMusic();
        }
    }

    public void goToMenu()
    {
        Time.timeScale = 1f;
        MusicManager.Instance.getBackVolumeMusic();
        if (Teleportation.isInShelter == false)
            pauseUICheese.SetActive(false);
        else
            pauseUIShelter.SetActive(false);
        SceneManager.LoadScene("MenuScene");
    }

    public void resume()
    {
        if (Teleportation.isInShelter == false)
            pauseUICheese.SetActive(false);
        else
            pauseUIShelter.SetActive(false);
        MusicManager.Instance.getBackVolumeMusic();
        Time.timeScale = 1f;
    }

    public void shelter()
    {
        Time.timeScale = 1f;
        deadUI.SetActive(false);
        Teleportation.Instance.shelter();
        MusicManager.Instance.PlayShelterMusic();
    }
}
