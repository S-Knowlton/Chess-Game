using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Queen : Piece
    {

        public Queen(Player p):base(p)
        {

        }

        public override List<Move> getPossibleMoves(Board b)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Q" + player.GetID();
        }
    }
}
