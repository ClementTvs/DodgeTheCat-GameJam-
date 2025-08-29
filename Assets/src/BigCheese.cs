using UnityEngine;

public class BigCheese : MonoBehaviour
{
    public AudioClip pop;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            AudioSource.PlayClipAtPoint(pop, transform.position, VolumeManager.volume * 3f);
            GameManager.Instance.addCheese(10, false);
            Destroy(gameObject);
        }
    }
}
