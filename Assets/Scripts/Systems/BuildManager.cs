using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject campfirePrefab;

    private PlotManager plotManager;

    private bool buildMode = false;

    private void Start()
    {
        plotManager = FindAnyObjectByType<PlotManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildMode = !buildMode;

            Debug.Log(buildMode ? "Build Mode On" : "Build Mode Off");
        }

        if (!buildMode)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            TryPlaceCampfire();
        }
    }

    private void TryPlaceCampfire()
    {
        if (!plotManager.ownsPlot)
        {
            Debug.Log("You Do Not Own This Plot");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Place the campfire
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(campfirePrefab, hit.point + new Vector3(0, 0.5f, 0), Quaternion.identity);

            buildMode = false;

            Debug.Log("Campfire Blueprint Placed!");
        }
    }
}
