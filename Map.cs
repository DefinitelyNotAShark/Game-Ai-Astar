using System;
using System.Collections.Generic;
using System.Text;

namespace Game_AI_Exercise
{
    class Map
    {
        private int width;
        private int height;


        private int startPointX;
        private int startPointY;
        private int endPointX;
        private int endPointY;

        private bool wasABlock = false;
        private List<Block> blocks = new List<Block>();

        private List<Node> open = new List<Node>();
        private List<Node> closed = new List<Node>();



        public Map(int passedInWidth, int passedInHeight, int xParamGoal, int yParamGoal)
        {
            width = passedInWidth;
            height = passedInHeight;
            endPointX = xParamGoal;
            endPointY = yParamGoal;
            AddBlocks();

            Node start = new Node();
            start.xPos = startPointX;
            start.yPos = startPointY;

            open.Add(start);

        }

        #region AddBlocks
        private void AddBlocks()
        {
            blocks.Add(new Block(1, 2));
            blocks.Add(new Block(2, 5));
            blocks.Add(new Block(2, 6));
            blocks.Add(new Block(2, 7));
            blocks.Add(new Block(3, 1));
            blocks.Add(new Block(3, 2));
            blocks.Add(new Block(3, 3));
            blocks.Add(new Block(4, 7));
            blocks.Add(new Block(4, 8));
            blocks.Add(new Block(4, 9));
            blocks.Add(new Block(5, 0));
            blocks.Add(new Block(5, 1));
            blocks.Add(new Block(5, 2));
            blocks.Add(new Block(6, 5));
            blocks.Add(new Block(6, 6));
            blocks.Add(new Block(8, 1));
            blocks.Add(new Block(8, 2));
            blocks.Add(new Block(8, 3));
            blocks.Add(new Block(8, 4));
            blocks.Add(new Block(8, 7));
            blocks.Add(new Block(8, 8));
            blocks.Add(new Block(8, 9));
        }
        #endregion

        public void SetNodes()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //make a node and set its position to current
                    Node n = new Node();
                    n.xPos = x;
                    n.yPos = y;
                    
                    //check if it's a block
                    foreach(Block b in blocks)
                    {
                        if (b.blockx == x && b.blocky == y)
                        {
                            n.isBlock = true;
                        }
                    }

                    //
                    foreach(Node openNode in open)
                    {

                    }


                }
            }
        }

        public string CalculateFCost(Node start, Node finish, Node current)
        {
            //calculate G (distance from start);
            int g;
            int gx = Math.Abs(current.xPos) - Math.Abs(start.xPos);//get the x difference
            int gy = Math.Abs(current.yPos) - Math.Abs(start.yPos);//get the y difference

            if (gx == 0 || gy == 0)//if the difference between one of them is 0, one of them is a straight line
            {
                if (gx != 0)//if the x difference is more than 0, horizontal line
                {
                    g = gx * 10;
                    return g.ToString();
                }
                else if (gy != 0)//if the y difference is more than 0, vertical line
                {
                    g = gy * 10;
                    return g.ToString();
                }
            }
            else//otherwise, we have a diagonal line
            {
                double sum = (gx * gx) + (gy * gy);//square both of the distances
                g = Convert.ToInt16(Math.Sqrt(sum) * 14);//
                return g.ToString();
            }

            return "";

             
            //calculate H (distance from end);

            // f = g + h;

            //return f;
        }

        //public void DrawMap()
        //{
            
        //    Player player = new Player();//initial x and y and goal x and y

        //    for (int i = 0; i < height; i++)
        //    {
        //        if (i == player.x)
        //            correctHeight = true;
        //        else
        //            correctHeight = false;

        //        if (i == player.x)
        //            goalHeight = true;
        //        else
        //            goalHeight = false;


        //        for (int a = 0; a < width; a++)
        //        {
        //            wasABlock = false;

        //            foreach(Block b in blocks)
        //            {
        //                if(b.blockLocation[0] == a && b.blockLocation[1] == i)
        //                {
        //                    Console.Write("|B");
        //                    wasABlock = true;
        //                }
                    
        //            }

        //            if (a == player.y)
        //            {
        //                if (correctHeight)
        //                    Console.Write("|X");
        //                else
        //                    Console.Write("|-");
        //            }

        //            else if (a == player.y)
        //            {
        //                if (goalHeight)
        //                    Console.Write("|O");
        //                else
        //                    Console.Write("|-");
        //            }

        //            else if(!wasABlock)
        //            {
        //                Console.Write("|-");
        //            }


        //        }//end second for loop
        //            Console.Write("|\n");
        //    }//end first for loop
        //}//end draw map

    }
}
