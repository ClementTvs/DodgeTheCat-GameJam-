using UnityEngine;

public class Cheese : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
			Debug.Log("Olala je tape le fromage");
            Destroy(gameObject);
        }
    }
}
