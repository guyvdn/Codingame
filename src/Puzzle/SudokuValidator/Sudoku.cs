using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.Puzzle.SudokuValidator
{
    public class Sudoku
    {
        public class Point
        {
            public Point(int x, int y, int value)
            {
                X = x;
                Y = y;
                Value = value;
            }

            public int X { get; }
            public int Y { get; }
            public int Value { get; }
            public int SubGrid => (3 * (Y / 3)) + (X / 3);
        }

        private readonly List<Point> _points = new List<Point>();

        public void AddPoint(int x, int y, int value)
        {
            _points.Add(new Point(x, y, value));
        }

        public bool IsValid
        {
            get
            {
                return IsValidGroup(x => x.X) &&
                       IsValidGroup(x => x.Y) &&
                       IsValidGroup(x => x.SubGrid);
            }
        }

        private bool IsValidGroup(Func<Point, int> keySelector)
        {
            return _points
                .GroupBy(keySelector)
                .All(g => g.GroupBy(x => x.Value).Count() == 9);
        }
    }
}