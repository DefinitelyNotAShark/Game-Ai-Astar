using System;

//data scrtucture and algorithm to guide bot from point a to point b
//bot knows location
//knows if attempt to move location fails

/* Steps:
 * Draw out chart
 * Have a position var
 * Check if is at goal
 * Check if can move the best direction
 *  If can't move, then try to go in another direction
 *  Keep doing 1 move maybe with each button push
 */

namespace Game_AI_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            InputManager input = new InputManager();
            Console.Read();
        }
    }
}
