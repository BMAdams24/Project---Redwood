using TMPro;
using UnityEngine;
using System.Text;

public class JournalUI : MonoBehaviour
{
    //Journal panel object
    public GameObject journalPanel;

    //Text displayed inside the journal
    public TextMeshProUGUI leftPageText;
    public TextMeshProUGUI rightPageText;

    //reference to journal system
    public JournalManager journalManager;

    private bool isOpen = false;

    //current journal page
    private int currentPage = 0;

    private string[] pageNames = { "Contents", "Trees", "Locations", "Axes" };

    //Currently selected
    private string selectedTree = "";
    private string selectedAxe = "";
    private string selectedLocation = "";

    private void Update()
    {
        //Press J to open/close journal
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleJournal();
        }

        if (isOpen)
        {
            //If Oak has been discovered and 1 is pressed, show the oak info on the right page
            if (Input.GetKeyDown(KeyCode.Alpha1) && journalManager.discoveredTrees.Contains("Oak"))
            {
                selectedTree = "Oak";
                UpdateJournalText();
            }

            //Same as oak but for birch
            if (Input.GetKeyDown(KeyCode.Alpha2) && journalManager.discoveredTrees.Contains("Birch"))
            {
                selectedTree = "Birch";
                UpdateJournalText();
            }

            //Same as oak but for maple
            if (Input.GetKeyDown(KeyCode.Alpha3) && journalManager.discoveredTrees.Contains("Maple"))
            {
                selectedTree = "Maple";
                UpdateJournalText();
            }


            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextPage();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PreviousPage();
            }

