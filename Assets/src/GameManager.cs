using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private int totalCheese = 0;
	public bool where = false;
	static public bool spawnInShelter;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(Instance);
	}

	public void addCheese()
	{
		UIManager ui = Object.FindFirstObjectByType<UIManager>();

		if (Follow.timeElapsed >= 60f && Follow.timeElapsed < 120)
		{
			totalCheese += 2;
			ui.handleMult(2);
		}
		else if (Follow.timeElapsed >= 120 && Follow.timeElapsed < 180)
		{
			totalCheese += 3;
			ui.handleMult(3);
		}
		else if (Follow.timeElapsed >= 180)
		{
			totalCheese += 4;
			ui.handleMult(4);
		}
		else
			totalCheese++;
		Debug.Log("Cheese nbr " + totalCheese);
	}

	public int getCheese()
	{
		return totalCheese;
	}

	public void resetCheese()
	{
		totalCheese = 0;
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("Jar cheese", Jar.getCheeseSaved());
		PlayerPrefs.Save();
	}
}
