using UnityEngine;

public class Jar : MonoBehaviour
{
    static private int cheeseSaved = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("a");
        cheeseSaved += GameManager.Instance.getCheese();
        GameManager.Instance.resetCheese();
    }

    static public int getCheeseSaved()
    {
        return cheeseSaved;
    }
}
