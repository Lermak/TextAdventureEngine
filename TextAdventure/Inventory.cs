using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAdventure
{
    public static class Inventory
    {
        public static List<Item> MyItems = new List<Item>();

        public static bool HaveItem(string name)
        {
            return MyItems.Select(s => s.Name == name).Any();
        }

        public static void Remove(string name)
        {
            MyItems.Remove(MyItems.Select(s => s).Where(s => s.Name == name).First());
        }

        public static string ShowInventory()
        {
            string output = "";
            for(int i = 0; i < MyItems.Count; ++i)
            {
                output += MyItems[i].Name + "\n";
            }
            return output;
        }

        public static string Examine(string name)
        {
            string output = "";
            Item i = MyItems.Select(s => s).Where(s => s.Name == name).First();

            if (i != null)
                output = i.Description;
            else
                output = "I don't have that.";

            return output;
        }
    }
}
