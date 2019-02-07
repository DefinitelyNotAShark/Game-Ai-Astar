using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astar_Pathfinding
{
    class Astar
    {
        private Grid gridMap = new Grid(10, 10);
        public static SortingList openlist;
        public static SortingList closedList;
        /// <summary>
        /// Generates an array of predetermined obstacles nodes 
        /// </summary>
        /// <returns>returns an array</returns>
        private Node[] ObstacleNode()
        {

            Node[] blockNodes = { new Node(1, 2, true,NodeType.Obstacle), new Node(2, 5, true,NodeType.Obstacle), new Node(2, 6, true,NodeType.Obstacle), new Node(3, 1, true,NodeType.Obstacle), new Node(3, 2, true,NodeType.Obstacle),
            new Node(3, 3, true,NodeType.Obstacle), new Node(4, 6, true,NodeType.Obstacle),new Node(4, 7, true,NodeType.Obstacle),new Node(4, 8, true,NodeType.Obstacle),new Node(5, 0, true,NodeType.Obstacle),new Node(5, 1, true,NodeType.Obstacle),
            new Node(5, 2, true,NodeType.Obstacle), new Node(6, 5, true,NodeType.Obstacle),new Node(6, 6, true,NodeType.Obstacle),new Node(8, 1, true,NodeType.Obstacle),new Node(8, 2, true,NodeType.Obstacle),new Node(8, 3, true,NodeType.Obstacle),
            new Node(8, 4, true,NodeType.Obstacle), new Node(8, 6, true,NodeType.Obstacle),new Node(8, 7, true,NodeType.Obstacle),new Node(8, 8, true,NodeType.Obstacle)};
            return blockNodes;
        }

        public void Play()
        {
            //initialize start and goal node
            Node start = new Node(0, 0, false, NodeType.Start);
            Node target = new Node(9, 9, false, NodeType.Target);

            //Setup the node grid(obstacles,target,start,& empty nodes)
            SetUpGrid(start, target);
            //list that holds the result of A* path nodes
            ArrayList list = FindPath(start, target);

            start.nodeType = NodeType.Start;
            target.nodeType = NodeType.Target;

            //user input
            string input = "";
            //provides an interface for users to see the results of A* pathfinding
            do
            {
                Console.WriteLine("(gridpath, grid, pathnodes, clearscreen(cs), quit)");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "gridpath":
                        Console.WriteLine(gridMap.DrawImageGrid(list, true));
                        break;
                    case "grid":
                        Console.WriteLine(gridMap.DrawImageGrid(list, false));
                        break;
                    case "pathnodes":
                        showPathNodesTable(list);
                        break;
                    case "clearscreen":
                    case "cs":
                        Console.Clear();
                        break;
                    case "quit":
                        Console.WriteLine("this app will end shortly!");
                        break;
                    default:
                        Console.WriteLine("wrong input, try again!");
                        break;

                }
            } while (input.ToLower() != "quit"); 
        }
        /// <summary>
        /// Displays the set of Path Nodes Needed to reach the target node
        /// </summary>
        /// <param name="_list"></param>
        private void showPathNodesTable(ArrayList _list){
            for (int i = 0; i < _list.Count; i++)
            {
                Console.WriteLine("PosX: " + ((Node)_list[i]).xPos + "| PosY: " + ((Node)_list[i]).yPos + "| G: " + ((Node)_list[i]).Gcost + 
                    "| H: "+ ((Node)_list[i]).Hcost + "| F: " + ((Node)_list[i]).Fcost);
            }
        }
        /// <summary>
        /// Sets up the Node grid with obstacles, empty nodes,start node, and target node 
        /// </summary>
        /// <param name="_start">The node to start the A* pathfinding</param>
        /// <param name="_target">The goal node</param>
        private void SetUpGrid(Node _start,Node _target)
        {
            gridMap.AddToGridMap(_start);
            gridMap.AddToGridMap(_target);

            gridMap.InitializeObstacles(ObstacleNode());
            gridMap.InitializeEmptyNodes();
        }
        /// <summary>
        /// Produces the Path needed to reach the target goal node.
        /// </summary>
        /// <param name="_startnode">The node to start the A* pathfinding</param>
        /// <param name="_targetnode">The goal node</param>
        /// <returns>returns an array list of Nodes which defines the route needed to reach the goal node from the start node</returns>
        public ArrayList FindPath(Node _startnode, Node _targetnode)
        {
            openlist = new SortingList();
            openlist.Push(_startnode);
            _startnode.Gcost = 0;
            _startnode.Hcost = CalculateCost(_startnode, _targetnode);

            closedList = new SortingList();
            Node curNode = null;//The current Node
            while(openlist.Length() != 0)
            {
                //Set current node to the first node in the sorted list [the node with the lowest Fcost]
                curNode = openlist.First();
                //Check if current node is target node;
                //if so, return the list of all the nodes needed to reach the target
                if (curNode.xPos == _targetnode.xPos &&
                    curNode.yPos == _targetnode.yPos)
                {
                    return CalculatePath(curNode);
                }

                //An ArrayList to store the neighboring nodes
                ArrayList neighbors = new ArrayList();

                //Retrieves the neighbors from the grid
                gridMap.GetNeighbors(curNode,neighbors);

                //For Every node in the neighbors array, check if its in closedlist;
                
                for (int i = 0; i < neighbors.Count; i++)
                {
                    Node neighborNode = (Node)neighbors[i];
                    //if neighbor is not in closedlist
                    if (!closedList.HasNode(neighborNode))
                    {
                        //calculate the cost values for current neighbor node
                        int cost = CalculateCost(curNode, neighborNode);//Gcost
                        int totalCost = curNode.Gcost + cost;//Gcost of currentnode + Gcost 
                        int neighborToTargetHCost = CalculateCost(neighborNode,_targetnode);//Hcost

                        //update current neighbor node properties with new cost values
                        neighborNode.Gcost = totalCost;//Gcost
                        neighborNode.Hcost = neighborToTargetHCost;
                        neighborNode.Fcost = totalCost + neighborToTargetHCost;//Fcost

                        //update the Parent Node data
                        neighborNode.parentNode = curNode;
                        
                        //put current neighbor node in the openlist
                        if (!openlist.HasNode(neighborNode))
                        {
                            neighborNode.nodeType = NodeType.Open;
                            openlist.Push(neighborNode);
                        }
                    }
                }
                //Add the current node to the closed list
                closedList.Push(curNode);
                curNode.nodeType = NodeType.Closed;
                //and remove it from openList
                openlist.Remove(curNode);
            }
            //if agent cannot reach target node then there are no available paths
            if (curNode.xPos != _targetnode.xPos &&
                curNode.yPos != _targetnode.yPos)
            {
                return null;
            }
            return CalculatePath(curNode);
        }
        /// <summary>
        /// Generates the shortest path to reach target node
        /// </summary>
        /// <param name="_node"></param>
        /// <returns>returns a pathArray from the start node to the target node</returns>
        private static ArrayList CalculatePath(Node _node)
        {
            ArrayList list = new ArrayList();
            while (_node != null)
            {
                list.Add(_node);
                _node = _node.parentNode;
            }
            list.Reverse();
            return list;
        }
        /// <summary>
        /// Calculate the cost between two nodes by using the distance formula
        /// </summary>
        /// <param name="_curnode">The current node</param>
        /// <param name="_othernode">the other node</param>
        /// <returns>returns the cost between the current node and the other node</returns>
        private static int CalculateCost(Node _curnode,Node _othernode)
        {
            int CostX = _curnode.xPos - _othernode.xPos;
            int CostY = _curnode.yPos - _othernode.yPos;
            int magnitude = (int)Math.Round(Math.Sqrt((CostX * CostX) + (CostY * CostY)));
            
            return magnitude;
        }
        
    }
}
