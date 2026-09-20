using System;
using UnityEngine;

[Serializable]
public class JournalEntry
{
    //Entry Title
    public string title;

    //Main description
    public string description;

    //Where it can be found
    public string location;

    //Base value
    public int value;

    //Durability
    public int durability;

    //Axe damage
    public int damage;

    //Axe cost
    public int cost;
}
