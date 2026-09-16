using UnityEngine;

public class TreeHealth : MonoBehaviour
{

    //Tree information
    public string treeName = "Pine";
    public int maxHealth = 3;
    public int logValue = 10;

    //Log prefab spawned when destroyed
    public GameObject logPrefab;

    private int currentHealth;

    private JournalManager journalManager;

    private void Start()
    {
        currentHealth = maxHealth;

        //Find the journal manager
        journalManager = FindAnyObjectByType<JournalManager>();
    }

    //Damages the tree
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(treeName + " Health: " + currentHealth);

        //Record this tree species
        journalManager.DiscoverTree(treeName);

        //Check if tree was destroyed
        if (currentHealth <= 0)
        {
            SpawnLog();

            Destroy(gameObject);
        }
    }

    //Creates a log when tree dies
    private void SpawnLog()
    {
        GameObject newLog = Instantiate(logPrefab, transform.position, Quaternion.identity);

        Log log = newLog.GetComponent<Log>();

        if (log != null )
        {
            log.value = logValue;
            log.treeName = treeName;
        }
    }
}
