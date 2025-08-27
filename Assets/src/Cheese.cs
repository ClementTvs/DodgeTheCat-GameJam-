using UnityEngine;

public class Cheese : MonoBehaviour
{
    public AudioClip pop;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            AudioSource.PlayClipAtPoint(pop, transform.position);
            GameManager.Instance.addCheese();
            Destroy(gameObject);
        }
    }
}
