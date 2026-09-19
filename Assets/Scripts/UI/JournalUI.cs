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

    //Currently selected tree
    private string selectedTree = "Oak";

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
            case 0:
                leftPage.AppendLine("This is a journal used to keep track of discoveries!");
                leftPage.AppendLine("");
                leftPage.AppendLine("Categories: " + "\n- Trees" + "\n- Locations" + "\n- Axes");
                break;

            case 1:
                leftPage.AppendLine("Category: " + pageNames[currentPage]);

                leftPage.AppendLine("");

                leftPage.AppendLine("Trees Found: " + journalManager.discoveredTrees.Count + "/" + journalManager.totalTreeTypes);

                leftPage.AppendLine("");
                leftPage.AppendLine("----------------");
                leftPage.AppendLine("");

                if (JournalDatabase.treeEntries.ContainsKey(selectedTree))
                {
                    JournalEntry entry =
                        JournalDatabase.treeEntries[selectedTree];

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

            case 2:
                leftPage.AppendLine("Category: " + pageNames[currentPage]);

                leftPage.AppendLine("");

                leftPage.AppendLine("Locations Found: " + journalManager.discoveredLocations.Count + "/" + journalManager.totallocations);

                leftPage.AppendLine("");

                foreach (string location in journalManager.discoveredLocations)
                {
                    leftPage.AppendLine("- " + location);
                }

                break;

            case 3:
                leftPage.AppendLine("Category: " + pageNames[currentPage]);

                leftPage.AppendLine("");

                leftPage.AppendLine("Axes Found: " + journalManager.discoveredAxes.Count + "/" + journalManager.totalAxes);

                leftPage.AppendLine("");

                foreach (string axe in journalManager.discoveredAxes)
                {
                    leftPage.AppendLine("- " + axe);
                }

                break;
        }

        leftPage.AppendLine("");
        leftPage.AppendLine("Press A Number to View Tree Types");
        leftPage.AppendLine("");
        leftPage.AppendLine("Use Left/Right Arrow Keys for next page");

        leftPageText.text = leftPage.ToString();
        rightPageText.text = rightPage.ToString();
    }
}
