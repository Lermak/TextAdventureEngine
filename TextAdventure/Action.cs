using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAdventure
{
    public delegate string DelAction();
    public class Action
    {       
        public string[] ActionSynnonyms;//all elements must be in lower case
        public string[] ActWith;//all elements must be in lower case
        public string[] JunctionWords;//all elements must be in lower case
        public string[] ActUpon;//all elements must be in lower case
        DelAction act;
        public bool Performed = false;

        public string Act
        { get { return act(); } }

        public Action(string[] action, string[] with, string[] conj, string[] upon)
        {
            ActionSynnonyms = action;
            ActUpon = upon;
            ActWith = with;
            JunctionWords = conj;
            act = () => { return "No Action Defined"; };
        }

        public void SetupDelagate(DelAction d)
        {
            act = d;
        }

        public Action Copy()
        {
            Action a = new Action(ActionSynnonyms, ActWith, JunctionWords, ActUpon);
            a.SetupDelagate(act);

            return a;
        }
    }
}
