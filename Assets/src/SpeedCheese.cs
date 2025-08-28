using UnityEngine;
using System.Collections;

public class SpeedCheese : MonoBehaviour
{
    public AudioClip pop;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            StartCoroutine(SpeedBoostAndDestroy());
            AudioSource.PlayClipAtPoint(pop, transform.position);
            GameManager.Instance.addCheese(1, false);
        }
    }

    private IEnumerator SpeedBoostAndDestroy()
    {
        float originalSpeed = 5f;
        PlayerMovement.speed = originalSpeed + 5f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(10f);
        PlayerMovement.speed = originalSpeed;
        Destroy(gameObject);
    }
}
