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

        foreach (Collider hit in hits)
        {
            LogCarry log = hit.GetComponent<LogCarry>();

            if (log != null)
            {
                heldLog = log;
                log.PickUp(holdPoint);
                return;
            }
        }
    }
}
