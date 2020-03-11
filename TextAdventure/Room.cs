using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAdventure
{
    public class Room
    {
        Action[] MyActions;
        //All details about a room are stored in this array
        //element 0 is the opening description of the room, all other elements are shown in the RoomDescription method
        public string[] description;
        public Room(string[] desc)
        {
            description = desc;
        }
        public void SetupActions(Action[] act)
        {
            MyActions = act;
        }

        public string RoomDescription()
        {
            string output = "";
            for(int i = 1; i < description.Length; ++i)
            {
                output += description[i];
            }
            return output;
        }



        /// <summary>
        /// Locate the first action that uses the verb and noun provided in my list of actions
        /// If an aciton was located, attempt to perform it.
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="upon"></param>
        /// <returns></returns>
        public string PerformAction(string[] commands)
        {
            string output = "";

            if (commands.Length > 0)
            {
                var actions = MyActions.Select(a => a).Where(a => a.ActionSynnonyms.Contains(commands[0]));
                if (actions.Any())
                {
                    if (commands.Length > 1)
                    {
                        var actionOn = actions.Select(a => a).Where(a => a.ActWith.Contains(commands[1]));
                        if (actionOn.Any())
                        {
                            if (commands.Length > 2)
                            {
                                var actionOnTo = actionOn.Select(a => a).Where(a => a.JunctionWords.Contains(commands[2]));

                                if (actionOnTo.Any())
                                {
                                    var actionOnToObj = actionOnTo.Select(a => a).Where(a => a.ActUpon.Contains(commands[3]));

                                    if (actionOnToObj.Any())
                                        output = actionOnToObj.First().Act;
                                    else
                                        output = "I can't do that!";
                                }
                                else
                                {
                                    output = "I don't understand how that works.";
                                }
                            }
                            else
                            {
                                output = actionOn.First().Act;
                            }
                        }
                        else
                        {
                            output = "I can't do anything with that.";
                        }
                    }
                    else
                    {
                        output = actions.First().Act;
                    }
                }
                else
                {
                    output = "I can't do that here.";
                }
            }

            return output;
        }

        public Room Copy()
        {
            string[] s = new string[description.Length];
            description.CopyTo(s, 0);
            Room r = new Room(s);

            if (MyActions != null)
            {
                Action[] a = new Action[MyActions.Length];
                MyActions.CopyTo(r.MyActions, 0);
            }

            return r;
        }
    }
}
