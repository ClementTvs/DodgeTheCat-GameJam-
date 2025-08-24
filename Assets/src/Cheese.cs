using UnityEngine;

public class Cheese : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mouse"))
        {
            GameManager.Instance.addCheese();
            Destroy(gameObject);
        }
    }
}
