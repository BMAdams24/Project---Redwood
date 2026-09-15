using UnityEngine;

public class AxeManager : MonoBehaviour
{
    //Current axe level
    public int axeLevel = 1;

    //Current axe damage
    public int axeDamage = 1;

    //Upgrade the players axe
    public void UpgradeAxe()
    {
        axeLevel++;
        axeDamage++;

        Debug.Log("Axe upgraded top level " +  axeLevel);
    }
}
