using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class EmptyPiece : Piece
    {

        public EmptyPiece():base(new Player(0))
        {
            
        }

        public override List<Move> getPossibleMoves(Board board)
        {
            return new List<Move>();
        }

        public override string ToString()
        {
            return "  ";
        }
    }
}
