using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int totalCheese = 0;
    public bool where = false; 
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
        totalCheese++;
        Debug.Log("Cheese nbr " + totalCheese);
    }

    public int getCheese()
    {
        return totalCheese;
    }
}
