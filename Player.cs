using System;
using System.Collections.Generic;
using System.Text;

namespace Game_AI_Exercise
{
    class Player
    {
        public List<int> playerLocation = new List<int>();
        public List<int> goalLocation = new List<int>();

        public Player(int passedInWidth, int passedInHeight, int goalPosX, int goalPosY)
        {
            playerLocation.Add(passedInWidth);
            playerLocation.Add(passedInHeight);

            goalLocation.Add(goalPosX);
            goalLocation.Add(goalPosY);
        }

        void PlayerChooseDirection()
        {
        }
    }
}
