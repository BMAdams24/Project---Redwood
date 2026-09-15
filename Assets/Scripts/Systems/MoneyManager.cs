using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    //Current amount of money the player owns
    public int money = 0;

    //Adds money whenever something is sold
    public void AddMoney(int amount)
    {
        money += amount;

        Debug.Log("Money : $" + money);
    }
}
