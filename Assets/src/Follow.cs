using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
	public GameObject Target;
	public CatsPaw catsPaw;

	private SpriteRenderer sr;
	private Color c;
	private bool canFollow = true;
	public Transform spawn;

    public static float timeElapsed = 0f;

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
		float minSpeed = 2f;
		float maxSpeed = 4.5f;
		float t = Mathf.Clamp01(timeElapsed / 180f);
		float speed = Mathf.Lerp(minSpeed, maxSpeed, t);

		if (canFollow && !Teleportation.isInShelter)
			transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
		if (!Teleportation.isInShelter)
			timeElapsed += Time.deltaTime;
		else
			timeElapsed = 0f;
		if (Teleportation.isInShelter == true)
			catsPaw.transform.position = spawn.position;
	}

	IEnumerator CallCatsPawRoutine()
	{
		while (true)
		{
			float minWait = 1.5f;
			float maxWait = 2f;
			float t = Mathf.Clamp01(timeElapsed / 180f);
			float timeToWait = Mathf.Lerp(maxWait, minWait, t);

			canFollow = false;
			c.a = 0f;
			sr.color = c;
			yield return StartCoroutine(catsPaw.CatsPawFalls1());
			canFollow = true;
			c.a = 0.75f;
			sr.color = c;
			yield return new WaitForSeconds(timeToWait);
		}
	}
}
