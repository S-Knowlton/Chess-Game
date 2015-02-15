using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /*
     * Placeholder piece on a board. Represents an empty space
     */ 
    class EmptyPiece : Piece
    {

        public EmptyPiece():base(new Player(0))
        {
            
        }

        public override List<Point> getPossibleEndSpaces(Board board)
        {
            return new List<Point>();
        }

        public override string ToString()
        {
            return "  ";
        }
    }
}
