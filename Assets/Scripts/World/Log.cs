using Unity.VisualScripting;
using UnityEngine;

public class Log : MonoBehaviour
{
    //How much this log sells for
    public int value = 10;

    //Tyoe of tree this log came from
    public string treeName = "Unknown";

    public Material woodMaterial;

    private void Start()
    {
        if (woodMaterial != null)
        {
            GetComponent<Renderer>().material = woodMaterial;
        }
    }
}
