using System.Collections.Generic;
using UnityEngine;

public static class JournalDatabase
{
    public static Dictionary<string, JournalEntry> treeEntries = new Dictionary<string, JournalEntry>()

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

    public static Dictionary<string, JournalEntry> axeEntries = new Dictionary<string, JournalEntry>()
    {
        {
            "Rusty Axe",
            new JournalEntry
            {
                title = "Rusty Axe",

                damage = 1,

                cost = 0,

                description = "A worn axe purchased by many newcomers.\n\nEvery forester has to start somewhere!"
            }
        },

        {
            "Traveler's Axe",
            new JournalEntry
            {
                title = "Traveler's Axe",

                damage = 2,

                cost = 50,

                description = "A well-maintained axe designed for constant use.\n\nPopular among travelers and merchants."
            }
        },

        {
            "Steel Axe",
            new JournalEntry
            {
                title = "Steel Axe",

                damage = 3,

                cost = 150,

                description = "A durable steel-bladed axe capable of handling tougher trees.\n\nMany woodcutters consider this where logging becomes truly profitable."
            }
        },

        {
            "Forester's Axe",
            new JournalEntry
            {
                title = "Forester's Axe",

                damage = 5,

                cost = 400,

                description = "A trusted tool carried by experienced foresters.\n\nBuilt for long days in the wilderness."
            }
        }
    };

    public static Dictionary<string, JournalEntry> locationEntries = new Dictionary<string, JournalEntry>()
    {
        {
            "Starter Forest",
            new JournalEntry
            {
                title = "Starter Forest",

                description = "The first woodland beyond the village.\n\nOak, Birch, and Maple trees grow throughout this region.\n\nMost new loggers begin their journeys here!"
            }
        }
    };
}
