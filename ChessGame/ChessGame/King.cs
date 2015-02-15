using System;
using System.Drawing;

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

        public override List<Point> getPossibleEndSpaces(Board b)
        {
            List<Point> endSpaces = new List<Point>();

            Point upLeft = new Point(position.X - 1, position.Y - 1);
            Point up = new Point(position.X - 1, position.Y);
            Point upRight = new Point(position.X - 1, position.Y + 1);
            Point right = new Point(position.X, position.Y + 1);
            Point downRight = new Point(position.X + 1, position.Y + 1);
            Point down = new Point(position.X + 1, position.Y);
            Point downLeft = new Point(position.X + 1, position.Y - 1);
            Point left = new Point(position.X, position.Y - 1);

            List<Point> possibles = new List<Point>();
            possibles.Add(upLeft);
            possibles.Add(up);
            possibles.Add(upRight);
            possibles.Add(right);
            possibles.Add(downRight);
            possibles.Add(down);
            possibles.Add(downLeft);
            possibles.Add(left);

            for (int i = 0; i < possibles.Count(); i++)
            {
                if (b.pointExists(possibles[i]))
                {
                    endSpaces.Add(possibles[i]);
                }
            }

            return endSpaces;
        }

        public override string ToString()
        {
            return "+" + player.GetID();
        }
    }
}
