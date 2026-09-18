using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //References to game systems
    private MoneyManager moneyManager;
    private AxeManager axeManager;
    private JournalManager journalManager;
    private PlotManager plotManager;

    //Save file path
    private string savePath;

    private void Start()
    {
        moneyManager = FindAnyObjectByType<MoneyManager>();
        axeManager = FindAnyObjectByType<AxeManager>();
        journalManager = FindAnyObjectByType<JournalManager>();
        plotManager = FindAnyObjectByType<PlotManager>();

        savePath = Application.persistentDataPath + "/Save1.json";
    }

    private void Update()
    {
        //F5 saves
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }

        //F9 loads
        if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadGame();
        }
    }

    //Saves game data
    public void SaveGame()
    {
        SaveData data = new SaveData();

        //Save money
        data.money = moneyManager.money;

        //Save current axe
        data.axeName = axeManager.currentAxeName;

        //Save current Plot
        data.ownsPlot = plotManager.ownsPlot;

        //Save journal entries
        data.discoveredTrees = journalManager.discoveredTrees.ToArray();
        data.discoveredLocations = journalManager.discoveredLocations.ToArray();
        data.discoveredAxes = journalManager.discoveredAxes.ToArray();

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Game Saved!");
    }

    //Loads game data
    private void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("No Save Files Found.");
            return;
        }

        string json = File.ReadAllText(savePath);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        moneyManager.money = data.money;
        axeManager.LoadAxe(data.axeName);
        plotManager.ownsPlot = data.ownsPlot;

        //After plot ownership gets loaded, change the plot appearance
        FindAnyObjectByType<PlotPurchase>().UpdatePlotAppearance();

        journalManager.discoveredTrees.Clear();
        journalManager.discoveredLocations.Clear();
        journalManager.discoveredAxes.Clear();

        foreach (string tree in data.discoveredTrees)
        {
            journalManager.discoveredTrees.Add(tree);
        }

        foreach (string location in data.discoveredLocations)
        {
            journalManager.discoveredLocations.Add(location);
        }

        foreach (string axe in data.discoveredAxes)
        {
            journalManager.discoveredAxes.Add(axe);
        }

        Debug.Log("Game Loaded!");
    }
}
