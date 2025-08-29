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
            if (VolumeManager.volume >= 0.2f)
                AudioSource.PlayClipAtPoint(sound, transform.position, VolumeManager.volume + 0.4f);
            else if (VolumeManager.volume >= 0.1f)
                AudioSource.PlayClipAtPoint(sound, transform.position, VolumeManager.volume + 0.3f);
            else
                AudioSource.PlayClipAtPoint(sound, transform.position, VolumeManager.volume);
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
