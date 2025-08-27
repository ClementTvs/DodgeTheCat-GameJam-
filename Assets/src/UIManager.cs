using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
	public TextMeshProUGUI cheeseNbrTextShelter;
	public TextMeshProUGUI cheeseNbrTextCheese;
	public TextMeshProUGUI cheeseNbrSavedText;
	public TextMeshProUGUI timerText;
	public TextMeshProUGUI x2Mult;
	public TextMeshProUGUI x3Mult;
	public TextMeshProUGUI x4Mult;
	private float timeElapsed = 0f;

	void Start()
	{
        x2Mult = GameObject.Find("x2Mult").GetComponent<TextMeshProUGUI>();
        x3Mult = GameObject.Find("x3Mult").GetComponent<TextMeshProUGUI>();
        x4Mult = GameObject.Find("x4Mult").GetComponent<TextMeshProUGUI>();

        x2Mult.gameObject.SetActive(false);
        x3Mult.gameObject.SetActive(false);
        x4Mult.gameObject.SetActive(false);
	}

	void Update()
	{
		int cheeseNbr = GameManager.Instance.getCheese();
		int cheeseSaved = Jar.getCheeseSaved();

		cheeseNbrTextCheese.text = cheeseNbr.ToString();
		cheeseNbrTextShelter.text = cheeseNbr.ToString();
		cheeseNbrSavedText.text = cheeseSaved.ToString();
		if (Teleportation.isInShelter == false)
		{
			timeElapsed += Time.deltaTime;

			int minutes = Mathf.FloorToInt(timeElapsed / 60);
			int secondes = Mathf.FloorToInt(timeElapsed % 60);

			timerText.text = string.Format("{0:00}:{1:00}", minutes, secondes);
		}
		else
			timeElapsed = 0f;
		if (Teleportation.isInShelter)
		{
			x2Mult.gameObject.SetActive(false);
       		x3Mult.gameObject.SetActive(false);
        	x4Mult.gameObject.SetActive(false);
		}
	}

	public void handleMult(int multToActivate)
	{
		x2Mult.gameObject.SetActive(false);
		x3Mult.gameObject.SetActive(false);
		x4Mult.gameObject.SetActive(false);

		switch (multToActivate)
		{
			case 2:
				x2Mult.gameObject.SetActive(true);
				break;
			case 3:
				x3Mult.gameObject.SetActive(true);
				break;
			case 4:
				x4Mult.gameObject.SetActive(true);
				break;
		}
	}
}
