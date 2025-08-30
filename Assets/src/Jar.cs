using UnityEngine;
using UnityEngine.SceneManagement;

public class Jar : MonoBehaviour
{
    static private int cheeseSaved = 0;
    public AudioClip sound;
    static int ending = 1;

    private void Awake()
    {
        cheeseSaved = PlayerPrefs.GetInt("Jar cheese", 0);
        ending = PlayerPrefs.GetInt("ending", 1);
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
	{
        if (GameManager.Instance.getCheese() > 0)
        {
            AudioSource.PlayClipAtPoint(sound, transform.position, VolumeManager.volume * 3f);
        }
		cheeseSaved += GameManager.Instance.getCheese();
		PlayerPrefs.SetInt("Jar cheese", cheeseSaved);
		PlayerPrefs.Save();
		GameManager.Instance.resetCheese();
        if (cheeseSaved >= 1000 && ending == 1)
        {
            ending = 0;
            PlayerPrefs.SetInt("ending", 0);
		    PlayerPrefs.Save();
            SceneManager.LoadScene("FinalCutscene");

		}
	}

    static public int getCheeseSaved()
    {
        return cheeseSaved;
    }
}
