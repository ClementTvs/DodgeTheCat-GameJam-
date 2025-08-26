using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI cheeseNbrTextShelter;
    public TextMeshProUGUI cheeseNbrTextCheese;
    public TextMeshProUGUI cheeseNbrSavedText;
    public TextMeshProUGUI timerText;
    private float timeElapsed = 0f;

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

    }
}
