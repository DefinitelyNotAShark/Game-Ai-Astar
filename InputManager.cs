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
            map.SetNodes();

            while (!gameOver)
            {
                Console.ReadKey();
                Console.Clear();
                map.SetNodes();
            }
        }
    }
}
