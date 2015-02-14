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
        Piece[][] board;

        Board(){
            board = new Piece[8][8];
            board[0][0] = new Pawn();
        }

        int getPlayerAt(Point){

        }
    }
}
