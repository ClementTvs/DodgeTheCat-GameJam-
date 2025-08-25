using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        // Récupère les inputs du clavier (WASD ou flèches)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Déplacement
        Vector2 movement = new Vector2(moveX, moveY);
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}

