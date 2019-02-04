using System;
using System.Collections.Generic;
using System.Text;

namespace Game_AI_Exercise
{
    class Node
    {
        public bool isBlock;
        public bool isPlayer;

        public int xPos;
        public int yPos;

        public int gValue;
        public int hValue;
        public int fValue;

        string nodeVisual()
        {
            if (isBlock)
                return "|B";

            else if (isPlayer)
                return "|X";

            else
                return "|-";
        }
    }
}
