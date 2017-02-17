using System;
using TechTalk.SpecFlow;

namespace ExamenUnoSoftware
{
    public class Board
    {
        private string[,] board;
        private int rowsCount;
        private int columnsCount;

        public Board()
        {
            this.rowsCount = 3;
            this.columnsCount = 3;
            this.board = new string[rowsCount, columnsCount];
            init();
        }

        private void init()
        {
            for (int i = 0; i < rowsCount; ++i)
            {
                for (int k = 0; k < columnsCount; ++k)
                {
                    this.board[i, k] = " ";
                }
            }
        }

        public void SetFromTable(Table table)
        {
            for (int i = 0; i < table.RowCount; ++i)
            {
                TableRow row = table.Rows[i];
                for (int k = 0; k < columnsCount; ++k)
                {
                    string currChar = row[k];
                    this.board[i, k] = string.IsNullOrEmpty(currChar) ? " " : currChar;
                }
            }

            Console.Write(board);
        }

        public string GetCharAtPos(int rowPos, int columnPos)
        {
            return board[rowPos, columnPos];
        }

        public bool CheckRowWin(string currentSymbol)
        {
            bool wRow = false;
            for (int i = 0; i < rowsCount; i++)
            {
                int matchCount = 0;
                for (int k = 0; k < columnsCount; ++k)
                {
                    if (board[i, k].Equals(currentSymbol) && !board[i, k].Equals(" "))
                    {
                        ++matchCount;
                    }
                }

                if (matchCount == 3)
                {
                    return true;
                }
            }

            return wRow;
        }

        public bool CheckColumnWin(string currentSymbol)
        {
            bool wCol = false;
            for (int i = 0; i < columnsCount; i++)
            {
                int matchCount = 0;
                for (int k = 0; k < rowsCount; ++k)
                {
                    if (board[k, i].Equals(currentSymbol) && !board[k, i].Equals(" "))
                    {
                        ++matchCount;
                    }
                }

                if (matchCount == 3)
                {
                    return true;
                }
            }

            return wCol;
        }

        public bool CheckDiagonalWin(string currentSymbol)
        {
            int m = 0, n = columnsCount - 1;
            bool diag1 = true;
            bool diag2 = true;
            for (int i = 0; i < rowsCount; i++)
            {
                if (!board[i, m++].Equals(currentSymbol))
                    diag1 = false;

                if (!board[i, n--].Equals(currentSymbol))
                    diag2 = false;
            }

            return diag1 || diag2;
        }

        public bool CheckFullWin(string currentSymbol)
        {
            return CheckRowWin(currentSymbol) || CheckColumnWin(currentSymbol) || CheckDiagonalWin(currentSymbol);
        }

        public bool isFull()
        {
            bool winOne = CheckFullWin("X");
            bool WinTwo = CheckFullWin("0");

            if ((winOne || WinTwo))
            {
                return false;
            }

            bool isFullBoard = true;

            for (int row = 0; row < rowsCount; ++row)
            {
                for (int column = 0; column < columnsCount; ++column)
                {
                    if (board[row, column].Equals(" "))
                    {
                        isFullBoard = false;
                        break;
                    }
                }

                if (!isFullBoard)
                {
                    break;
                }
            }

            return isFullBoard;
        }
    }
}