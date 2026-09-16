using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    //Tree Prefab to spawn
    public GameObject treePrefab;

    //Time before the tree regrows
    public float respawnTime = 10f;

    //Tracks whether a tree currently exists
    private bool treeExists = true;

    private void Update()
    {
        //Check if the tree has been removed
        if (transform.childCount == 0 && treeExists)
        {
            treeExists = false;

            Invoke(nameof(SpawnTree), respawnTime);
        }
    }

    private void SpawnTree()
    {
        GameObject newTree = Instantiate(treePrefab, transform.position, Quaternion.identity);

        newTree.transform.SetParent(transform);

        treeExists = true;
    }
}
