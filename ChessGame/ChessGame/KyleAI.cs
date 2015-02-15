using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class KyleAI
    {

        MainWindow owner;

        public KyleAI(MainWindow o)
        {
            owner = o;
        }

        public Move getMove(Board b){

            List<Piece> pieces = getBlackPieces(b);
            List<Move> moves = new List<Move>();


            for (int i = 0; i < pieces.Count; i++)
            {
                List<System.Drawing.Point> endPoints = pieces[i].getPossibleEndSpaces(b);
                for (int j = 0; j < endPoints.Count; j++)
                {
                    moves.Add(new Move(pieces[i].GetPosition(), endPoints[j]));
                }
            }

            if (pieces.Count == 0)
            {
                return null;
            }
            else
            {
                Random rand = new Random();
                return moves[rand.Next(moves.Count())];
            }
        }

        public List<Piece> getBlackPieces(Board b)
        {

            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Point tempPoint = new Point(i, j);
                    if (b.GetPieceAt(tempPoint).player.GetID() == 2)
                    {
                        pieces.Add(b.GetPieceAt(tempPoint));
                    }
                }
            }

            return pieces;
        }
    }
}
