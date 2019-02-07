using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astar_Pathfinding
{
    enum NodeType { Empty, Start, Open, Closed,  Obstacle, Target}
    class Node:IComparable
    {
        public NodeType nodeType;
        public Node parentNode;
        public int xPos,yPos;//Position of Node(0 = starting index)
        //[NOTES] : F = G + H
        public int Gcost;//cost value from starting node to current node
        public int Hcost;//cost value from current node to target node
        public bool isBlock;

        public Node(int _posx,int _posy, bool _isblock = false,NodeType _type = NodeType.Empty)
        {
            //positions
            xPos = _posx;
            yPos = _posy;
            //are obstacles?
            isBlock = _isblock;
            Hcost = 0;
            Gcost = 1;
            //parent node
            this.parentNode = null;
            //node type
            nodeType = _type;
        }

        public int CompareTo(object obj)
        {
            Node otherNode = obj as Node;
            //Place object before this node
            if (this.Hcost < otherNode.Hcost) return -1;
            //Place object after this node
            else if (this.Hcost > otherNode.Hcost) return 1;
            //Leave it if object & this node are the same
            return 0;
        }
        
        public override string ToString()
        {
            return String.Format($"{nodeType} Node");
        }
    }
}
