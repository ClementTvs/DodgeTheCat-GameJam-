using UnityEngine;

public class MultCheese : MonoBehaviour
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
			GameManager.Instance.ActivateTempMultiplier();
            GameManager.Instance.addCheese(1, false);
            Destroy(gameObject);
        }
    }
}
