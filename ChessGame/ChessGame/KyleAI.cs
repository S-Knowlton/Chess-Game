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

        public Move GetMove(Board b){

            List<Piece> pieces = GetBlackPieces(b);

            List<Move> moves = getAllMoves(b, pieces);

            if (pieces.Count == 0)
            {
                return null;
            }
            else
            {
                Random rand = new Random();

                //select a move to take a piece (if able)
                bool canTake = false;

                List<Move> takeMoves = new List<Move>(0);

                List<Piece> oppPieces = GetWhitePieces(b);
                for (int i = 0; i < moves.Count; i++)
                {
                    for (int j = 0; j < oppPieces.Count; j++)
                    {
                        if (moves[i].End == b.GetPiecePosition(oppPieces[j]))
                        {
                            //then I can take it
                            System.Console.WriteLine("I can take a piece");
                            canTake = true;
                            takeMoves.Add(moves[i]);
                        }
                    }
                }

                if (canTake)
                {
                    return takeMoves[rand.Next(takeMoves.Count())];
                }
                else
                {
                    return moves[rand.Next(moves.Count())];
                }
            }
        }

        //pieces must belong to the board passed ID1 = board1, ID2 = board2
        public List<Move> getAllMoves(Board b, List<Piece> pieces)
        {
            List<Move> moves = new List<Move>();

            for (int i = 0; i < pieces.Count; i++)
            {
                List<Point> endPoints = pieces[i].getPossibleEndSpaces(b);
                for (int j = 0; j < endPoints.Count; j++)
                {
                    moves.Add(new Move(pieces[i].GetPosition(), endPoints[j]));
                }
            }

            return moves;
        }

        public List<Piece> GetBlackPieces(Board b)
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

        public List<Piece> GetWhitePieces(Board b)
        {
            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Point tempPoint = new Point(i, j);
                    if (b.GetPieceAt(tempPoint).player.GetID() == 1)
                    {
                        pieces.Add(b.GetPieceAt(tempPoint));
                    }
                }
            }

            return pieces;
        }

        Board OpponentBoard(Board b)
        {
            return new Board(b);
        }

        List<Move> convertMovesToMyBoard(List<Move> l)
        {
            List<Move> fixedMoves = new List<Move>();
            for (int i = 0; i < l.Count; i++)
            {
                fixedMoves.Add(new Move(new Point(7 - l[i].Start.X, 7 - l[i].Start.Y), new Point(7-l[i].End.X, 7-l[i].End.Y)));
            }
            return fixedMoves;
        }

        List<Piece> PiecesByType(Board b, Piece p)
        {
            List<Piece> foundPieces = new List<Piece>();

            List<Piece> pieces = GetBlackPieces(b);
            for (int i = 0; i < pieces.Count; i++)
            {

                //System.Console.WriteLine(pieces[i].ToString());

                if (pieces[i].ToString() == p.ToString())
                {
                    foundPieces.Add(pieces[i]);
                }
            }

            return foundPieces;
        }
        
    }
}
