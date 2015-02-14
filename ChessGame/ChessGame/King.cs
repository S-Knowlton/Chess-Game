using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class King : Piece
    {
        public King(Player p): base(p)
        {

        }

        public override List<Move> getPossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }
    }
}
