using System.Collections.Generic;
using UnityEngine;

public static class JournalDatabase
{
    public static Dictionary<string, JournalEntry> treeEntries =
        new Dictionary<string, JournalEntry>()
    {
        {
            "Oak",
            new JournalEntry
            {
                title = "Oak Tree",

                description =
                "This was the first tree species I encountered after arriving near the village. The locals make heavy use of oak in construction due to its availability and reliability.\n\nThe wood carries a faint earthy scent that becomes more noticeable after freshly cutting the tree.",

                location = "Starter Forest",

                value = 10,

                durability = 3
            }
        },

        {
            "Birch",
            new JournalEntry
            {
                title = "Birch Tree",

                description =
                "Several villagers mentioned that birch is preferred for decorative work thanks to its pale appearance.\n\nThe bark is noticeably smoother than oak and can often be spotted from a distance.",

                location = "Starter Forest",

                value = 25,

                durability = 5
            }
        },

        {
            "Maple",
            new JournalEntry
            {
                title = "Maple Tree",

                description =
                "Maple trees are harder to find than other local species and are often considered a lucky discovery by new loggers.\n\nSome villagers collect maple sap for various uses around town.",

                location = "Starter Forest",

                value = 50,

                durability = 8
            }
        }
    };
}
