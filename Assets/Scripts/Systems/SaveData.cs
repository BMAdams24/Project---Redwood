using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    //Player money
    public int money;

    //Current equipped axe
    public string axeName;

    //Curerent Plot Status
    public bool ownsPlot;

    //Journal discoveries
    public string[] discoveredTrees;
    public string[] discoveredLocations;
    public string[] discoveredAxes;
}
