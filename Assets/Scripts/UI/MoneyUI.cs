using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    //Text displayed on screen
    public TextMeshProUGUI moneyText;

    //Reference to the money system
    public MoneyManager moneyManager;

    //Reference to the Axe System
    public AxeManager axeManager;

    private void Update()
    {
        //Update the displayed money every frame
        moneyText.text = "Money: $" + moneyManager.money + "\nAxe: " + axeManager.currentAxeName;
    }
}
