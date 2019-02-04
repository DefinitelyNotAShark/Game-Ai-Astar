using System;
using System.Collections.Generic;
using System.Text;

namespace Game_AI_Exercise
{
    class InputManager
    {
        private bool gameOver = false;

        public InputManager()
        {
            GameLoop();//start the game
        }

        private void GameLoop()
        {
            Map map = new Map(10, 10, 9, 9);
            Node start = new Node();
            start.xPos = 0;
            start.yPos = 0;

            Node current = new Node();
            current.xPos = 2;
            current.yPos = 3;

            Node finish = new Node();
            finish.xPos = 9;
            finish.yPos = 9;

            Console.WriteLine(map.CalculateFCost(start, finish, current));
            //map.SetNodes();
            

            while (!gameOver)
            {
                Console.ReadKey();
                Console.Clear();
                map.SetNodes();
            }
        }
    }
}
