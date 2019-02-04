using System;
using System.Collections.Generic;
using System.Text;

namespace Game_AI_Exercise
{
    class Block
    {
        public List<int> blockLocation = new List<int>();

        public Block(int passedInWidth, int passedInHeight)
        {
            blockLocation.Add(passedInWidth);
            blockLocation.Add(passedInHeight);
        }
    }
}
