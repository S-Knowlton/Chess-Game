using System;
using System.Drawing;
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

        public override List<Point> getPossibleEndSpaces(Board board)
        {
            Point oneForward = new Point(position.X - 1, position.Y);
            Point twoForward = new Point(position.X - 2, position.Y);
            Point takeRight = new Point(position.X - 1, position.Y - 1);
            Point takeLeft = new Point(position.X - 1, position.Y + 1);

            List<Point> endSpaces = new List<Point>();

            //checks forward bounds
            if (position.X != 0)
            {

                //the space in front of it
                if (board.GetPieceAt(oneForward).player.GetID() == 0)
                {
                    endSpaces.Add(oneForward);

                    //if it hasn't moved yet
                    if (position.X == 6 && board.GetPieceAt(twoForward).player.GetID() == 0)
                    {
                        endSpaces.Add(twoForward);
                    }
                }

                //taking a piece (we will not allow 'en pesante')
                //checks right and left bounds
                if (position.Y != 7 && position.Y != 0 && board.GetPieceAt(takeRight).player.GetID() != 0 && board.GetPieceAt(takeRight).player.GetID() != player.GetID())
                {
                    endSpaces.Add(takeRight);
                }

                if (position.Y != 7 && position.Y != 0 && board.GetPieceAt(takeLeft).player.GetID() != 0 && board.GetPieceAt(takeLeft).player.GetID() != player.GetID())
                {
                    endSpaces.Add(takeLeft);
                }
            }

            return endSpaces;
        }

        public override string ToString()
        {
            return "P" + player.GetID();
        }
    }
}
