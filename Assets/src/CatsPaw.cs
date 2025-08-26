using UnityEngine;
using System.Collections;

public class CatsPaw : MonoBehaviour
{
	public GameObject CatsPawGO;
	public GameObject shadow;
	private SpriteRenderer sr;
	private Color c;

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
	void Update()
	{

	}
	public IEnumerator CatsPawFalls()
	{
		transform.position = shadow.transform.position;
		c.a = 1f;
		sr.color = c;
		yield return new WaitForSeconds(1f);
		c.a = 0f;
		sr.color = c;
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.CompareTag("Mouse") && c.a == 1f)
		{
			GameManager.Instance.resetCheese();
			Debug.Log("Game OVER");
        }
    }
}
