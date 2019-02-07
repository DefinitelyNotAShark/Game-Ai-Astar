using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astar_Pathfinding
{
    class Grid
    {
        
        private Node[,] grid;//The 2D array representation of a grid containing all cells
        public string[,] imagegrid;
        public int maxRows;//# of Rows in the grid
        public int maxColumns;//# of Colummns in the grid
        public Grid(int _numofrows,int _numofcolumns)
        {
            maxRows = _numofrows;
            maxColumns = _numofcolumns;
            grid = new Node[_numofcolumns,_numofrows];
        }
        public void InitializeEmptyNodes()
        {
            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxColumns; j++)
                {
                    if (grid[i, j] == null)
                    {
                        grid[i, j] = new Node(j, i,false,NodeType.Empty);
                    }

                }
            }
        }
        /// <summary>
        /// Set Nodes that are obstacles and adds them to the grid
        /// </summary>
        /// <param name="_nodes">An array of block obstacle nodes</param>
        public void InitializeObstacles(params Node[] _nodes)
        {
            CalculateObstacles(_nodes);
        }
       
        /// <summary>
        /// Makes the nodes an obstacle and places them on the grid
        /// </summary>
        /// <param name="_nodes"></param>
        private void CalculateObstacles(params Node[] _nodes)
        {
            for (int i = 0; i < _nodes.Length; i++)
            {
                SetNodeAsObstacle(_nodes[i]);
                AddObstacleToGrid(_nodes[i]);
            }
        }
        /// <summary>
        /// Set the Node as an Obstacle
        /// </summary>
        /// <param name="_node"></param>
        private void SetNodeAsObstacle(Node _node)
        {
            _node.isBlock = true;
        }
        /// <summary>
        /// Add the Block Obstacle to the Grid [row,column]
        /// </summary>
        /// <param name="_node"></param>
        private void AddObstacleToGrid(Node _node)
        {
            grid[_node.yPos, _node.xPos] = _node;
        }
        /// <summary>
        /// Places the set of neighbors in a list
        /// </summary>
        /// <param name="_node"></param>
        /// <param name="_neighbors"></param>
        public void GetNeighbors(Node _node, ArrayList _neighbors)
        {
            int neighborPosX = _node.xPos;
            int neighborPosY = _node.yPos;

            //Bottom
            int NodeRow = neighborPosY + 1;
            int NodeColumn = neighborPosX;
            AssignNeighbor(NodeRow,NodeColumn,_neighbors);

            //Top
            NodeRow = neighborPosY - 1;
            NodeColumn = neighborPosX;
            AssignNeighbor(NodeRow, NodeColumn, _neighbors);
            //Right
            NodeRow = neighborPosY;
            NodeColumn = neighborPosX + 1;
            AssignNeighbor(NodeRow, NodeColumn, _neighbors);
            //Left
            NodeRow = neighborPosY;
            NodeColumn = neighborPosX - 1;
            AssignNeighbor(NodeRow, NodeColumn, _neighbors);
        }
        /// <summary>
        /// Adds the neighbors that are not obstacles to the list of neighbors
        /// </summary>
        /// <param name="_row">the current row of the neighbor</param>
        /// <param name="_column">the current column of the neighbor</param>
        /// <param name="_neighbors">A list that holds the current neighbors</param>
        private void AssignNeighbor(int _row,int _column, ArrayList _neighbors)
        {
            if (!IsOutOfBounds(_row) && !IsOutOfBounds(_column) 
                && _row < maxRows && _column < maxColumns)
            {
                Node curNodeOnGrid = grid[_row,_column];
                
                if (!curNodeOnGrid.isBlock)
                {
                    _neighbors.Add(curNodeOnGrid);
                } 
            }
        }
        /// <summary>
        /// Determines if position is out of bounds
        /// </summary>
        /// <param name="_position">the position of the node [can be X-axis or Y-axis]</param>
        /// <returns>returns whether the current position is out of bounds</returns>
        private bool IsOutOfBounds(int _position)
        {
            if (_position < 0) return true;
            return false;
        }
        /// <summary>
        /// Adds node to grid
        /// </summary>
        /// <param name="_node">The node to place on the grid</param>
        public void AddToGridMap(Node _node)
        {
            grid[_node.xPos, _node.yPos] = _node;
        }
        /// <summary>
        /// Sets the image grid with the symbols each type of node
        /// </summary>
        /// <param name="_list"></param>
        private void SetUpImageGrid(ArrayList _list)
        {
            imagegrid = new string[maxRows, maxColumns];
            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxColumns; j++)
                {
                    
                    switch (grid[i,j].nodeType)
                    {
                        case NodeType.Empty:
                            imagegrid[i,j] = "| - |";
                            break;
                        case NodeType.Start:
                            imagegrid[i, j] = "| @ |";
                            break;
                        case NodeType.Obstacle:
                            imagegrid[i, j] = "| X |";
                            break;
                        case NodeType.Target:
                            imagegrid[i, j] = "| * |";
                            break;
                        case NodeType.Closed:
                            imagegrid[i, j] = "| C |";
                            break;
                        case NodeType.Open:
                            imagegrid[i, j] = "| O |";
                            break;
                    }
                }
            }
        }
        public string DrawImageGrid(ArrayList _list,bool _drawpath)
        {
            SetUpImageGrid(_list);
            if (_drawpath)
            {
                DrawPath(_list);
            }
            string text = "";
            for (int i = 0; i < maxRows; i++)
            {
                text += "\n";
                for (int j = 0; j < maxColumns; j++)
                {
                    text += imagegrid[i, j];
                }
            }
            return text;
        }
        /// <summary>
        /// Draws the path on the image grid
        /// </summary>
        /// <param name="_list"></param>
        private void DrawPath(ArrayList _list)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                imagegrid[((Node)_list[i]).yPos, ((Node)_list[i]).xPos] = "| ? |";
            }
        }
    }
}
