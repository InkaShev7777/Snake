using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Food:Coordinates
    {
        Random rand = new Random();
        public Food()
        {
            X = rand.Next(1, 40);
            Y = rand.Next(1, 20);
        }
    }
}
