using UnityEngine;

public class BigCheese : MonoBehaviour
{
    public AudioClip pop;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            if (VolumeManager.volume >= 0.2f)
                AudioSource.PlayClipAtPoint(pop, transform.position, VolumeManager.volume + 0.4f);
            else if (VolumeManager.volume >= 0.1f)
                AudioSource.PlayClipAtPoint(pop, transform.position, VolumeManager.volume + 0.3f);
            else
                AudioSource.PlayClipAtPoint(pop, transform.position, VolumeManager.volume);
            GameManager.Instance.addCheese(10, false);
            Destroy(gameObject);
        }
    }
}
