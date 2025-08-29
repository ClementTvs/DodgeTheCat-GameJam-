using UnityEngine;

public class Jar : MonoBehaviour
{
    static private int cheeseSaved = 0;
    public AudioClip sound;
    bool ending = true;
  
    private void Awake()
    {
        cheeseSaved = PlayerPrefs.GetInt("Jar cheese", 0);
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
		if (cheeseSaved >= 1000 && ending == true)
		{
			Debug.Log("You won !");
			ending = false;
		}
	}

    static public int getCheeseSaved()
    {
        return cheeseSaved;
    }
}
