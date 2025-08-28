using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public static float speed = 5f;
	public Rigidbody2D rb;
	public AudioClip sound;
	private Vector2 movement;
	private SpriteRenderer sr;
	public Sprite mousetopBot;
	public Sprite mouseLeftRight;

	public Collider2D topBotCollider;
	public Collider2D leftRightCollider;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = mousetopBot;
		topBotCollider.enabled = true;
		leftRightCollider.enabled = false;
	}

	void Update()
	{
		if (Teleportation.isInShelter)
			speed = 5f;
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
			SwitchCollider(true);
		}
		if (movement.y > 0)
		{
			sr.sprite = mousetopBot;
			sr.flipY = true;
			SwitchCollider(true);
		}
		if (movement.x < 0)
		{
			sr.sprite = mouseLeftRight;
			sr.flipX = false;
			sr.flipY = false;
			SwitchCollider(false);
		}
		if (movement.x > 0)
		{
			sr.sprite = mouseLeftRight;
			sr.flipX = true;
			sr.flipY = false;
			SwitchCollider(false);
		}
	}

	void SwitchCollider(bool topBot)
	{
		topBotCollider.enabled = topBot;
		leftRightCollider.enabled = !topBot;
	}

	void OnMouseDown()
	{
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}
