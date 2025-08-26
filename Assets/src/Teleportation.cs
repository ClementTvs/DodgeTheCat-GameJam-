using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public Camera camera;
    public Transform camShelter;
    public Transform camCheese;
    public Transform mouseShelter;
	public Transform mouseCheese;
	public static bool isInShelter = false;

    private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Mouse"))
		{
			Rigidbody2D rigidBody = collider.GetComponent<Rigidbody2D>();

			if (GameManager.Instance.where == false)
			{
				isInShelter = true;
				GameManager.Instance.where = true;
				rigidBody.position = mouseShelter.position;
				camera.transform.position = camShelter.position;
			}
			else
			{
				isInShelter = false;
				GameManager.Instance.where = false;
				rigidBody.position = mouseCheese.position;
				camera.transform.position = camCheese.position;
			}
		}
	}
}
