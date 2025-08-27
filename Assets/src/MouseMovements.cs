using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;
	public Rigidbody2D rb;
	public AudioClip sound;
	private Vector2 movement;
	private SpriteRenderer sr;
	public Sprite mousetopBot;
	public Sprite mouseLeftRight;


	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = mousetopBot;
	}

	void FixedUpdate()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		movement = new Vector2(moveX, moveY).normalized;
		rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
		if (movement.y < 0)
		{
			sr.sprite = mousetopBot;
			sr.flipY = false;
		}
		if (movement.y > 0)
		{
			sr.sprite = mousetopBot;
			sr.flipY = true;
		}
		if (movement.x < 0)
		{
			sr.sprite = mouseLeftRight;
			sr.flipX = false;
			sr.flipY = false;
		}
		if (movement.x > 0)
		{
			sr.sprite = mouseLeftRight;
			sr.flipX = true;
			sr.flipY = false;
		}
	}

	void OnMouseDown()
	{
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}
