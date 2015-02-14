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
        public Player player;

        //abstract methods here

        public Piece(Player p)
        {
            player = p;
        }

        public abstract List<Move> getPossibleMoves(Board board);

        public override abstract string ToString();
    }
}