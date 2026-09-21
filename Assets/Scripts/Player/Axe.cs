using UnityEngine;

public class Axe : MonoBehaviour
{
    public float range = 3f;
    private AxeManager axeManager;

    private Camera playerCamera;

    private LogCarry heldLog;

    public Transform holdPoint;

    private void Start()
    {
        playerCamera = Camera.main;

        //Find axe manager in the scene
        axeManager = FindFirstObjectByType<AxeManager>();

        if (playerCamera == null )
        {
            Debug.LogError("No Main Camera Found!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldLog == null)
            {
                TryPickup();
            }

            else
            {
                heldLog.Drop();
                heldLog = null;
            }

            Chop();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TryRetrieve();
        }
    }

    private void Chop()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);

        foreach (Collider hit in hits)
        {
            TreeHealth tree = hit.GetComponent<TreeHealth>();

            if (tree != null)
            {
                Debug.Log("Tree Found!");
                tree.TakeDamage(axeManager.axeDamage);
            }
        }
    }
    private void TryPickup()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in hits)
        {
            LogCarry log =
                collider.GetComponent<LogCarry>();

            if (log == null)
            {
                continue;
            }

            if (log.isStored)
            {
                continue;
            }

            heldLog = log;

            log.PickUp(holdPoint);

            return;
        }
    }

    public void ClearHeldLog(Log log)
    {
        LogCarry carry = log.GetComponent<LogCarry>();

        if (heldLog ==  carry)
        {
            Debug.Log("Axe forgot held log");
            heldLog = null;
        }
    }

    private void TryRetrieve()
    {
        StorageRack rack = FindAnyObjectByType<StorageRack>();

        if (rack == null)
        {
            return;
        }

        Log log = rack.GetStoredLog();

        if (log == null)
        {
            return;
        }

        LogCarry carry = log.GetComponent<LogCarry>();

        if (carry == null)
        {
            return;
        }

        rack.RetrieveLog(log);

        heldLog = carry;

        carry.PickUp(holdPoint);
    }
}
