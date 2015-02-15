using System;
using System.Drawing;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Bishop : Piece
    {
        public Bishop(Player p):base(p)
        {

        }

        public override List<Point> getPossibleEndSpaces(Board b)
        {
            return null;
        }

        public override string ToString()
        {
            return "B" + player.GetID();
        }
    }
}
