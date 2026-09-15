using UnityEngine;

public class LogCarry : MonoBehaviour
{
    private bool isHeld = false;

    private Transform holdPoint;

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
    }

    private void Update()
    {
        if (isHeld && holdPoint != null)
        {
            transform.position = holdPoint.position;
        }
    }
}
