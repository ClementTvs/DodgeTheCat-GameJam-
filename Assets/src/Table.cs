using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject paper;
    public GameObject good100;
    public GameObject good300;
    public GameObject good500;
    public GameObject good750;
    public GameObject good1000;

    private void OnCollisionStay2D(Collision2D collider)
    {
        paper.SetActive(true);
        if (Jar.getCheeseSaved() >= 100)
            good100.SetActive(true);
        if (Jar.getCheeseSaved() >= 300)
            good300.SetActive(true);
        if (Jar.getCheeseSaved() >= 500)
            good500.SetActive(true);
        if (Jar.getCheeseSaved() >= 750)
            good750.SetActive(true);
        if (Jar.getCheeseSaved() >= 1000)
            good1000.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        paper.SetActive(false);
        good100.SetActive(false);
        good300.SetActive(false);
        good500.SetActive(false);
        good750.SetActive(false);
        good1000.SetActive(false);
    }
}
