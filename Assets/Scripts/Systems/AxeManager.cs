using UnityEngine;

public class AxeManager : MonoBehaviour
{
    //Current axe name
    public string currentAxeName = "Rusty Axe";

    //Current damage value
    public int axeDamage = 1;

    //Reference to journal manager
    private JournalManager journalManager;


    private void Start()
    {
        //Find journal manager
        journalManager = FindAnyObjectByType<JournalManager>();

        //Discover starter axe
        journalManager.DiscovereAxe(currentAxeName);
    }


    //purchase a new Axe
    public void SetAxe(string axeName, int damage)
    {

        currentAxeName = axeName;
        axeDamage = damage;

        journalManager.DiscovereAxe(axeName);

        Debug.Log("New Axe Obtained: " + axeName);
    }

    //Sets the players axe by name
    public void LoadAxe(string axeName)
    {
        switch (axeName)
        {
            case "Rusty Axe":
                currentAxeName = "Rusty Axe";
                axeDamage = 1;

                break;

            case "Traveler's Axe":
                currentAxeName = "Traveler's Axe";
                axeDamage = 2;

                break;

            case "Steel Axe":
                currentAxeName = "Steel Axe";
                axeDamage = 3;

                break;

            case "Forester's Axe":
                currentAxeName = "Forester's Axe";
                axeDamage = 5;

                break;
        }
    }
}
