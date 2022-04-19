using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Borders
    {
        private char ch;
        private List<Coordinates> border = new List<Coordinates>();

        public Borders(int x, int y, char ch)
        {
            this.ch = ch;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);
        }
        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Coordinates coordinates = new Coordinates(i, y, ch);
                coordinates.Draw();
                border.Add(coordinates);
            }
        }
        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Coordinates coordinates = new Coordinates(x, i, ch);
                coordinates.Draw();
                border.Add(coordinates);
            }
        }
    }
}
