using UnityEngine;

public class LogCarry : MonoBehaviour
{
    private bool isHeld = false;

    private Transform holdPoint;

    public bool isStored = false;

    public bool canBeStored = true;

    public Log logData;

    public StorageRack currentRack;

    public int rackSlot = -1;


    private void Start()
    {
        logData = GetComponent<Log>();
    }

    public void PickUp(Transform point)
    {
        isHeld = true;
        holdPoint = point;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public void Drop()
    {
        isHeld = false;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        canBeStored = true;
    }

    private void Update()
    {
        if (isHeld && holdPoint != null)
        {
            transform.position = holdPoint.position;
        }
    }

    public void ForceDrop()
    {
        isHeld = false;

        holdPoint = null;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}
