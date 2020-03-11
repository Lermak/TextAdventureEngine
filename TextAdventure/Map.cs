using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    public static class Map
    {
        public static Room[][] MyRooms;
        static int xPos;
        static int yPos;

        public static Room CurrentRoom
        { get { return MyRooms[yPos][xPos]; } }

        public static void InitilizeMap(Room[][] rooms, int x, int y)
        {
            MyRooms = rooms;
            xPos = x;
            yPos = y;
        }
        /*
         *  Since the map is a jagged two dimesntional array
         *  movement down on the array means moving up on the y index, and moving up mean moving down on the index
         *  left/right movement is also reversed
         */
        public static string MoveUp()
        {
            string output = "";

            if(yPos - 1 < 0 || MyRooms[yPos - 1].Length <= xPos)
            {
                output = "I can't move that way";
            }
            else
            {
                yPos--;
            }

            return output;
        }

        public static string MoveDown()
        {
            string output = "";

            if (yPos + 1 > MyRooms.GetUpperBound(0) || MyRooms[yPos + 1].Length <= xPos)//upper bound returns the index, no need for >=
            {
                output = "I can't move that way";
            }
            else
            {
                yPos++;
            }

            return output;
        }

        public static string MoveLeft()
        {
            string output = "";

            if (xPos - 1 < 0)
            {
                output = "I can't move that way";
            }
            else
            {
                xPos--;
            }

            return output;
        }

        public static string MoveRight()
        {
            string output = "";

            if (xPos + 1 >= MyRooms[yPos].Length)
            {
                output = "I can't move that way";
            }
            else
            {
                xPos++;
            }

            return output;
        }
    }
}
