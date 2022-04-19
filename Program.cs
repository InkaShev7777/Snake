using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static Action action = null;
        static Snake snake = new Snake();
        static ConsoleKeyInfo key;
        static void Main(string[] args)
        {
            Thread th = new Thread(RunMetod);
            th.Start();
            snake.Show();
            do
            {
                Borders border = new Borders(40,20,'#');
                Thread.Sleep(200);
                Console.Clear();
                action?.Invoke();
                snake.Show();
               
            }
            while (snake.IsLive);
        }
        private static void RunMetod(object? obj)
        {
            do
            {
                key = Console.ReadKey();
                Thread.Sleep(150);
                Console.CursorVisible = false;
                if (key.Key == ConsoleKey.UpArrow)
                {
                    action = snake.Up;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    action = snake.Down;
                
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    action = snake.Left;
               
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    action = snake.Right;
                }
            } while (snake.IsLive);
        }
    }
}
