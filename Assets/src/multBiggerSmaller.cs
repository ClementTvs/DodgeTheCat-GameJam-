using UnityEngine;
using TMPro;
public class multBiggerSmaller : MonoBehaviour
{
    public float speed = 0.3f;     // vitesse de la pulsation
    public float minScale = 0.8f; // taille minimale
    public float maxScale = 1.1f; // taille maximale

    void Update()
    {
        // t va osciller entre 0 et 1
        float t = Mathf.PingPong(Time.time * speed, 1f);

        // interpole entre minScale et maxScale
        float scale = Mathf.Lerp(minScale, maxScale, t);

        // applique la nouvelle taille
        transform.localScale = new Vector3(scale, scale, 1f);
    }

}
