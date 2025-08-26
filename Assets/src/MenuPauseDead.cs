using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPauseDead : MonoBehaviour
{
    public GameObject pauseUICheese;
    public GameObject pauseUIShelter;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f)
        {
            if (Teleportation.isInShelter == false)
                pauseUICheese.SetActive(false);
            else
                pauseUIShelter.SetActive(false);
            Time.timeScale = 1f;
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
        }
    }

    public void goToMenu()
    {
        Time.timeScale = 1f;
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
        Time.timeScale = 1f;
    }
}
