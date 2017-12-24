using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicTacToe.Models;

namespace TicTacToe
{
    public class Board
    {
        public bool GameOver { get; set; }
        public bool IsDraw { get; set; }

        private Player player1;
        private Player player2;
        private int moves;
        private int[] board;

        public Board(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            board = new int[9];
            moves = 0;
        }

        public void MakeMove(int player, int position)
        {
            moves++;
            board[position - 1] = player;
            if (CheckWinner())
            {
                player1.Games++;
                player2.Games++;
                if (player % 2 == 1)
                {
                    player1.Wins++;
                }
                else
                {
                    player2.Wins++;
                }
                GameOver = true;
            }
            else if(moves == 9)
            {
                GameOver = true;
                IsDraw = true;
            }
        }

        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (((board[i * 3] != 0 && board[(i * 3)] == board[(i * 3) + 1] && board[(i * 3)] == board[(i * 3) + 2]) ||
                     (board[i] != 0 && board[i] == board[i + 3] && board[i] == board[i + 6])))
                {
                    return true;
                }
            }

            if ((board[0] != 0 && board[0] == board[4] && board[0] == board[8]) ||
                (board[2] != 0 && board[2] == board[4] && board[2] == board[6]))
            {
                return true;
            }

            return false;
        }

        public void ClearBoard()
        {
            for(int i = 0; i < 9; ++i)
            {
                board[i] = 0;
            }
            moves = 0;
        }
    }
}