using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public class Item
    {
        public string Name;
        public string Description;

        public Item(string n, string d)
        {
            Name = n;
            Description = d;
        }
    }
}
