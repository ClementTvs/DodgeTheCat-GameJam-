using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Récupère les inputs du clavier (WASD ou flèches)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Déplacement
        Vector2 movement = new Vector2(moveX, moveY) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}