            //If the current page on the left is locations and a number is pressed, show the info of the location on the right
            if (currentPage == 2)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && journalManager.discoveredLocations.Contains("Starter Forest"))
                {
                    selectedLocation = "Starter Forest";
                    UpdateJournalText();
                }
            }

            //If the current page on the left is axes and a number is pressed, show the info of the axe on the right
            if (currentPage == 3)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && journalManager.discoveredAxes.Contains("Rusty Axe"))
                {
                    selectedAxe = "Rusty Axe";
                    UpdateJournalText();
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) && journalManager.discoveredAxes.Contains("Traveler's Axe"))
                {
                    selectedAxe = "Traveler's Axe";
                    UpdateJournalText();
                }

                if (Input.GetKeyDown(KeyCode.Alpha3) && journalManager.discoveredAxes.Contains("Steel Axe"))
                {
                    selectedAxe = "Steel Axe";
                    UpdateJournalText();
                }

                if (Input.GetKeyDown(KeyCode.Alpha4) && journalManager.discoveredAxes.Contains("Forester's Axe"))
                {
                    selectedAxe = "Forester's Axe";
                    UpdateJournalText();
                }
            }
        }
    }

    private void ToggleJournal()
    {
        isOpen = !isOpen;

        journalPanel.SetActive(isOpen);

        if (isOpen )
        {
            if (journalManager.discoveredTrees.Count == 0)
            {
                selectedTree = "";
            }

            UpdateJournalText();
        }
    }

    private void NextPage()
    {
        currentPage++;

        if (currentPage >= pageNames.Length)
        {
            currentPage = 0;
        }

        UpdateJournalText();
    }

    private void PreviousPage()
    {
        currentPage--;

        if (currentPage < 0)
        {
            currentPage = pageNames.Length - 1;
        }

        UpdateJournalText();
    }

    private void UpdateJournalText()
    {
        StringBuilder leftPage = new StringBuilder();
        StringBuilder rightPage = new StringBuilder();

        leftPage.AppendLine("FORESTER'S JOURNAL");
        leftPage.AppendLine("");

        switch (currentPage)
        {
            //FIRST PAGE
            case 0:
                leftPage.AppendLine("This is a journal used to keep track of discoveries!");
                leftPage.AppendLine("");
                leftPage.AppendLine("Categories: " + "\n- Trees" + "\n- Locations" + "\n- Axes");
                break;
            
            //SECOND PAGE TREES
            case 1:
                leftPage.AppendLine("Category: " + pageNames[currentPage]);

                leftPage.AppendLine("");

                leftPage.AppendLine("Trees Found: " + journalManager.discoveredTrees.Count + "/" + journalManager.totalTreeTypes);

                leftPage.AppendLine("");
                leftPage.AppendLine("----------------");
                leftPage.AppendLine("");


                //Right page
                if (JournalDatabase.treeEntries.ContainsKey(selectedTree))
                {
                    JournalEntry entry = JournalDatabase.treeEntries[selectedTree];

                    rightPage.AppendLine(entry.title);
                    rightPage.AppendLine("");

                    rightPage.AppendLine("Base Value: $" + entry.value);

                    rightPage.AppendLine("Location: " +entry.location);

                    rightPage.AppendLine("Durability: " + entry.durability);

                    rightPage.AppendLine("");

                    rightPage.AppendLine(entry.description);
                }

                else
                {
                    rightPage.AppendLine("FORESTER'S NOTES");
                    rightPage.AppendLine("");

                    rightPage.AppendLine("No tree species have been " + "documented yet.");
                    rightPage.AppendLine("");

                    rightPage.AppendLine("Explore the world and discover " + "new trees to begin recording " + "information in the journal.");
                }

                    foreach (string tree in journalManager.discoveredTrees)
                    {
                        leftPage.AppendLine("- " + tree);
                    }

                break;

            //THIRD PAGE LOCATIONS
            case 2:
                leftPage.AppendLine("Category: " + pageNames[currentPage]);

                leftPage.AppendLine("");

                leftPage.AppendLine("Locations Found: " + journalManager.discoveredLocations.Count + "/" + journalManager.totallocations);

                leftPage.AppendLine("");
                leftPage.AppendLine("----------------");
                leftPage.AppendLine("");

                //Right page
                if (JournalDatabase.locationEntries.ContainsKey(selectedLocation))
                {
                    JournalEntry entry = JournalDatabase.locationEntries[selectedLocation];

                    rightPage.AppendLine(entry.title);
                    rightPage.AppendLine("");

                    rightPage.AppendLine(entry.description);
                }

                else
                {
                    rightPage.AppendLine("FORESTER'S NOTES");
                    rightPage.AppendLine("");

                    rightPage.AppendLine("No locations have been documented yet.");
                    rightPage.AppendLine("");

                    rightPage.AppendLine("Explore the world and discover " + "new locations to begin recording " + "information in the journal.");
                }

                foreach (string location in journalManager.discoveredLocations)
                {
                    leftPage.AppendLine("- " + location);
                }

                break;
        
            //FOURTH PAGE AXES
            case 3:
                leftPage.AppendLine("Category: " + pageNames[currentPage]);

                leftPage.AppendLine("");

                leftPage.AppendLine("Axes Found: " + journalManager.discoveredAxes.Count + "/" + journalManager.totalAxes);

                leftPage.AppendLine("");
                leftPage.AppendLine("----------------");
                leftPage.AppendLine("");

                //Right page
                if (JournalDatabase.axeEntries.ContainsKey(selectedAxe))
                {
                    JournalEntry entry = JournalDatabase.axeEntries[selectedAxe];

                    rightPage.AppendLine(entry.title);
                    rightPage.AppendLine("");

                    rightPage.AppendLine("Damage: " + entry.damage);
                    
                    rightPage.AppendLine("Cost: $" + entry.cost);
                    rightPage.AppendLine("");

                    rightPage.AppendLine(entry.description);
                }

                else
                {
                    rightPage.AppendLine("FORESTER'S NOTES");
                    rightPage.AppendLine("");

                    rightPage.AppendLine("No axes have been documented yet.");
                    rightPage.AppendLine("");

                    rightPage.AppendLine("Explore the world and discover " + "new axes to begin recording " + "information in the journal.");
                }

                foreach (string axe in journalManager.discoveredAxes)
                {
                    leftPage.AppendLine("- " + axe);
                }

                break;
        }

        leftPage.AppendLine("");
        leftPage.AppendLine("Press a discovered entry number to view details");
        leftPage.AppendLine("");
        leftPage.AppendLine("Use Left/Right Arrow Keys for next page");

        leftPageText.text = leftPage.ToString();
        rightPageText.text = rightPage.ToString();
    }
}
