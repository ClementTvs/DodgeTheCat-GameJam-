using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI cheeseNbrText;

    void Update()
    {
        if (cheeseNbrText != null)
        {
            int cheeseNbr = GameManager.Instance.getCheese();
            cheeseNbrText.text = cheeseNbr.ToString();
        }
    }
}
