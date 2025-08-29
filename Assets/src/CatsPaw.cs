using UnityEngine;
using System.Collections;

public class CatsPaw : MonoBehaviour
{
	public GameObject CatsPawGO;
	public GameObject shadow;
	private SpriteRenderer sr;
	private Color c;
    public GameObject deadUI;
	public AudioClip stomp;
	public Transform spawn;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		c = sr.color;
		c.a = 0.0f;
		sr.color = c;
	}

	void Update()
	{
		if (Teleportation.isInShelter == true)
			shadow.transform.position = spawn.position;
	}

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		c = sr.color;
		c.a = 0.0f;
		sr.color = c;
	}

	public IEnumerator CatsPawFalls1()
	{
		transform.position = shadow.transform.position;
		c.a = 1f;
		sr.color = c;

		if (Teleportation.isInShelter == false)
		{
			AudioSource.PlayClipAtPoint(stomp, transform.position, VolumeManager.volume * 3f);
		}
		yield return new WaitForSeconds(1f);
		if (Teleportation.isInShelter == true)
			shadow.transform.position = spawn.position;
		c.a = 0f;
		sr.color = c;
	}

	public IEnumerator CatsPawFalls2()
	{
		transform.position = shadow.transform.position;
		c.a = 1f;
		sr.color = c;
		if (Teleportation.isInShelter == false)
		{
			AudioSource.PlayClipAtPoint(stomp, transform.position, VolumeManager.volume * 3f);
		}
		yield return new WaitForSeconds(1f);

		c.a = 0f;
		sr.color = c;
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.CompareTag("Mouse") && c.a == 1f)
		{
			GameManager.Instance.resetCheese();
			deadUI.SetActive(true);
			Debug.Log("Game OVER");
			Time.timeScale = 0f;
			MusicManager.Instance.lowerVolumeMusic();
		}
	}
}
