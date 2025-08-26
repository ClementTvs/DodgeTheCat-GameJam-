using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI cheeseNbrTextShelter;
    public TextMeshProUGUI cheeseNbrTextCheese;
    public TextMeshProUGUI cheeseNbrSavedText;

    void Update()
    {
        int cheeseNbr = GameManager.Instance.getCheese();
        int cheeseSaved = Jar.getCheeseSaved();

        cheeseNbrTextCheese.text = cheeseNbr.ToString();
        cheeseNbrTextShelter.text = cheeseNbr.ToString();
        cheeseNbrSavedText.text = cheeseSaved.ToString();
    }
}
