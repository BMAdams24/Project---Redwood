using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    //Stores every discovered tree
    private HashSet<string> discoveredTrees = new HashSet<string>();

    //Total tree species currently in the game
    public int totalTreeTypes = 3;


    //Stores discovered locations
    private HashSet<string> discoveredLocations = new HashSet<string>();

    //Number of locations currently in game
    public int totallocations = 1;

    //Attempts to discover a tree
    public void DiscoverTree(string treeName)
    {
        //Returns true if this is a new discovery
        if (discoveredTrees.Add(treeName))
        {
            Debug.Log("NEW TREE DISCOVERED!\n" + treeName + "\nTrees Found: " + discoveredTrees.Count + "" + "/" + totalTreeTypes);
        }
    }

    //Returns total discovered trees
    public int GetDiscoveredTreeCount()
    {
        return discoveredTrees.Count;
    }

    //Records a newly discovered location
    public void DiscoverLocation(string locationName)
    {
        if (discoveredLocations.Add(locationName))
        {
            Debug.Log("NEW LOCATION DISCOVERED!\n" + locationName + "\nLocations Found: " + "/" + totallocations);
        }
    }
}
