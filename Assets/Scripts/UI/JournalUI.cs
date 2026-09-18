using TMPro;
using UnityEngine;
using System.Text;

public class JournalUI : MonoBehaviour
{
    //Journal panel object
    public GameObject journalPanel;

    //Text displayed inside the journal
    public TextMeshProUGUI journalText;

    //reference to journal system
    public JournalManager journalManager;

    private bool isOpen = false;

    //current journal page
    private int currentPage = 0;

    private string[] pageNames = { "Contents", "Trees", "Locations", "Axes" };

    private void Update()
    {
        //Press J to open/close journal
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleJournal();
        }

        if (isOpen)
        {
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
        StringBuilder journal = new StringBuilder();

        journal.AppendLine("FORESTER'S JOURNAL");
        journal.AppendLine("");

        switch (currentPage)
        {
            case 0:
                journal.AppendLine("This is a journal used to keep track of discoveries!");
                journal.AppendLine("");
                journal.AppendLine("Categories: " + "\n- Trees" + "\n- Locations" + "\n- Axes");
                break;

            case 1:
                journal.AppendLine("Category: " + pageNames[currentPage]);

                journal.AppendLine("");

                journal.AppendLine("Trees Found: " + journalManager.discoveredTrees.Count + "/" + journalManager.totalTreeTypes);

                journal.AppendLine("");

                foreach (string tree in journalManager.discoveredTrees)
                {
                    journal.AppendLine("- " + tree);
                }

                break;

            case 2:
                journal.AppendLine("Category: " + pageNames[currentPage]);

                journal.AppendLine("");

                journal.AppendLine("Locations Found: " + journalManager.discoveredLocations.Count + "/" + journalManager.totallocations);

                journal.AppendLine("");

                foreach (string location in journalManager.discoveredLocations)
                {
                    journal.AppendLine("- " + location);
                }

                break;

            case 3:
                journal.AppendLine("Category: " + pageNames[currentPage]);

                journal.AppendLine("");

                journal.AppendLine("Axes Found: " + journalManager.discoveredAxes.Count + "/" + journalManager.totalAxes);

                journal.AppendLine("");

                foreach (string axe in journalManager.discoveredAxes)
                {
                    journal.AppendLine("- " + axe);
                }

                break;
        }

        journal.AppendLine("");
        journal.AppendLine("Use Left/Right Arrow Keys");

        journalText.text = journal.ToString();
    }
}
