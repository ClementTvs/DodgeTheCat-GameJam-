using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject Cheese;
	public GameObject BigCheese;
	public GameObject SpeedCheese;
	public GameObject MultCheese;
	public GameObject LastCheese;
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
			float rand = Random.value;
			if (rand > 0.90f && Jar.getCheeseSaved() >= 100)
				Instantiate(BigCheese, spawnPos, Quaternion.identity);
			else if (rand > 0.87f && Jar.getCheeseSaved() >= 300)
				Instantiate(SpeedCheese, spawnPos, Quaternion.identity);
			else if (rand > 0.85 && Jar.getCheeseSaved() >= 500)
				Instantiate(MultCheese, spawnPos, Quaternion.identity);
			else if (rand > 0.80 && Jar.getCheeseSaved() >= 750)
				Instantiate(LastCheese, spawnPos, Quaternion.identity);
			else
				Instantiate(Cheese, spawnPos, Quaternion.identity);
		}
	}

}
