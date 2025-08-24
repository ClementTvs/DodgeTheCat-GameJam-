using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int totalCheese = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void addCheese()
    {
        totalCheese++;
        Debug.Log("Cheese nbr " + totalCheese);
    }
}
