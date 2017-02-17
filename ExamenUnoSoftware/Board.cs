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
    }
}