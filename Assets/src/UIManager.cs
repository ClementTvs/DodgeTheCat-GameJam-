using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI cheeseNbrTextCheese;
    public TextMeshProUGUI cheeseNbrTextShelter;

    void Update()
    {
        if (cheeseNbrTextCheese != null)
        {
            int cheeseNbr = GameManager.Instance.getCheese();
            cheeseNbrTextCheese.text = cheeseNbr.ToString();
            cheeseNbrTextShelter.text = cheeseNbr.ToString();
        }
    }
}
