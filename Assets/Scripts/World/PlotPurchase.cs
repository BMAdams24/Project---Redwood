using UnityEngine;

public class PlotPurchase : MonoBehaviour
{
    //Cost of the plot
    public int plotCost = 250;

    private MoneyManager moneyManager;
    private PlotManager plotManager;

    //Materials for plot ownership
    public Material unownedMaterial;
    public Material ownedMaterial;

    //Renderer for the plot
    public Renderer plotRenderer;

    private void Start()
    {
        //Find managers
        moneyManager = FindAnyObjectByType<MoneyManager>();
        plotManager = FindAnyObjectByType<PlotManager>();

        //Update visual state when game starts
        UpdatePlotAppearance();
    }

    private void OnTriggerStay(Collider other)
    {
        //Check for player
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BuyPlot();
            }
        }
    }

    private void BuyPlot()
    {
        //Prevent buying twice
        if (plotManager.ownsPlot)
        {
            Debug.Log("You already own this plot");
            return;
        }

        if (moneyManager.money >= plotCost)
        {
            moneyManager.money -= plotCost;

            plotManager.ownsPlot = true;
            UpdatePlotAppearance();

            Debug.Log("Plot Purchased");
        }
    }

    //Updates the plot appearance
    public void UpdatePlotAppearance()
    {
        if (plotManager.ownsPlot)
        {
            plotRenderer.material = ownedMaterial;
        }

        else
        {
            plotRenderer.material = unownedMaterial;
        }
    }
}
