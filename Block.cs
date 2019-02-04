using System;
using System.Collections.Generic;
using System.Text;

namespace Game_AI_Exercise
{
    class Block
    {
        public int blockx;
        public int blocky;

        public Block(int passedInWidth, int passedInHeight)
        {
            blockx = passedInWidth;
            blocky = passedInHeight;
        }
    }
}
