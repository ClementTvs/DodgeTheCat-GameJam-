using UnityEngine;

public class LastCheese : MonoBehaviour
{
    public AudioClip pop;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            AudioSource.PlayClipAtPoint(pop, transform.position, VolumeManager.volume * 3f);
            GameManager.Instance.addCheese(1, true);
            Destroy(gameObject);
        }
    }
}
