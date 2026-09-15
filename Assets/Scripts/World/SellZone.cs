using UnityEngine;

public class SellZone : MonoBehaviour
{
    //Reference to the money manager
    private MoneyManager moneyManager;

    private void Start()
    {
        //Find the money manager in the scene
        moneyManager = FindAnyObjectByType<MoneyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the object entering is a log
        Log log = other.GetComponent<Log>();

        if (log != null)
        {
            //Give the player money
            moneyManager.AddMoney(log.value);

            //Remove the sold log
            Destroy(other.gameObject);

            Debug.Log("Sold " + log.treeName + " for $" + log.value);
        }
    }
}
