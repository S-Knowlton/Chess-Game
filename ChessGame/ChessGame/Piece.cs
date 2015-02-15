using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class Piece
    {
        public Point position;
        public Player player;

        //abstract methods here

        public Piece(Player p)
        {
            player = p;
        }

        public void SetPosition(Point p){
            position = p;
        }

        public Point GetPosition(){
            return position;
        }

        public abstract List<Move> getPossibleMoves(Board board);

        public override abstract string ToString();
    }
}