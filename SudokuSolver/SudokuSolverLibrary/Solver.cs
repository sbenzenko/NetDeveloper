using System;

namespace SudokuSolverLibrary
{
    public class Solver
    {
        public byte[,] Grid { get; } = new byte[9, 9];

        // Number of invalid tries 
        public int BackTracks { get; set; } = 0;
        public bool Solved { get; } = false;

        public Solver(byte[,] grid)
        {
            Grid = grid;
        }

        /// <summary>
        /// Main entry point:
        /// 1) Finding next empty cell
        /// 2) Try all numbers in a loop and check if grid is valid
        /// 3) If grid is valud, recursively call SolveSudoku
        /// </summary>
        /// <returns></returns>
        public bool SolveSudoku()
        {
            // find next cell to fill
            var nextCell = FindNextCellToFill();
            if (nextCell.Col == -1)
                return true;

            for (byte value = 1; value < 10; value++)
            {
                //try different number in [row,column] cell
                if (IsValid(nextCell.Row, nextCell.Col, value))
                {
                    Grid[nextCell.Row, nextCell.Col] = value;
                    if (SolveSudoku())
                        return true;

                    // The grid is invalid. Go back to try different number
                    // Increment number of backtracks
                    BackTracks++;
                    Grid[nextCell.Row, nextCell.Col] = 0;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Finding next empty cell
        /// </summary>
        /// <returns></returns>
        private (sbyte Row, sbyte Col) FindNextCellToFill()
        {
            for (sbyte row = 0; row < 9; row++)
            {
                for (sbyte col = 0; col < 9; col++)
                {
                    if (Grid[row, col] == 0)
                        return (row, col);
                }
            }

            return (-1, -1);
        }

        /// <summary>
        /// Check if grid is valid
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsValid(sbyte row, sbyte col, byte value)
        {
            return IsRowOK(row, value) && IsColumnOK(col, value) && IsSectorOK((sbyte) (3*(row/3)), (sbyte) (3*(col/3)), value);
        }

        /// <summary>
        /// Is sector 3x3 valid (all numbers are different)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsSectorOK(sbyte row, sbyte col, byte value)
        {
            for (sbyte x = row; x < row+3; x++)
            {
                for (sbyte y = col; y < col+3; y++)
                {
                    if (Grid[x, y] == value)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Is column valid (all numbers are different)
        /// </summary>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsColumnOK(sbyte col, byte value)
        {
            for (sbyte row = 0; row < 9; row++)
            {
                if (Grid[row, col] == value)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Is row valid (all numbers are different)
        /// </summary>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsRowOK(sbyte row, byte value)
        {
            for (sbyte col = 0; col < 9; col++)
            {
                if (Grid[row, col] == value)
                    return false;
            }
            return true;
        }
    }
}
