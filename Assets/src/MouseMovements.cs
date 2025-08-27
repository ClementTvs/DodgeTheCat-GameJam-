using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;
	public Rigidbody2D rb;
	public AudioClip sound;
	private Vector2 movement;
	private SpriteRenderer sr;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		movement = new Vector2(moveX, moveY).normalized;
		rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
		if (movement.x < 0)
			sr.flipX = false;
		else if (movement.x > 0)
			sr.flipX = true;
	}

	void OnMouseDown()
	{
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}
