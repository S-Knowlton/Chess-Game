using System;
using System.Drawing;

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

        /*
         * Returns a list of points that the queen could move to
         */ 
        public override List<Point> getPossibleEndSpaces(Board b)
        {
            List<Point> endSpaces = new List<Point>();

            //downLeft
            bool hitSomething = false;
            Point currentPosition = new Point(position.X, position.Y);
            while (b.pointExists(new Point(currentPosition.X + 1, currentPosition.Y - 1)) && hitSomething == false)
            {
                currentPosition.X += 1;
                currentPosition.Y -= 1;

                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            //downRight
            hitSomething = false;
            currentPosition = new Point(position.X, position.Y);
            while (b.pointExists(new Point(currentPosition.X + 1, currentPosition.Y + 1)) && hitSomething == false)
            {
                currentPosition.X += 1;
                currentPosition.Y += 1;

                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            //upLeft
            hitSomething = false;
            currentPosition = new Point(position.X, position.Y);
            while (b.pointExists(new Point(currentPosition.X - 1, currentPosition.Y - 1)) && hitSomething == false)
            {
                currentPosition.X -= 1;
                currentPosition.Y -= 1;

                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            //upRight
            hitSomething = false;
            currentPosition = new Point(position.X, position.Y);
            while (b.pointExists(new Point(currentPosition.X - 1, currentPosition.Y + 1)) && hitSomething == false)
            {
                currentPosition.X -= 1;
                currentPosition.Y += 1;

                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            hitSomething = false;
            currentPosition = new Point(position.X, position.Y);

            //up
            while (b.pointExists(new Point(currentPosition.X - 1, currentPosition.Y)) && hitSomething == false)
            {
                currentPosition.X -= 1;
                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            hitSomething = false;
            currentPosition = new Point(position.X, position.Y);
            //right
            while (b.pointExists(new Point(currentPosition.X, currentPosition.Y + 1)) && hitSomething == false)
            {
                currentPosition.Y += 1;
                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            hitSomething = false;
            currentPosition = new Point(position.X, position.Y);
            //down
            while (b.pointExists(new Point(currentPosition.X + 1, currentPosition.Y)) && hitSomething == false)
            {
                currentPosition.X += 1;
                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            hitSomething = false;
            currentPosition = new Point(position.X, position.Y);
            //left
            while (b.pointExists(new Point(currentPosition.X, currentPosition.Y - 1)) && hitSomething == false)
            {
                currentPosition.Y -= 1;
                if (b.GetPieceAt(currentPosition).player.GetID() == 0)
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                }
                else if (b.GetPieceAt(currentPosition).player.GetID() != player.GetID())
                {
                    endSpaces.Add(new Point(currentPosition.X, currentPosition.Y));
                    hitSomething = true;
                }
                else
                {
                    hitSomething = true;
                }
            }

            return endSpaces;
        }

        public override string ToString()
        {
            return "Q" + player.GetID();
        }
    }
}
