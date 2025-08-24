using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject Cheese;
	public Vector2 spawnMin = new Vector2(-8f, -4.5f);
	public Vector2 spawnMax = new Vector2(8f, 4.5f);
	void Start()
	{
		InvokeRepeating("SpawnRandom", 0.1f, 1f);
	}

	void SpawnRandom()
	{
		float x = Random.Range(spawnMin.x, spawnMax.x);
		float y = Random.Range(spawnMin.y, spawnMax.y);
		Vector2 spawnPos = new Vector2(x, y);

		Instantiate(Cheese, spawnPos, Quaternion.identity);
	}
}
