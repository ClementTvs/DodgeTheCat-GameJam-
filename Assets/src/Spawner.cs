using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject Cheese;
	public static Vector2 spawnMin = new Vector2(-8f, -4.5f);
	public static Vector2 spawnMax = new Vector2(8f, 4.5f);
	void Start()
	{
		InvokeRepeating("SpawnRandomCheese", 0.1f, 1f);
	}

	void Update()
	{
		if (Teleportation.isInShelter)
		{
			GameObject[] cheeses = GameObject.FindGameObjectsWithTag("Cheese");
			foreach (GameObject c in cheeses)
				Destroy(c);
		}
	}

	void SpawnRandomCheese()
	{
		float x = Random.Range(spawnMin.x, spawnMax.x);
		float y = Random.Range(spawnMin.y, spawnMax.y);
		Vector2 spawnPos = new Vector2(x, y);
		if (!Teleportation.isInShelter)
		{
			GameObject cheese = Instantiate(Cheese, spawnPos, Quaternion.identity);
		}
	}

}
