using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{

    /*
     * Chess pieces implement these methods and fields.
     */ 
    public abstract class Piece
    {
        public Point position;
        public Player player;


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

        public abstract List<Point> getPossibleEndSpaces(Board board);

        public override abstract string ToString();
    }
}