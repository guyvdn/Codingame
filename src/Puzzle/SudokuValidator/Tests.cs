using FluentAssertions;
using NUnit.Framework;
using System;

namespace Codingame.Puzzle.SudokuValidator
{
    public class Tests
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(2, 0, ExpectedResult = 0)]
        [TestCase(3, 0, ExpectedResult = 1)]
        [TestCase(5, 0, ExpectedResult = 1)]
        [TestCase(6, 0, ExpectedResult = 2)]
        [TestCase(8, 0, ExpectedResult = 2)]
        [TestCase(0, 2, ExpectedResult = 0)]
        [TestCase(0, 3, ExpectedResult = 3)]
        [TestCase(4, 4, ExpectedResult = 4)]
        [TestCase(6, 6, ExpectedResult = 8)]
        public int SubGridTests(int x, int y)
        {
            return new Sudoku.Point(x, y, 0).SubGrid;
        }

        [Test]
        public void TestGrids()
        {
            CreateSudoku(TestCases.BasicGrid).IsValid.Should().BeTrue();
            CreateSudoku(TestCases.AnotherCorrectGrid).IsValid.Should().BeTrue();
            CreateSudoku(TestCases.RowError).IsValid.Should().BeFalse();
            CreateSudoku(TestCases.ColumnError).IsValid.Should().BeFalse();
            CreateSudoku(TestCases.SubgridError).IsValid.Should().BeFalse();
            CreateSudoku(TestCases.RubbishError).IsValid.Should().BeFalse();
            CreateSudoku(TestCases.WhenSummingIsNotEnough).IsValid.Should().BeFalse();
        }

        private static Sudoku CreateSudoku(string input)
        {
            var sudoku = new Sudoku();

            var lines = input.Split(Environment.NewLine);
            for (int i = 0; i < 9; i++)
            {
                var inputs = lines[i].Split(' ');
                for (var j = 0; j < 9; j++)
                {
                    int n = int.Parse(inputs[j]);
                    sudoku.AddPoint(i, j, n);
                }
            }

            return sudoku;
        }
    }
}