using UnityEngine;

public class Jar : MonoBehaviour
{
    static private int cheeseSaved = 0;
    bool ending = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        cheeseSaved += GameManager.Instance.getCheese();
        GameManager.Instance.resetCheese();
        if (cheeseSaved >= 1000 && ending == true)
        {
            Debug.Log("You won !");
            ending = false;
        }
    }

    static public int getCheeseSaved()
    {
        return cheeseSaved;
    }
}
