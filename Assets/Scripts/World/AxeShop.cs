using UnityEngine;

public class AxeShop : MonoBehaviour
{
    //References to managers
    private MoneyManager moneyManager;
    private AxeManager axeManager;

    private void Start()
    {
        //Find managers in the scene
        moneyManager = FindAnyObjectByType<MoneyManager>();
        axeManager = FindAnyObjectByType<AxeManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        //Only allow the player to interact
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BuyNextAxe();
            }
        }
    }

    //Purchases the next axe tier
    private void BuyNextAxe()
    {
        if (axeManager.currentAxeName == "Rusty Axe" && moneyManager.money >= 50)
        {
            moneyManager.money -= 50;

            axeManager.SetAxe("Traveler's Axe", 2);
        }

        else if (axeManager.currentAxeName == "Traveler's Axe" && moneyManager.money >= 150)
        {
            moneyManager.money -= 150;

            axeManager.SetAxe("Steel Axe", 3);
        }

        else if (axeManager.currentAxeName == "Steel Axe" && moneyManager.money >= 400)
        {
            moneyManager.money -= 400;

            axeManager.SetAxe("Forester's Axe", 5);
        }
    }
}
