using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    abstract class Piece
    {
       Point position;
       Player player;

        //abstract methods here
       public abstract List<Move> getPossibleMoves();
    }
}