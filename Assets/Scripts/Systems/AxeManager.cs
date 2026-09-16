using UnityEngine;

public class AxeManager : MonoBehaviour
{
    //Current axe name
    public string currentAxeName = "Rusty Axe";

    //Current damage value
    public int axeDamage = 1;

    //purchase a new Axe
    public void SetAxe(string axeName, int damage)
    {
        currentAxeName = axeName;
        axeDamage = damage;

        Debug.Log("New Axe Obtained: " + axeName);
    }
}
