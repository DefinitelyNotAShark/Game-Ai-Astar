using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astar_Pathfinding
{
    class SortingList
    {
        private ArrayList nodes = new ArrayList();
        public SortingList()
        {
            nodes = new ArrayList();
        }
        /// <summary>
        /// The length of the arraylist
        /// </summary>
        /// <returns>return the length of the arraylist</returns>
        public int Length()
        {
            return this.nodes.Count;
        }
        /// <summary>
        /// Determines whether the node is present in the arraylist
        /// </summary>
        /// <param name="_nodetoFind">the node to search for in the sorted ArrayList</param>
        /// <returns>returns a true or false whether the list has the node</returns>
        public bool HasNode(Node _nodetoFind)
        {
            return this.nodes.Contains(_nodetoFind);
        }
        /// <summary>
        /// Gets the first node in the ArrayList
        /// </summary>
        /// <returns>Returns the first node in the sorted ArrayList</returns>
        public Node First()
        {
            if (this.nodes.Count > 0)
            {
                return this.nodes[0] as Node;
            }
            return null;
        }
        /// <summary>
        /// Adds the node to the sorted ArrayList, then sorts it again
        /// </summary>
        /// <param name="_nodeToAdd">The node to add in the sorted ArrayList</param>
        public void Push(Node _nodeToAdd)
        {
            this.nodes.Add(_nodeToAdd);
            this.nodes.Sort();
        }
        /// <summary>
        /// Removes the node from the sorted ArrayList, then sorts it again 
        /// </summary>
        /// <param name="_nodeToRemove">The node to remove in the sorted ArrayList</param>
        public void Remove(Node _nodeToRemove)
        {
            this.nodes.Remove(_nodeToRemove);
            this.nodes.Sort();
        }
        
    }
}
