using UnityEngine;

public class Axe : MonoBehaviour
{
    public float range = 3f;
    public int damage = 1;

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;

        if (playerCamera == null )
        {
            Debug.LogError("No Main Camera Found!");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
                tree.TakeDamage(damage);
            }
        }
    }
}
