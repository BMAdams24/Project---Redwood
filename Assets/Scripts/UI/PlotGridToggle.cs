using UnityEngine;

public class PlotGridToggle : MonoBehaviour
{
    public GameObject plotGrid;

    private PlotManager plotManager;

    private bool gridVisible = false;


    private void Start()
    {
        plotManager = FindAnyObjectByType<PlotManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!plotManager.ownsPlot)
            {
                Debug.Log("You do not own a plot yet.");
            }

            else
            {
                ToggleGrid();
            }
        }
    }

    private void ToggleGrid()
    {
        gridVisible = !gridVisible;

        plotGrid.SetActive(gridVisible);
    }
}
