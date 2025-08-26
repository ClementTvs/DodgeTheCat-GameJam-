using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public Camera camera;
    public Transform camShelter;
    public Transform camCheese;
    public Transform mouseShelter;
	public Transform mouseCheese;
	public static bool isInShelter = false;

	public AudioClip shelterMusic;
    public AudioClip cheeseMusic;
    private AudioSource audioSource;

	void Start()
	{
		isInShelter = false;
		if (GameManager.spawnInShelter == true)
		{
			Rigidbody2D rigidBody = GameObject.FindWithTag("Mouse").GetComponent<Rigidbody2D>();

			GameManager.spawnInShelter = false;
			isInShelter = true;
			GameManager.Instance.where = true;
			rigidBody.position = mouseShelter.position;
			camera.transform.position = camShelter.position;

			audioSource = GetComponent<AudioSource>();
			if (audioSource == null)
				audioSource = gameObject.AddComponent<AudioSource>();

			audioSource.loop = true;
			audioSource.clip = shelterMusic;
			audioSource.Play();
		}
		else
		{
			audioSource = GetComponent<AudioSource>();
			if (audioSource == null)
				audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.loop = true;
			audioSource.clip = cheeseMusic;
			audioSource.Play();
		}
	}

	private void PlayMusic(AudioClip newClip)
	{
    	if (audioSource.clip == newClip && audioSource.isPlaying)
        	return; // déjà la bonne musique, on ne relance pas

    	audioSource.Stop();
    	audioSource.clip = newClip;
    	audioSource.Play();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Mouse"))
		{
			Rigidbody2D rigidBody = collider.GetComponent<Rigidbody2D>();

			if (GameManager.Instance.where == false)
			{
				isInShelter = true;
				GameManager.Instance.where = true;
				rigidBody.position = mouseShelter.position;
				camera.transform.position = camShelter.position;

    			PlayMusic(shelterMusic);
			}
			else
			{
				isInShelter = false;
				GameManager.Instance.where = false;
				rigidBody.position = mouseCheese.position;
				camera.transform.position = camCheese.position;

    			PlayMusic(cheeseMusic);
			}
		}
	}
}
