using UnityEngine;
using System.Collections;

public class SpeedCheese : MonoBehaviour
{
    public AudioClip electrical;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            StartCoroutine(SpeedBoostAndDestroy());
            AudioSource.PlayClipAtPoint(electrical, transform.position, VolumeManager.volume * 3f);
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
