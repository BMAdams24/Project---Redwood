using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    //Stores every discovered tree
    public HashSet<string> discoveredTrees = new HashSet<string>();

    //Total tree species currently in the game
    public int totalTreeTypes = 3;


    //Stores discovered locations
    public HashSet<string> discoveredLocations = new HashSet<string>();

    //Number of locations currently in game
    public int totallocations = 1;


    //Stores discovered axes
    public HashSet<string> discoveredAxes = new HashSet<string>();

    //Number of axe types currently in game
    public int totalAxes = 4;


    //Attempts to discover a tree
    public void DiscoverTree(string treeName)
    {
        //Returns true if this is a new discovery
        if (discoveredTrees.Add(treeName))
        {
            Debug.Log("NEW TREE DISCOVERED!\n" + treeName + "\nTrees Found: " + discoveredTrees.Count + "/" + totalTreeTypes);
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
            Debug.Log("NEW LOCATION DISCOVERED!\n" + locationName + "\nLocations Found: " + discoveredLocations.Count + "/" + totallocations);
        }
    }

    //Records a discovered axe
    public void DiscovereAxe(string axeName)
    {
        if (discoveredAxes.Add(axeName))
        {
            Debug.Log("NEW AXE DISCOVERED!\n" + axeName + "\nAxes Found: " + discoveredAxes.Count + "/" + totalAxes);
        }


    }


}