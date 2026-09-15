using UnityEngine;

public class AxeShop : MonoBehaviour
{
    //Cost of the first upgrade
    public int upgradeCost = 50;

    private MoneyManager moneyManager;
    private AxeManager AxeManager;

    private void Start()
    {
        //Find managers in the scene
        moneyManager = FindAnyObjectByType<MoneyManager>();
        AxeManager = FindAnyObjectByType<AxeManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        //Only allow the player to interact
        if (other.CompareTag("Player"))
        {
            //Press E to buy upgrade
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (moneyManager.money >= upgradeCost)
                {
                    moneyManager.money -= upgradeCost;

                    AxeManager.UpgradeAxe();

                    Debug.Log("Bought Axe Upgrade!");
                }

                else
                {
                    Debug.Log("Not Enough Money!");
                }
            }
        }
    }
}
