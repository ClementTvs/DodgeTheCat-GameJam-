using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
	public GameObject Target;
	public CatsPaw catsPaw;

	private SpriteRenderer sr;
	private Color c;
	private bool canFollow = true;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		c = sr.color;
		c.a = 0.75f;
		sr.color = c;
		StartCoroutine(CallCatsPawRoutine());
	}

	void Update()
	{
		if (canFollow && !Teleportation.isInShelter)
			transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, 3 * Time.deltaTime);
	}

	IEnumerator CallCatsPawRoutine()
	{
		while (true)
		{
			canFollow = false;
			c.a = 0f;
			sr.color = c;
			yield return StartCoroutine(catsPaw.CatsPawFalls());
			canFollow = true;
			c.a = 0.75f;
			sr.color = c;
			yield return new WaitForSeconds(2f);
		}
	}
}
