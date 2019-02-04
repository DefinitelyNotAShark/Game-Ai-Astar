using System;
using System.Collections.Generic;
using System.Text;

namespace Game_AI_Exercise
{
    class Node
    {
        Node parentNode;

        public bool isBlock;
        public bool isPlayer;

        public int xPos;
        public int yPos;

        public int gValue;
        public int hValue;
        public int fValue;

        public Node()
        {
            xPos = 0;
            yPos = 0;
        }
        public Node(int _posX,int _posY, bool _isblock = false)
        {
            xPos = _posX;
            yPos = _posY;
            isBlock = _isblock;
        }
        /// <summary>
        /// The parent Nodes; THe area where we will check the surround nodes for (F) costs
        /// </summary>
        /// <param name="_PosX"></param>
        /// <param name="_PosY"></param>
        private void InitParentNode(int _PosX, int _PosY)
        {
            parentNode = new Node(_PosX, _PosY);
        }
        public string nodeVisual()
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
