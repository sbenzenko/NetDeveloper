﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolverLibrary;

namespace SudokuSolverTests
{
    [TestClass]
    public class Tester
    {
        [TestMethod]
        public void Solve_Simple()
        {
            byte[,] sudoku = new byte[9, 9] { 
                { 5, 1, 7, 6, 0, 0, 0, 3, 4},
                { 2, 8, 9, 0, 0, 4, 0, 0, 0},
                { 3, 4, 6, 2, 0, 5, 0, 9, 0},
                { 6, 0, 2, 0, 0, 0, 0, 1, 0},
                { 0, 3, 8, 0, 0, 6, 0, 4, 7},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 9, 0, 0, 0, 0, 0, 7, 8},
                { 7, 0, 3, 4, 0, 0, 5, 6, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            Solver solver = new Solver(sudoku);

            bool solved = solver.SolveSudoku();

            byte[,] result = new byte[9, 9] {
                {5, 1, 7, 6, 9, 8, 2, 3, 4},
                {2, 8, 9, 1, 3, 4, 7, 5, 6},
                {3, 4, 6, 2, 7, 5, 8, 9, 1},
                {6, 7, 2, 8, 4, 9, 3, 1, 5},
                {1, 3, 8, 5, 2, 6, 9, 4, 7},
                {9, 5, 4, 7, 1, 3, 6, 8, 2},
                {4, 9, 5, 3, 6, 2, 1, 7, 8},
                {7, 2, 3, 4, 8, 1, 5, 6, 9},
                {8, 6, 1, 9, 5, 7, 4, 2, 3}
            };

            Assert.IsTrue(solved);
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Assert.AreEqual(result[row, col], sudoku[row, col]);
                }
            }
        }

        [TestMethod]
        public void Solve_Medium()
        {
            byte[,] sudoku = new byte[9, 9] {
                { 0, 0, 5, 3, 0, 0, 0, 0, 0},
                { 8, 0, 0, 0, 0, 0, 0, 2, 0},
                { 0, 7, 0, 0, 1, 0, 5, 0, 0},
                { 4, 0, 0, 0, 0, 5, 3, 0, 0},
                { 0, 1, 0, 0, 7, 0, 0, 0, 6},
                { 0, 0, 3, 2, 0, 0, 0, 8, 0},
                { 0, 6, 0, 5, 0, 0, 0, 0, 9},
                { 0, 0, 4, 0, 0, 0, 0, 3, 0},
                { 0, 0, 0, 0, 0, 9, 7, 0, 0}
            };
            Solver solver = new Solver(sudoku);

            bool solved = solver.SolveSudoku();


            byte[,] result = new byte[9, 9] {
                {1, 4, 5, 3, 2, 7, 6, 9, 8},
                {8, 3, 9, 6, 5, 4, 1, 2, 7},
                {6, 7, 2, 9, 1, 8, 5, 4, 3},
                {4, 9, 6, 1, 8, 5, 3, 7, 2},
                {2, 1, 8, 4, 7, 3, 9, 5, 6},
                {7, 5, 3, 2, 9, 6, 4, 8, 1},
                {3, 6, 7, 5, 4, 2, 8, 1, 9},
                {9, 8, 4, 7, 6, 1, 2, 3, 5},
                {5, 2, 1, 8, 3, 9, 7, 6, 4}
            };

            Assert.IsTrue(solved);
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Assert.AreEqual(result[row, col], sudoku[row, col]);
                }
            }
        }

        [TestMethod]
        public void Solve_Hard()
        {
            byte[,] sudoku = new byte[9, 9] {
                { 8, 5, 0, 0, 0, 2, 4, 0, 0},
                { 7, 2, 0, 0, 0, 0, 0, 0, 9},
                { 0, 0, 4, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 0, 7, 0, 0, 2},
                { 3, 0, 5, 0, 0, 0, 9, 0, 0},
                { 0, 4, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 8, 0, 0, 7, 0},
                { 0, 1, 7, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 3, 6, 0, 4, 0}
            };
            Solver solver = new Solver(sudoku);

            bool solved = solver.SolveSudoku();

            byte[,] result = new byte[9, 9] {
                {8, 5, 9, 6, 1, 2, 4, 3, 7},
                {7, 2, 3, 8, 5, 4, 1, 6, 9},
                {1, 6, 4, 3, 7, 9, 5, 2, 8},
                {9, 8, 6, 1, 4, 7, 3, 5, 2},
                {3, 7, 5, 2, 6, 8, 9, 1, 4},
                {2, 4, 1, 5, 9, 3, 7, 8, 6},
                {4, 3, 2, 9, 8, 1, 6, 7, 5},
                {6, 1, 7, 4, 2, 5, 8, 9, 3},
                {5, 9, 8, 7, 3, 6, 2, 4, 1}
            };

            Assert.IsTrue(solved);
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Assert.AreEqual(result[row, col], sudoku[row, col]);
                }
            }
            
        }
    }
}
