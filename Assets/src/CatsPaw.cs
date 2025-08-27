using UnityEngine;
using System.Collections;

public class CatsPaw : MonoBehaviour
{
	public GameObject CatsPawGO;
	public GameObject shadow;
	private SpriteRenderer sr;
	private Color c;
    public GameObject deadUI;


	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		c = sr.color;
		c.a = 0.0f;
		sr.color = c;
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
		yield return new WaitForSeconds(1f);
		c.a = 0f;
		sr.color = c;
	}

	public IEnumerator CatsPawFalls2()
	{
		transform.position = shadow.transform.position;
		c.a = 1f;
		sr.color = c;
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
