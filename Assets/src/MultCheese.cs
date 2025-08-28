using UnityEngine;

public class MultCheese : MonoBehaviour
{
    public AudioClip pop;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            AudioSource.PlayClipAtPoint(pop, transform.position);
			GameManager.Instance.ActivateTempMultiplier();
            GameManager.Instance.addCheese(1, false);
            Destroy(gameObject);
        }
    }
}
