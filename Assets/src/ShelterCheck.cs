using UnityEngine;

public class ShelterCheck : MonoBehaviour
{
    public GameObject carpet;
    public GameObject armchair;
    public GameObject flowers;
    public GameObject tv;
    public GameObject wife;
    void Update()
    {
        if (Jar.getCheeseSaved() >= 100)
            carpet.SetActive(true);
        if (Jar.getCheeseSaved() >= 300)
            armchair.SetActive(true);
        if (Jar.getCheeseSaved() >= 500)
            flowers.SetActive(true);
        if (Jar.getCheeseSaved() >= 750)
            tv.SetActive(true);
        if (Jar.getCheeseSaved() >= 1000)
            wife.SetActive(true);
    }
}
