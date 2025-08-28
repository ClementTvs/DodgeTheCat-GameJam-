using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private int totalCheese = 0;
	public bool where = false;
	static public bool spawnInShelter;
	private float tempMultiplier = 1f;
    private Coroutine tempMultCoroutine;

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

    public void addCheese(int amount, bool lastCheese)
    {
        UIManager ui = Object.FindFirstObjectByType<UIManager>();
        int baseMult = 1;
		int finalMult = 1;

        if (Follow.timeElapsed >= 60f && Follow.timeElapsed < 120)
		{
			baseMult = 2;
		}
		else if (Follow.timeElapsed >= 120 && Follow.timeElapsed < 180)
		{
			baseMult = 3;
		}
		else if (Follow.timeElapsed >= 180)
		{
			baseMult = 4;
		}
		if (!Teleportation.isInShelter)
			finalMult = Mathf.RoundToInt(baseMult * tempMultiplier);
		else
			finalMult = baseMult;
        totalCheese += amount * finalMult;
        ui.handleMult(baseMult);
        if (lastCheese)
            totalCheese = Mathf.RoundToInt(totalCheese * 1.5f);
    }

    public void ActivateTempMultiplier()
    {
        if (tempMultCoroutine != null)
        {
            StopCoroutine(tempMultCoroutine);
        }
        
        tempMultCoroutine = StartCoroutine(TempMultiplierCoroutine());
    }

    private IEnumerator TempMultiplierCoroutine()
    {
        tempMultiplier = 2f;
        yield return new WaitForSeconds(20f);
        tempMultiplier = 1f;
        tempMultCoroutine = null;
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
