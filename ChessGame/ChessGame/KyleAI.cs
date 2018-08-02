using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChessGame
{
    class KyleAI
    {

        Page owner;

        public KyleAI(Page o)
        {
            owner = o;
        }

        /*
         * Returns the move specified by the AI
         */ 
        public Move GetMove(Board b){

            List<Piece> pieces = GetBlackPieces(b);

            List<Move> moves = GetAllMoves(b, pieces);

            //if we're out of pieces, we lose (reset the game)
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

                if (canTake) //take it
                {
                    return takeMoves[rand.Next(takeMoves.Count())];
                }
                else //do a random move
                {
                    return moves[rand.Next(moves.Count())];
                }
            }
        }

        //pieces must belong to the board passed ID1 = board1, ID2 = board2
        List<Move> GetAllMoves(Board b, List<Piece> pieces)
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

        /*
         * Returns a list of black pieces on the specified board
         */ 
        List<Piece> GetBlackPieces(Board b)
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

        /*
         * returns a list of white pieces on the specified board
         */
        List<Piece> GetWhitePieces(Board b)
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
    }
}
