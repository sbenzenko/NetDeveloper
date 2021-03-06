﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolverLibrary;

namespace SolveSudokuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[,] sudoku = new byte[9, 9] {
            //    { 5, 1, 7, 6, 0, 0, 0, 3, 4},
            //    { 2, 8, 9, 0, 0, 4, 0, 0, 0},
            //    { 3, 4, 6, 2, 0, 5, 0, 9, 0},
            //    { 6, 0, 2, 0, 0, 0, 0, 1, 0},
            //    { 0, 3, 8, 0, 0, 6, 0, 4, 7},
            //    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    { 0, 9, 0, 0, 0, 0, 0, 7, 8},
            //    { 7, 0, 3, 4, 0, 0, 5, 6, 0},
            //    { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            //};

            //byte[,] sudoku = new byte[9, 9] {
            //    { 0, 0, 5, 3, 0, 0, 0, 0, 0},
            //    { 8, 0, 0, 0, 0, 0, 0, 2, 0},
            //    { 0, 7, 0, 0, 1, 0, 5, 0, 0},
            //    { 4, 0, 0, 0, 0, 5, 3, 0, 0},
            //    { 0, 1, 0, 0, 7, 0, 0, 0, 6},
            //    { 0, 0, 3, 2, 0, 0, 0, 8, 0},
            //    { 0, 6, 0, 5, 0, 0, 0, 0, 9},
            //    { 0, 0, 4, 0, 0, 0, 0, 3, 0},
            //    { 0, 0, 0, 0, 0, 9, 7, 0, 0}
            //};

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

            Console.WriteLine($"Sudoku solved: {solved}");
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write($"{solver.Grid[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Backtracks: {solver.BackTracks}");

            Console.ReadLine();
        }

        
    }
}
