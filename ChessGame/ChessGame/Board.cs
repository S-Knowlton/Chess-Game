using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Board
    {
        Piece[,] board;

        Board(Player p1, Player p2){
            board = new Piece[8,8];

            //player 1 (white)
            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new Pawn(p1);
            }
            board[7, 0] = new Rook(p1);
            board[7, 1] = new Knight(p1);
            board[7, 2] = new Bishop(p1);
            board[7, 3] = new Queen(p1);
            board[7, 4] = new King(p1);
            board[7, 5] = new Bishop(p1);
            board[7, 6] = new Knight(p1);
            board[7, 7] = new Rook(p1);

            //player 2 (black)
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn(p2);
            }
            board[0, 0] = new Rook(p2);
            board[0, 1] = new Knight(p2);
            board[0, 2] = new Bishop(p2);
            board[0, 3] = new Queen(p2);
            board[0, 4] = new King(p2);
            board[0, 5] = new Bishop(p2);
            board[0, 6] = new Knight(p2);
            board[0, 7] = new Rook(p2);

        }

        int GetPlayerAt(Point p){
            return 0;
        }

        static string PointToBoardName(Point p)
        {
            return "not yet implemented";
        }
    }
}
