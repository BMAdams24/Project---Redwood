using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    private JournalManager journalManager;

    private void Start()
    {
        //Find the journal system
        journalManager = FindAnyObjectByType<JournalManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check for player
        if (other.CompareTag("Player"))
        {
            LocationDiscoverer location = GetComponent<LocationDiscoverer>();

            if (location != null)
            {
                journalManager.DiscoverLocation(location.locationName);
            }
        }
    }
}
