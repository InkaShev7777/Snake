using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    class Snake
    {
        public List<Coordinates> coordinates { get; set; }
        public bool IsLive { get; private set; }
        public string snake { get; set; }
        Food food;
        public Snake(int x,int y)
        {
            coordinates = new List<Coordinates>();
            coordinates.Add(new Coordinates(x, y));
        }
        public Snake()
        {
            snake = "*";
            coordinates = new List<Coordinates>();
            coordinates.Add(new Coordinates(1, 1));
            food = new Food();
            IsLive = true;
        }
        public void Show()
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                if(coordinates[i].X == 0 || coordinates[i].Y == 0 || coordinates[i].X == 40 || coordinates[i].Y == 20)
                {
                    Console.WriteLine("Game over!!!");
                    Thread.Sleep(500);
                    IsLive = false;
                }
                Console.SetCursorPosition(coordinates[i].X, coordinates[i].Y);
                if (i == 0)
                {
                    Console.Write("H");
                }
                else
                {
                    Console.Write("*");
                }
                Console.SetCursorPosition(food.X, food.Y);
                Console.Write("0");
            }
           
        }

        public void MoveBody()
        {
            for (int i = coordinates.Count-1; i > 0; i--)
            {
                coordinates[i].X = coordinates[i-1].X;
                coordinates[i].Y = coordinates[i-1].Y;
            }
        }
        public void AddFood()
        {
            GC.Collect(GC.GetGeneration(food));
            food = new Food();
        }
        public void Up()
        {
            if (coordinates[0].X == food.X && coordinates[0].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count-1].X,coordinates[coordinates.Count-1].Y-1));
                AddFood();
            }
            MoveBody();
            coordinates[0].Y--;
        }
        public void Down()
        {
            if (coordinates[0].X == food.X && coordinates[0].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count-1].X,coordinates[coordinates.Count-1].Y+1));
                AddFood();
            }
            MoveBody();
            coordinates[0].Y++;
        }
        public void Left()
        {
            if (coordinates[0].X == food.X && coordinates[0].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count-1].X-1,coordinates[coordinates.Count-1].Y));
                AddFood();
            }
            MoveBody();
            coordinates[0].X--;
        }
        public void Right()
        {
            if (coordinates[0].X == food.X && coordinates[0].Y == food.Y)
            {
                coordinates.Add(new Coordinates(coordinates[coordinates.Count-1].X+1,coordinates[coordinates.Count-1].Y));
                AddFood();
            }
            MoveBody();
            coordinates[0].X++;
        }
    }
}
