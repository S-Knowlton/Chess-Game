using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Pawn : Piece
    {
        public Pawn(Player p):base(p)
        {
            
        }

        public override List<Move> getPossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
