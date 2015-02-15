using System;
using System.Drawing;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Knight : Piece
    {
        public Knight(Player p):base(p)
        {
           
        }

        public override List<Point> getPossibleEndSpaces(Board b)
        {
            Point upLeft = new Point(position.X - 2, position.Y - 1);
            Point upRight = new Point(position.X - 2, position.Y + 1);
            Point rightUp = new Point(position.X - 1, position.Y + 2);
            Point rightDown = new Point(position.X + 1, position.Y + 2);
            Point downRight = new Point(position.X + 2, position.Y + 1);
            Point downLeft = new Point(position.X + 2, position.Y - 1);
            Point leftDown = new Point(position.X + 1, position.Y - 2);
            Point leftUp = new Point(position.X - 1, position.Y - 2);

            List<Point> possibles = new List<Point>();
            possibles.Add(upLeft);
            possibles.Add(upRight);
            possibles.Add(rightUp);
            possibles.Add(rightDown);
            possibles.Add(downRight);
            possibles.Add(downLeft);
            possibles.Add(leftDown);
            possibles.Add(leftUp);

            List<Point> endSpaces = new List<Point>();

            for(int i = 0; i < possibles.Count(); i++){
                if (b.pointExists(possibles[i]) && b.GetPieceAt(possibles[i]).player.GetID() != player.GetID())
                {
                    endSpaces.Add(possibles[i]);
                }
            }

            return endSpaces;
        }

        public override string ToString()
        {
            return "K" + player.GetID();
        }

    }
}
